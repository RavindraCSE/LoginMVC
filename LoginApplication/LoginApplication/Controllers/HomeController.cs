using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using LoginApplication.Models;

namespace LoginApplication.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
       public ActionResult Index(string UserName, string Password)
        //public ActionResult Index(UserLogin userLogin )
        {
            if (ModelState.IsValid)
            { 
            // write code to connect to the database
            SqlConnection conn = new SqlConnection(@"data source=HPPC\SQL1200;database=Company;User Id=sa;Password=123456");
            string query = "select count(*) from tblUsers where UserName=@UserName and Password=@Password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("@UserName", UserName));
            cmd.Parameters.Add(new SqlParameter("@Password", Password));
            conn.Open();
            int NoOfUsers = (int)cmd.ExecuteScalar();
                if (NoOfUsers > 0)
                {
                    return RedirectToAction("Home");
                }
            }
           



            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}