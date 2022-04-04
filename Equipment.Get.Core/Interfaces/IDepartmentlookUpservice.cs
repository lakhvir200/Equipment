using Equipment.Get.Core.Helpers.Out;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
    interface IDepartmentlookUpservice
    {
        Task<List<DepartmentLookup>> GetAllDepartmentAsync();
        //Task<List<Departments> GetAllDepartmentAsync();
        // Task<List<Equipments>> GetAllEquipmentAsync();

    }
}
