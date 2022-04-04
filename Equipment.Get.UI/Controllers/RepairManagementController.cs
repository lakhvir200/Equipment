using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairManagementController : ControllerBase
    {
        IRepairMasterServices _repairMasterServices;
        public RepairManagementController(IRepairMasterServices repairMasterServices)
        {
            _repairMasterServices = repairMasterServices;
        }

        [HttpGet]
        public async Task<IEnumerable<RepairMaster>> GetRepairList()
        {
            return await _repairMasterServices.GetAllRepairMaster();
        }

        [HttpPost]
        public async Task<int> AddRepairMaster(RepairMaster repairMaster)
        {
            var isAdded = await _repairMasterServices.AddRepairMaster(repairMaster);
            return isAdded;
        }
        [HttpPut]

        public async Task<int> UpdateRepairMaster(RepairMaster repairMaster)
        {
            var isUpdate = await _repairMasterServices.UpdateRepairMaster(repairMaster);
            return isUpdate;
        }

        [HttpDelete]
                                                                                                                                                                                                                                                                      
        public async Task<RepairMaster> DeleteRepairMaster(int RID, bool STATUS, bool IsPermanentDelete)
        {
            var repairMaster = await _repairMasterServices.DeleteRepairMaster(RID, STATUS, IsPermanentDelete);
            return repairMaster;

        }
    }
}
