using KTF.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTF.Service.Interfaces
{
    public interface IStaplerService
    {
        Task AddAsync(StaplerHistory entity);
        Task CancelAsync(StaplerHistory entity);
    }
}
