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
    public class MovieController : Controller
    {
        private IDispatcher _dispatcher;
        public MovieController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        // GET: Movie
        public ActionResult Index()
        {            
            return View(_dispatcher.Execute<GetMovies, IEnumerable<GetMoviesResult>>(new GetMovies()));
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View(_dispatcher.Execute<GetMovieById, GetMoviesResult>(new GetMovieById() { 
            MovieId=id}));
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
           ViewBag.Actor= _dispatcher.Execute<GetActors, IEnumerable<GetActorsResult>>(new GetActors());
            ViewBag.Producer = _dispatcher.Execute<GetProducers, IEnumerable<GetProducersResult>>(new GetProducers());
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(TBL_MOVIES collection)
        {
            try
            {
                
                    // TODO: Add insert logic here
                    _dispatcher.Execute<CreateMovie>(new CreateMovie()
                    {
                        Name = collection.Name,
                        ActorId = collection.ActorId,
                        Plot = collection.Plot,
                        ProducerId = collection.ProducerId,
                        YearofRelease = collection.YearofRelease,
                        ActorsId = collection.ActorsId
                    });
               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            var c=_dispatcher.Execute<GetMovieById, GetMoviesResult>(new GetMovieById()
            {
                MovieId = id
            });
            ViewBag.Actor = _dispatcher.Execute<GetActors, IEnumerable<GetActorsResult>>(new GetActors());
            ViewBag.Producer = _dispatcher.Execute<GetProducers, IEnumerable<GetProducersResult>>(new GetProducers());
            ViewBag.SelectedProducer = c.ProducerId;
            ViewBag.Actors = c.ActorsId;
            var stateList = _dispatcher.Execute<GetActors, IEnumerable<GetActorsResult>>(new GetActors()).ToList();
            //ViewBag.State = new SelectList(stateList, "ActorId", "Name");
            c.SelectedValues = c.ActorsId;
            c.AllValues = new SelectList(stateList, "ActorId", "Name");
            return View(c);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, TBL_MOVIES collection)
        {
            try
            {

                // TODO: Add insert logic here
                _dispatcher.Execute<UpdateMovie>(new UpdateMovie()
                {
                    MovieId=id,
                    Name = collection.Name,                   
                    Plot = collection.Plot,
                    ProducerId = collection.ProducerId,
                    YearofRelease = collection.YearofRelease,
                    SelectedValues = collection.SelectedValues
                });

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
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
