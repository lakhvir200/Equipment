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
    public class ConsumptionController : ControllerBase
    {
        IConsumptionService _consumptionsService;
        public ConsumptionController(IConsumptionService consumptionsService)
        {
            _consumptionsService = consumptionsService;
        }
        [HttpGet]
        public async Task<IEnumerable<Consumption>> GetAllConsumption()
        {
            ConsumptionServices consumptionsService = new ConsumptionServices();// Object

            var result = await consumptionsService.GetAllConsumption();// method calling 
            return result;
        }
    }
}
