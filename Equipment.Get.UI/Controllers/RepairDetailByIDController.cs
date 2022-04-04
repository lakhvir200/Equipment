using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairDetailByIDController : ControllerBase
    {
        IRepairMasterServices _equipmentDetailByIDService;
        public RepairDetailByIDController(IRepairMasterServices equipmentDetailByIDService)
        {
            _equipmentDetailByIDService = equipmentDetailByIDService;
        }

        [HttpGet]
        public async Task<RepairView> GetAllRepairDetailByID(int id)
        {
            return await _equipmentDetailByIDService.GetAllRepairDetailByIDAsync(id);
        }
    }
}
