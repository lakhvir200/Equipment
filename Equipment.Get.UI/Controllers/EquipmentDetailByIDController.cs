using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentDetailByIDController : ControllerBase
    {
        IEquipmentDetailByIDService _equipmentDetailByIDService;
        public EquipmentDetailByIDController(IEquipmentDetailByIDService equipmentDetailByIDService)
        {
            _equipmentDetailByIDService = equipmentDetailByIDService;
        }

        [HttpGet]
        public async Task<EquipmentView> GetAllEquipmentDetailByIDAsync(int id)
        {
            return await _equipmentDetailByIDService.GetAllEquipmentDetailByIDAsync(id);
        }
    }
}
