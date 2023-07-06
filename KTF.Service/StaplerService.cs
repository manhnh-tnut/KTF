using KTF.Repository.Interfaces;
using KTF.Service.Interfaces;
using KTF.Shared.Models;

namespace KTF.Service
{
    public class StaplerService : IStaplerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaplerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(StaplerHistory entity)
        {
            var date = entity.Created.Date;
            var line = _unitOfWork.LineRepository.Get(entity.LineId);
            if (line == null)
            {
                throw new Exception("Line not found");
            }
            var query = _unitOfWork.StaplerReportRepository.Get(filter: q => q.Created > date, orderBy: o => o.OrderByDescending(e => e.Created));
            var report = query.FirstOrDefault();
            if (report == null || report.Line != line.Name || report.Code != line.Code || report.Model != line.Model)
            {
                report = new StaplerReport()
                {
                    Code = line.Code,
                    Line = line.Name,
                    Model = line.Model,
                    Creater = entity.Creater,
                    Created = DateTime.Now,
                    Ok = entity.Code == entity.CurrentCode ? 1 : 0,
                    Ng = entity.Code != entity.CurrentCode ? 1 : 0,
                };
                _unitOfWork.StaplerReportRepository.Insert(report);
            }
            else
            {
                report.Ok += entity.Code == entity.CurrentCode ? 1 : 0;
                report.Ng += entity.Code != entity.CurrentCode ? 1 : 0;
                report.Updater = entity.Creater;
                report.Updated = DateTime.Now;
                _unitOfWork.StaplerReportRepository.Update(report);
            }
            _unitOfWork.StaplerHistoryRepository.Insert(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task CancelAsync(StaplerHistory entity)
        {
            var date = entity.Created.Date;

            var query = _unitOfWork.StaplerReportRepository.Get(filter: q => q.Created > date && q.Line == entity.Line && q.Code == entity.Code);
            var report = query.FirstOrDefault();
            if (report == null)
            {
                throw new Exception("Report not found!");
            }
            else
            {
                report.Ok -= entity.Code == entity.CurrentCode ? 1 : 0;
                report.Ng -= entity.Code != entity.CurrentCode ? 1 : 0;
                _unitOfWork.StaplerReportRepository.Update(report);
            }
            _unitOfWork.StaplerHistoryRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
