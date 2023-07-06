using KTF.Repository.Interfaces;
using KTF.Service.Interfaces;
using KTF.Shared.Models;

namespace KTF.Service
{
    public class ScaleService : IScaleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScaleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(ScaleHistory entity)
        {
            var date = entity.Created.Date;
            var line = _unitOfWork.LineRepository.Get(entity.LineId);
            if (line == null)
            {
                throw new Exception("Line not found");
            }
            var query = _unitOfWork.ScaleReportRepository.Get(filter: q => q.Created > date, orderBy: o => o.OrderByDescending(e => e.Created));
            var report = query.FirstOrDefault();
            if (report == null || report.Line != line.Name || report.Code != line.Code || report.Model != line.Model)
            {
                report = new ScaleReport()
                {
                    Code = line.Code,
                    Line = line.Name,
                    Model = line.Model,
                    Creater = entity.Creater,
                    Created = DateTime.Now,
                    Quantity = entity.Quantity,
                    Weight = entity.Weight,
                    Total = 1
                };
                _unitOfWork.ScaleReportRepository.Insert(report);
            }
            else
            {
                report.Quantity += entity.Quantity;
                report.Weight += entity.Weight;
                report.Updater = entity.Creater;
                report.Updated = DateTime.Now;
                report.Total++;
                _unitOfWork.ScaleReportRepository.Update(report);
            }
            _unitOfWork.ScaleHistoryRepository.Insert(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
