using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Data.Infrastructure.Services.Get
{
    public class DepartmentServics : IDepartmentlookUpService
    {

        private readonly EquipmentDbContext _departmentDbContext;
        public DepartmentServics(EquipmentDbContext departmentDbContext)
        {
            _departmentDbContext = departmentDbContext;
        }

        public async Task<List<DepartmentLookup>> GetAllDepartmentLookupsAsync()
        {

            List<DepartmentLookup> departments = new List<DepartmentLookup>();
            
              var departmentRecords = await _departmentDbContext.DepartmentLookups.ToListAsync();

            foreach ( var item in departmentRecords)
            {


            }
            return departments;
        }
    }

   
}
