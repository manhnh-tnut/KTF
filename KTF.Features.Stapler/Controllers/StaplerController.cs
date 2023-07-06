using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using KTF.Shared.Models;
using KTF.Service.Interfaces;
using KTF.Repository.Interfaces;
using KTF.Service;

namespace KTF.Features.Stapler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaplerController : ControllerBase
    {
        private readonly ILogger<StaplerController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGpioService _gpioService;
        private readonly IStaplerService _staplerService;
        private readonly Item[] _outputs;

        public StaplerController(ILogger<StaplerController> logger,
            IUnitOfWork unitOfWork,
            IGpioService gpioService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _gpioService = gpioService;
            _staplerService = new StaplerService(_unitOfWork);
            _outputs = gpioService.GetOutputs();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StaplerHistory entity)
        {
            DateTime date = DateTime.Now.Date;
            try
            {
                entity.Creater = User?.Identity?.Name ?? "admin";
                entity.Created = DateTime.Now;
                await _staplerService.AddAsync(entity);

                var _item = _outputs.FirstOrDefault(i => string.Equals(i.Name, entity.Name, StringComparison.OrdinalIgnoreCase));
                if (_item == null)
                {
                    return NotFound($"Output with name '{entity.Name}' not found");
                }
                await _gpioService.WriteAsync(_item);
                return Ok(await GetCurrent(entity));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromForm] Guid key, [FromForm] string values)
        {
            var entity = _unitOfWork.StaplerHistoryRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }
            JsonConvert.PopulateObject(values, entity);

            entity.Updater = User?.Identity?.Name ?? "admin";
            entity.Updated = DateTime.Now;
            try
            {
                _unitOfWork.StaplerHistoryRepository.Update(entity);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] Guid key)
        {
            var entity = _unitOfWork.StaplerHistoryRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.StaplerHistoryRepository.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("Lines")]
        public async Task<dynamic> Lines(DataSourceLoadOptions loadOptions)
        {
            _logger.LogInformation("IP address:", Request.HttpContext.Connection.RemoteIpAddress);
            return await DataSourceLoader.LoadAsync(_unitOfWork.LineRepository.Get(filter: q => q.Machine == "Máy dập ghim", orderBy: o => o.OrderBy(e => e.Name)), loadOptions);
        }

        private async Task<dynamic> GetCurrent(StaplerHistory history)
        {
            DateTime date = history.Created.Date;
            return await _unitOfWork.StaplerReportRepository.Get()
                .OrderByDescending(i => i.Created)
                .FirstOrDefaultAsync(i => i.Created > date && i.Code == history.Code && i.Model == history.Model) ?? new StaplerReport();
        }

        [HttpPost("current")]
        public async Task<IActionResult> Current([FromBody] StaplerHistory history)
        {
            return Ok(await GetCurrent(history));
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> Cancel([FromBody] StaplerHistory entity)
        {
            var date = entity.Created.Date;
            try
            {
                var history = _unitOfWork.StaplerHistoryRepository.Get(filter: q => !q.IsCancelled && q.Created > date && q.Line == entity.Line && q.Code == entity.Code)
                .OrderByDescending(o => o.Created).FirstOrDefault();
                if (history == null)
                {
                    throw new Exception("History not found!");
                }
                history.Updater = User?.Identity?.Name ?? "admin";
                history.Updated = DateTime.Now;
                history.IsCancelled = true;
                await _staplerService.CancelAsync(history);
                return Ok(await GetCurrent(history));
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.Message);
            }
        }

    }
}
