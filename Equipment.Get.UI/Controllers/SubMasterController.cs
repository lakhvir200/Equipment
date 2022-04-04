using Equipment.Data.Infrastructure.Services.Get;
using Equipment.Get.Core.Helpers.Out;
using Equipment.Get.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMasterController : ControllerBase
    {
        ISubMasterService _subMasterService;
        public SubMasterController(ISubMasterService subMasterService)
        {
            _subMasterService = subMasterService;
        }
        /// <summary>
        /// GetAllsubMaster
        /// </summary>
        /// <param name="masterid"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<SubMaster>> GetAllsubMaster(int masterid)
        {
            ISubMasterService subMasterService = new SubMasterService();// Object

            var result = await subMasterService.GetAllSubMaster(masterid);// method calling 
            return result;
        }
        /// <summary>
        /// AddSubMaster
        /// </summary>
        /// <param name="subMaster"></param>
        /// <param name="masterid"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<int> AddSubMaster(SubMaster subMaster)
        {
            var isAdded = await _subMasterService.AddSubMaster(subMaster);
            return isAdded;
        }
        /// <summary>
        /// 
        /// </summary>
        [HttpDelete]
        public async Task<SubMaster> DeleteSubMaster(int MasterID,int SubMasterID)
        {
            var isDelete = await _subMasterService.DeleteSubMaster(MasterID, SubMasterID);
            return isDelete;
        }


    }
}