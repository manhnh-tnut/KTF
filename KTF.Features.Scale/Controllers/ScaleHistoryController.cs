using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KTF.Shared.Models;
using KTF.Service.Interfaces;
using KTF.Repository.Interfaces;

namespace KTF.Features.Scale.Controllers
{
    [Route("api/Scale-History")]
    [ApiController]
    public class ScaleHistoryController : ControllerBase
    {
        private readonly ILogger<ScaleHistoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ScaleHistoryController(ILogger<ScaleHistoryController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<dynamic> Get(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_unitOfWork.ScaleHistoryRepository.Get().OrderByDescending(i => i.Created), loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string values)
        {
            try
            {
                var entity = new ScaleHistory();
                JsonConvert.PopulateObject(values, entity);
                _unitOfWork.ScaleHistoryRepository.Insert(entity);
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
            var entity = _unitOfWork.ScaleHistoryRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }
            JsonConvert.PopulateObject(values, entity);

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
    }
}
