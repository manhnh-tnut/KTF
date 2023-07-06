using System.Diagnostics;
using System.Text;
using KTF.WebApp.Extentions;

namespace KTF.WebApp.Middlewares
{
    public class LicenseMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LicenseMiddleware> _logger;

        public LicenseMiddleware(RequestDelegate next, ILogger<LicenseMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string file = "Lisence.lic";
            var plainText = Helpers.NetworkHepler.GetPhysicalAddress();
            if (File.Exists(file))
            {
                var signature = await File.ReadAllBytesAsync(file);
                if (LicenseExtention.VerifySignature(plainText, ASCIIEncoding.ASCII.GetString(signature)))
                {
                    await _next(context);
                }
                else
                {
                    await context.Response.WriteAsync($"License verify fail for MAC {plainText}.");
                }
            }
            else
            {
                var process = Process.GetCurrentProcess();
                var countdown = TimeSpan.FromMinutes(10) - (DateTime.Now - process.StartTime);
                if (process == null || countdown < TimeSpan.Zero)
                {
                    await context.Response.WriteAsync($"License expired for MAC {plainText}.");
                }
                else
                {
                    // Call the next delegate/middleware in the pipeline.
                    await _next(context);
                }
            }
        }
    }

    public static class LicenseMiddlewareExtensions
    {
        public static IApplicationBuilder UseLicense(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LicenseMiddleware>();
        }
    }
}
