using Equipment.Data.Infrastructure.Services.Get;
using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        IMasterService _masterService;
        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpGet("GetMasterById")]
        public async Task<Master> GetMasterByID(int MasterID)
        {
            return await _masterService.GetMasterByID(MasterID);
        }
        
        [HttpPost]
        public async Task<int> AddMaster(Master master)
        {
            var isAdded = await _masterService.AddMaster(master);
            return isAdded;
        }

        [HttpPut]
        public async Task<int> UpdateMaster(Master master)
        {
            var isUpdate = await _masterService.UpdateMaster(master);
            return isUpdate;
        }

        [HttpDelete]
        public async Task<Master> DeleteMaster(int MasterID, bool IsActive, bool IsPermanentDelete)
        {
            var isDelete = await _masterService.DeleteMaster(MasterID, IsActive, IsPermanentDelete);
            return isDelete;
        }

        [HttpGet("GetAllMaster")]
        public async Task<IEnumerable<Master>> GetAllMaster()
        {
            MasterService masterService = new MasterService();// Object

            var result = await masterService.GetAllMaster();// method calling 
            return result;
        }

    }
}


