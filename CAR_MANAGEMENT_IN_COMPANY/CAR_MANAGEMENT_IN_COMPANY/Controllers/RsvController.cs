using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAR_MANAGEMENT_IN_COMPANY.Controllers
{
    public class RsvController : Controller
    {
        // GET: Rsv
        public ActionResult Index()
        {
            return View();
        }

        // GET: Rsv/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rsv/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rsv/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rsv/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rsv/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rsv/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Rsv/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
