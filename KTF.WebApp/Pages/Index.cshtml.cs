using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KTF.Repository;
using KTF.Repository.Interfaces;
using KTF.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KTF.WebApp.Pages {
    public class IndexModel : PageModel 
    {
        private readonly GenericRepository<Machine> _machineService;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _machineService = unitOfWork.MachineRepository;
        }

        [BindProperty]
        public IQueryable<Machine> Machines { get=>_machineService?.Get(orderBy:o=>o.OrderBy(e=>e.Name)); }
    }
}
