using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using BusTicket.DomainModels.Models;
using Dapper;

namespace BusTicket.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var connectionString =
                ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DBConnectionStringName"]]
                    .ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            var res = connection.Query<Color>("Select * FROM Colors", new {Title = "black"});
            return View(res);
        }
    }
}