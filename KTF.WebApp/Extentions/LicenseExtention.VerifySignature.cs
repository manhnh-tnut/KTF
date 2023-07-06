using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace KTF.WebApp.Extentions
{
    public partial class LicenseExtention
    {
        public static bool VerifySignature(string plainText, string base64Signature)
        {
            //byte[] publicPemBytes = File.ReadAllBytes("cert.pem");
            //using var publicX509 = new X509Certificate2(publicPemBytes);
            //using RSA rsa = publicX509.GetRSAPublicKey();
            //byte[] dataBytes = System.Text.Encoding.Default.GetBytes(plainText);
            //byte[] signatureBytes = Convert.FromBase64String(base64Signature);
            //return rsa.VerifyData(dataBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            using var publicX509 = new X509Certificate2(X509Certificate.CreateFromCertFile("cert.pem"));
            using RSA rsa = publicX509.GetRSAPublicKey();
            byte[] dataBytes = System.Text.Encoding.Default.GetBytes(plainText);
            byte[] signatureBytes = Convert.FromBase64String(base64Signature);
            return rsa.VerifyData(dataBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
    }
}
