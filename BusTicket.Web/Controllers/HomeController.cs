using System.Web.Mvc;
using BusTicket.DomainModels.Repositories.Impl;

namespace BusTicket.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var repository = new ColorRepository();
            var colors = repository.GetAll();
            return View(colors);
        }
    }
}