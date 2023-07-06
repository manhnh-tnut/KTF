using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using KTF.Repository.Interfaces;
using KTF.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KTF.WebManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly ILogger<MachineController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public MachineController(ILogger<MachineController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<dynamic> Get(DataSourceLoadOptions loadOptions)
        {
            return await DataSourceLoader.LoadAsync(_unitOfWork.MachineRepository.Get(), loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string values)
        {
            try
            {
                var entity = new Machine();
                JsonConvert.PopulateObject(values, entity);
                entity.Creater = User.Identity?.Name??"Admin";
                _unitOfWork.MachineRepository.Insert(entity);
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
            var entity = _unitOfWork.LineRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }
            JsonConvert.PopulateObject(values, entity);

            try
            {
                entity.Updater = User.Identity?.Name ?? "Admin";
                entity.Updated = DateTime.Now;
                _unitOfWork.LineRepository.Update(entity);
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
            var entity = _unitOfWork.LineRepository.Get(key);
            if (entity == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.LineRepository.Update(entity);
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
