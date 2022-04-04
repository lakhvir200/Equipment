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
    public class MasterLookupController : ControllerBase
    {
        IMasterLookupService _masterLookupService;
        public MasterLookupController(IMasterLookupService masterLookupService)
        {
            _masterLookupService = masterLookupService;
        }
        [HttpGet]
        public async Task<MasterLookup> GetAllMasterlookup()
        {
            MasterLookupServices masterLookupService = new MasterLookupServices();// Object

            var result = await masterLookupService.GetAllMasterlookup();// method calling 
            return result;
        }
    }
}

