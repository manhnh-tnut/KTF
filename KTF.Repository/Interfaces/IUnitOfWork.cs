using KTF.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTF.Repository.Interfaces
{
    public interface IUnitOfWork
    {

         GenericRepository<Line> LineRepository { get; }

         GenericRepository<Machine> MachineRepository { get; }

        GenericRepository<ScaleReport> ScaleReportRepository { get; }

        GenericRepository<ScaleHistory> ScaleHistoryRepository { get; }

        GenericRepository<StaplerReport> StaplerReportRepository { get; }

        GenericRepository<StaplerHistory> StaplerHistoryRepository { get; }

        Task SaveChangesAsync();
    }
}
