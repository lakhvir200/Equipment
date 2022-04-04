using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Get.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        IEquipmentService _equipmentService;
        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<EquipmentView>> GetEquipmentList()
        {
            return await _equipmentService.GetAllEquipmentAsync();
        }

        [HttpPost]
        public async Task<int> AddNewEquipment(Equipments equipment)
        {           
            var isAdded = await _equipmentService.AddEquipment(equipment);
            return isAdded;
        }
             
        [HttpPut]
        public async Task<int> UpdateEquipment(Equipments equipment)
        {
            equipment.IsActive = true;
            var isUpdate = await _equipmentService.UpdateEquipment(equipment);
            return isUpdate;
        }
        

        [HttpDelete]
        public async Task<Equipments> DeleteEquipments(int MasterID, bool IsActive, bool IsPermanentDelete)
        {
            var isDelete = await _equipmentService.DeleteEquipments(MasterID, IsActive, IsPermanentDelete);
            return isDelete;
        }

    }
}


