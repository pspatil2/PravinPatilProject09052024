using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Appsetting _appsetting;

        public HomeController(ILogger<HomeController> logger, IOptions<Appsetting> appsetting)
        {
            _logger = logger;
            _appsetting = appsetting.Value;
        }

        public IActionResult Index()
        {

            return View();
        }

        public JsonResult Adduser(string username, string password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_appsetting.connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_Insertuser", con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.ExecuteScalar();
                        con.Close();
                        return Json("ok");
                    }
                }
            }
            catch(Exception ex) 
            {
                return Json(ex.ToString());
            }
            
            
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
