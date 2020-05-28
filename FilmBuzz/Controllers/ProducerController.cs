using FilmBuzz.Common.Interface;
using FilmBuzz.Common.Model;
using FilmBuzz.Handler.Command;
using FilmBuzz.Handler.Query;
using FilmBuzz.Handler.QueryResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilmBuzz.Controllers
{
    public class ProducerController : Controller
    {
        private IDispatcher _dispatcher;
        public ProducerController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        // GET: Producer
        public ActionResult Index()
        {            
            return View(_dispatcher.Execute<GetProducers, IEnumerable<GetProducersResult>>(new GetProducers()));
        }


        // GET: Producer/Details/5
        public ActionResult Details(int id)
        {
            return View(_dispatcher.Execute<GetProducersById, GetProducersResult>(new GetProducersById() { 
            ProducerId=id}));
        }

        // GET: Producer/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateProducer()
        {
            return PartialView("_createProducer");
        }

        [HttpPost]
        public ActionResult CreateProducer(TBL_PRODUCERS prod)
        {
            _dispatcher.Execute<CreateProducer>(new CreateProducer()
            {
                Name = prod.Name,
                Sex = prod.Sex,
                Bio = prod.Bio,
                DOB = prod.DOB
            });
            return RedirectToAction("Create","Movie");
            //var output=_dispatcher.Execute<GetProducers, IEnumerable<GetProducersResult>>(new GetProducers());
            //return Json(output, JsonRequestBehavior.AllowGet);
        }
        // POST: Producer/Create
        [HttpPost]
        public ActionResult Create(TBL_PRODUCERS collection)
        {
            try
            {
                // TODO: Add insert logic here
                _dispatcher.Execute<CreateProducer>(new CreateProducer() { 
                Name=collection.Name,
                Sex=collection.Sex,
                Bio=collection.Bio,
                DOB=collection.DOB});
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Producer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producer/Edit/5
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

        // GET: Producer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producer/Delete/5
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
