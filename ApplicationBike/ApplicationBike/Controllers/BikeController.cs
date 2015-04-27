using ApplicationBike.BusinessLayer;
using ApplicationBike.BusinessLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplicationBike.Controllers
{
    public class BikeController : Controller
    {
        // GET: Bike
        public ActionResult Index(string SearchRegNumber, string SearchProducer, string SearchColour, int? id)
        {
            

            //call BL
            BikeSearchCommand _command = new BikeSearchCommand();
            _command.RegNumber = SearchRegNumber;
            _command.Producer = SearchProducer;
            _command.Colour = SearchColour;
            _command.PageSize = 3;
            _command.PageIndex = (id ?? 0);
            BikeSearchResult _result = CommandInvoker.InvokeCommand<BikeSearchCommand, BikeSearchResult>(_command);
            //

            ViewBag.HasNext = _result.HasNext;
            ViewBag.HasPrevious = _result.HasPrevious;
            ViewBag.PageIndex = _command.PageIndex;

            return View(_result.Result);

            return View();
        }

        // GET: Bike/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bike/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bike/Create
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

        // GET: Bike/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bike/Edit/5
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

        // GET: Bike/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bike/Delete/5
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
