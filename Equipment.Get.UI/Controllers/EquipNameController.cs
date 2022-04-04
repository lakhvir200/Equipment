using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Equipment.Data.Infrastructure;
using Equipment.Get.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Equipment.Get.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipNameController : ControllerBase
    {
        private readonly EquipmentDbContext _dbContext;

        public EquipNameController(EquipmentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}