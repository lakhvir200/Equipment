using Equipment.Get.Core.Helpers.Out;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equipment.Admin.MVC.UI.Controllers
{
    [Authorize]
    public class RepairController : Controller
    {
        // GET: RepairController
        public ActionResult Index()
        {
             RepairManageApiServices equipmentApiServices = new RepairManageApiServices();
             var rec = equipmentApiServices.AllRepair();
             return View(rec);           
        }
               
        //GET: Equipment
        [HttpGet]
        public ActionResult NewRepair()
        {
            RepairManageApiServices repairApiServices = new RepairManageApiServices();
            RepairMaster repair = new RepairMaster();            
            return View(repair);
        }                

        [HttpGet]
        public ActionResult Details(int id)
        {
            RepairManageApiServices equipmentApiServices = new RepairManageApiServices();
            var rec = equipmentApiServices.GetRepairById(id);
            return View(rec);
        }

        [HttpGet]
        public ActionResult AllRepair()
        {
            RepairManageApiServices equipmentApiServices = new RepairManageApiServices();
            var rec = equipmentApiServices.AllRepair();
            return View(rec);
        }

        // POST: Equipment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewRepair(RepairMaster equipments)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    equipments.STATUS = true;

                    RepairManageApiServices equipmentApiServices = new RepairManageApiServices();
                    var rec = equipmentApiServices.AddUpdateRepair(equipments, "I");
                    return Redirect("/Repair/Details?id=" + rec);
                }
                catch
                {
                    return View(equipments);
                }
            }
            else
            {
                return View(equipments);
            }
        }


        [HttpGet]
        public ActionResult EditRepair(int id)
        {
            RepairManageApiServices equipmentApiServices = new RepairManageApiServices();
            var rec = equipmentApiServices.GetRepairById(id);

            RepairMaster equipments = new RepairMaster();
            equipments.RID = rec.RID;
            equipments.RNO = rec.RNO;
            equipments.ACTION_TAKEN = rec.ACTION_TAKEN;
            equipments.ATT_BY = rec.ATT_BY;
            equipments.DEPT = rec.DEPT;
            equipments.EQ_ID = rec.EQ_ID;
            equipments.RDATE = rec.RDATE;
            equipments.RDateEdit = rec.RDATE.ToString("yyyy-MM-dd");
            equipments.REPAIR_MAINT = rec.REPAIR_MAINT;
            equipments.SPARES = rec.SPARES;
            equipments.Specifications = rec.Specifications;
            equipments.STATUS = rec.STATUS;
            equipments.Used = rec.Used;
            return View(equipments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRepair(RepairMaster equipments)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    equipments.STATUS = true;
                    RepairManageApiServices equipmentApiServices = new RepairManageApiServices();
                    var rec = equipmentApiServices.AddUpdateRepair(equipments, "U");                   
                    return Redirect("/Repair/Details?id=" + equipments.RID);
                }
                catch
                {
                    return View(equipments);
                }
            }
            else
            {
                return View(equipments);
            }
        }
    }
}
