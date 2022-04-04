using Equipment.Admin.MVC.UI.Services;
using Equipment.Get.Core.Helpers.Out;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Equipment.Admin.MVC.UI.Controllers
{
    public class MasterManagerController : Controller
    {

        public MasterManagerController()
        {

        }
        // GET: MasterManagerController
        public ActionResult Index(string q)
        {
            var _qdata = Utilities.Decrypt(q);
            if (_qdata != null)
            {
                ViewBag.MasterId = _qdata;
                SubMasterApiService subMasterApiService = new SubMasterApiService();
                return View(subMasterApiService.GetAllSubMasterById(Convert.ToInt32(_qdata)));
            }
            else
            {
                return View("Home", "Dashboard");
            }
        }

        // GET: MasterManagerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MasterManagerController/Create
        public ActionResult Create(string q)
        {
            var _qdata = Utilities.Decrypt(q);
            if (_qdata != null)
            {
                ViewBag.MasterId = _qdata;
                SubMaster subMaster = new SubMaster();
                subMaster.MasterId = Convert.ToInt32(_qdata);
                return View(subMaster);
            }
            else
            {
                return View("Home", "Dashboard");
            }
        }

        // POST: MasterManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubMaster sub)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    SubMasterApiService subMasterApiService = new SubMasterApiService();
                    sub.CreatedDate = DateTime.Now;
                    sub.updatedtime = DateTime.Now;
                    sub.IsActive = true;
                    subMasterApiService.AddNewSubMaster(sub);                  
                    return RedirectToAction("index", new { q = Utilities.Encrypt(sub.MasterId.ToString()) });

                }
                catch
                {
                    return View(sub);
                }
            }
            else
            {
                return View(sub);
            }
        }

        // GET: MasterManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MasterManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MasterManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
