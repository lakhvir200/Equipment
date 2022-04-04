using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using Equipment.Get.Core.Helpers.Out;
using Microsoft.AspNetCore.Authorization;

namespace Equipment.Admin.MVC.UI.Controllers
{
    [Authorize]
    public class ConsumptionController : Controller
    {
        //GET: Equipment
        
        public ActionResult GetEquipmentList()
        {
            return View();
        }

      

        [HttpGet]
        public ActionResult AllConsumption()
        {
            ConsumptionApiServices consumptionApiServices = new ConsumptionApiServices();
            var rec = consumptionApiServices.AllConsumption();
            return View(rec);
        }

    }
}