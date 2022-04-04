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
    public class EquipmentController : Controller
    {
        //GET: Equipment
        [HttpGet]
        public ActionResult NewEquipment()
        {
            EquipmentApiServices equipmentApiServices = new EquipmentApiServices();
            Equipments equipments = new Equipments();
            equipments.masterLookup = equipmentApiServices.AllLookups();
            return View(equipments);
        }

        public ActionResult GetEquipmentList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            EquipmentApiServices equipmentApiServices = new EquipmentApiServices();
            var rec = equipmentApiServices.GetEquipmentById(id);
            return View(rec);
        }

        [HttpGet]
        public ActionResult AllEquipment()
        {
            EquipmentApiServices equipmentApiServices = new EquipmentApiServices();
            var rec = equipmentApiServices.AllEquipments();
            return View(rec);
        }

        // POST: Equipment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewEquipment(Equipments equipments)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    EquipmentApiServices equipmentApiServices = new EquipmentApiServices();
                    var rec = equipmentApiServices.AddUpdateEquipment(equipments, "I");
                    return Redirect("Details?id=" + rec);
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
        public ActionResult EditEquipment(int id)
        {
            EquipmentApiServices equipmentApiServices = new EquipmentApiServices();
            var rec = equipmentApiServices.GetEquipmentById(id);

            Equipments equipments = new Equipments();
            equipments.ID = id;
            equipments.CategoryName = rec.CategoryName;
            equipments.CostOfEquipment = rec.CostOfEquipment;
            equipments.CreatedDate = rec.CreatedDate;
            equipments.DateOfPurchase = rec.DateOfPurchase.ToString();
            //equipments.DepartmentName = rec.DepartmentName;
            equipments.EquipmentCode = rec.EquipmentCode;
            equipments.EquipmentID = rec.EquipmentID;
            equipments.EquipmentName = rec.EquipmentName;
            //equipments.EquipmentStatus = rec.EquipmentStatus;
            equipments.IsActive = true;
            //equipments.Periodicity = rec.Periodicity;
            equipments.Remarks = rec.Remarks;
            equipments.Specifications = rec.Specifications;
            equipments.SubCategoryName = rec.SubCategoryName;
            //equipments.SupplierName = rec.SupplierName;
            equipments.EquipNameID = rec.EquipNameID;
            equipments.EquipModelID = rec.EquipModelID;
            equipments.CategoryID = rec.CategoryID;
            equipments.SubCategoryID = rec.SubCategoryID;
            equipments.MaintPeriodicityID = rec.MaintPeriodicityID;
            equipments.UnitLookupID = rec.UnitLookupID;
            equipments.DepartmentID = rec.DepartmentID;
            equipments.SupplierID = rec.SupplierID;
            equipments.StatusID = rec.StatusID;
            equipments.BillDeatils = rec.BillDeatils;
            equipments.BudgetYearId = rec.BudgetYearId;
            equipments.DateOfInstallation = rec.DateOfInstallation;
            equipments.BillDate = rec.BillDate;
            equipments.BillDateEdit = rec.BillDate.ToString("yyyy-MM-dd");
            equipments.DateOfInstallationEdit = rec.DateOfInstallation.ToString("yyyy-MM-dd");

            equipments.masterLookup = equipmentApiServices.AllLookups();
            return View(equipments);
        }
    
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEquipment(Equipments equipments)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    EquipmentApiServices equipmentApiServices = new EquipmentApiServices();
                    var rec = equipmentApiServices.AddUpdateEquipment(equipments, "U");
                    return Redirect("/Equipment/Details?id=" + equipments.ID);
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