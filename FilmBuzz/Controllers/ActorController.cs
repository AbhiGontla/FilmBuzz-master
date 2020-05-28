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
    public class ActorController : Controller
    {

        private IDispatcher _dispatcher;
        public ActorController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        // GET: Actor
        public ActionResult Index()
        {
            return View(_dispatcher.Execute<GetActors, IEnumerable<GetActorsResult>>(new GetActors()));
        }

        // GET: Actor/Details/5
        public ActionResult Details(int id)
        {

            return View(_dispatcher.Execute<GetActorsById, GetActorsResult>(new GetActorsById() { ActorId = id }));
        }

        // GET: Actor/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateActor()
        {
            return PartialView("_createActor");
        }
        [HttpPost]
        public ActionResult CreateActor(TBL_ACTORS collection)
        {
            _dispatcher.Execute<CreateActor>(new CreateActor()
            {
                Name = collection.Name,
                Sex = collection.Sex,
                Bio = collection.Bio,
                DOB = collection.DOB
            });
            return RedirectToAction("Create", "Movie");
        }

        // POST: Actor/Create
        [HttpPost]
        public ActionResult Create(TBL_ACTORS collection)
        {
            try
            {
                // TODO: Add insert logic here
                _dispatcher.Execute<CreateActor>(new CreateActor()
                {
                    Name = collection.Name,
                    Sex = collection.Sex,
                    Bio = collection.Bio,
                    DOB = collection.DOB
                });
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Actor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Actor/Edit/5
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

        // GET: Actor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Actor/Delete/5
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
