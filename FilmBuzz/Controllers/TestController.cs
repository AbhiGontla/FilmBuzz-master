using FilmBuzz.Common.Interface;
using FilmBuzz.Handler.Query;
using System.Web.Mvc;

namespace FilmBuzz.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        private IDispatcher _dispatcher;
        public TestController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }
        public ActionResult Index()
        {
            var c = _dispatcher.Execute<Test, bool>(new Test());
            return View();
        }
    }
}