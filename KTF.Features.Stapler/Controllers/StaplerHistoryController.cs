using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KTF.Shared.Models;
using KTF.Service.Interfaces;
using KTF.Repository.Interfaces;

namespace KTF.Features.Stapler.Controllers
{
    [Route("api/Stapler-History")]
    [ApiController]
    public class StaplerHistoryController : ControllerBase
    {
        private readonly ILogger<StaplerHistoryController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public StaplerHistoryController(ILogger<StaplerHistoryController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<dynamic> Get(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_unitOfWork.StaplerHistoryRepository.Get().OrderByDescending(i => i.Created), loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string values)
        {
            try
            {
                var entity = new StaplerHistory();
                JsonConvert.PopulateObject(values, entity);
                _unitOfWork.StaplerHistoryRepository.Insert(entity);
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
            var entity = _unitOfWork.StaplerHistoryRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }
            JsonConvert.PopulateObject(values, entity);

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
    }
}
