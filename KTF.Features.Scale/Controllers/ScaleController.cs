using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using KTF.Repository.Interfaces;
using KTF.Service;
using KTF.Service.Interfaces;
using KTF.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KTF.Features.Scale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaleController : ControllerBase
    {
        private readonly ILogger<ScaleController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGpioService _gpioService;
        private readonly IScaleService _scaleService;
        private readonly Item[] _outputs;

        public ScaleController(ILogger<ScaleController> logger,
            IUnitOfWork unitOfWork,
            IGpioService gpioService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _gpioService = gpioService;
            _scaleService = new ScaleService(_unitOfWork);
            _outputs = gpioService.GetOutputs();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ScaleHistory entity)
        {
            DateTime date = DateTime.Now.Date;
            try
            {
                entity.Creater = User?.Identity?.Name ?? "admin";
                entity.Created = DateTime.Now;
                await _scaleService.AddAsync(entity);

                var _item = _outputs.FirstOrDefault(i => string.Equals(i.Name, entity.Name, StringComparison.OrdinalIgnoreCase));
                if (_item == null)
                {
                    return NotFound($"Output with name {entity.Name} not found");
                }
                await _gpioService.WriteAsync(_item, 500);
                return Ok(entity);
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
            var entity = _unitOfWork.ScaleHistoryRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }
            JsonConvert.PopulateObject(values, entity);

            entity.Updater = User?.Identity?.Name ?? "admin";
            entity.Updated = DateTime.Now;
            try
            {
                _unitOfWork.ScaleHistoryRepository.Update(entity);
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
            var entity = _unitOfWork.ScaleHistoryRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.ScaleHistoryRepository.Delete(entity);
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
            return await DataSourceLoader.LoadAsync(_unitOfWork.LineRepository.Get(filter: q => q.Machine == "Máy kết nối cân", orderBy: o => o.OrderBy(e => e.Name)), loadOptions);
        }
    }
}
