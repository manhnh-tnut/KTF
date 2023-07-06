using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KTF.Shared.Models;
using KTF.Service.Interfaces;
using KTF.Repository.Interfaces;

namespace KTF.Features.Scale.Controllers
{
    [Route("api/Scale-Report")]
    [ApiController]
    public class ScaleReportController : ControllerBase
    {
        private readonly ILogger<ScaleReportController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ScaleReportController(ILogger<ScaleReportController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<dynamic> Get(DataSourceLoadOptions loadOptions)
        {
           return await DataSourceLoader.LoadAsync(_unitOfWork.ScaleReportRepository.Get().OrderByDescending(i => i.Created), loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string values)
        {
            try
            {
                var entity = new ScaleReport();
                JsonConvert.PopulateObject(values, entity);
                _unitOfWork.ScaleReportRepository.Insert(entity);
                await _unitOfWork.SaveChangesAsync();
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
            var entity = _unitOfWork.ScaleReportRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }
            JsonConvert.PopulateObject(values, entity);

            try
            {
                _unitOfWork.ScaleReportRepository.Update(entity);
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
            var entity = _unitOfWork.ScaleReportRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.ScaleReportRepository.Delete(entity);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.InnerException?.Message ?? e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
