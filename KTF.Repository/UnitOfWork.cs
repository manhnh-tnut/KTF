using KTF.Repository.Interfaces;
using KTF.Shared.Data;
using KTF.Shared.Models;

namespace KTF.Repository
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private ApplicationDbContext context;
        private GenericRepository<Line> lineRepository;
        private GenericRepository<Machine> staplerRepository;
        private GenericRepository<ScaleReport> scaleReportRepository;
        private GenericRepository<ScaleHistory> scaleHistoryRepository;
        private GenericRepository<StaplerReport> staplerReportRepository;
        private GenericRepository<StaplerHistory> staplerHistoryRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public GenericRepository<Line> LineRepository
        {
            get
            {

                if (lineRepository == null)
                {
                    this.lineRepository = new GenericRepository<Line>(context);
                }
                return lineRepository;
            }
        }

        public GenericRepository<Machine> MachineRepository
        {
            get
            {

                if (this.staplerRepository == null)
                {
                    this.staplerRepository = new GenericRepository<Machine>(context);
                }
                return staplerRepository;
            }
        }

        public GenericRepository<ScaleReport> ScaleReportRepository
        {
            get
            {

                if (this.scaleReportRepository == null)
                {
                    this.scaleReportRepository = new GenericRepository<ScaleReport>(context);
                }
                return scaleReportRepository;
            }
        }

        public GenericRepository<ScaleHistory> ScaleHistoryRepository
        {
            get
            {

                if (this.scaleHistoryRepository == null)
                {
                    this.scaleHistoryRepository = new GenericRepository<ScaleHistory>(context);
                }
                return scaleHistoryRepository;
            }
        }

        public GenericRepository<StaplerReport> StaplerReportRepository
        {
            get
            {

                if (this.staplerReportRepository == null)
                {
                    this.staplerReportRepository = new GenericRepository<StaplerReport>(context);
                }
                return staplerReportRepository;
            }
        }

        public GenericRepository<StaplerHistory> StaplerHistoryRepository
        {
            get
            {

                if (this.staplerHistoryRepository == null)
                {
                    this.staplerHistoryRepository = new GenericRepository<StaplerHistory>(context);
                }
                return staplerHistoryRepository;
            }
        }

        public Task SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}