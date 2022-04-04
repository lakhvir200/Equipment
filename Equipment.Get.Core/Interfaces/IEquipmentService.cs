using Equipment.Get.Core.Helpers.Out;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentView>> GetAllEquipmentAsync();
        Task<int> AddEquipment(Equipments equipments);       
        Task<int>UpdateEquipment(Equipments equipments);
        Task<Equipments> DeleteEquipments(int ID, bool IsActive, bool IsPermanentDelete);


    }
}

