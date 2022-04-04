using Equipment.Get.Core.Helpers.Out;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Equipment.Get.Core.Interfaces
{
   public interface IEquipmentDetailByIDService
    {
      public  Task <EquipmentView> GetAllEquipmentDetailByIDAsync(int id);

    }
}
