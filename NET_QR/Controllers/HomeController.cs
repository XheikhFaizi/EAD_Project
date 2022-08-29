using Microsoft.AspNetCore.Mvc;
using NET_QR.Models;
using System.Diagnostics;

namespace NET_QR.Controllers
{
    public class HomeController : Controller
    {

        List<User> userslist = new List<User>();
        //private void FetchData()
        //{

        //    string conString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=PROJECT_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    SqlConnection con = new SqlConnection(conString);
        //    string query = $" select * from Users ";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataReader dr;

        //    if (userslist.Count > 0)
        //    {
        //        userslist.Clear();
        //    }
        //    try
        //    {

        //        dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            userslist.Add(new User()
        //            {
        //                name = dr["name"].ToString()
        //            ,
        //                username = dr["username"].ToString()
        //            ,
        //                email = dr["email"].ToString()
        //            ,
        //                pass = dr["pass"].ToString()
        //            });
        //        }
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //////////Return NULL DEFAULT VIEW
        public ViewResult Null()
        {
            return View();
        }

        //////////Return About DEFAULT VIEW
        public ViewResult about()
        {
            return View();


        }

        //////////Return Services DEFAULT VIEW
        public ViewResult services()
        {
            return View();


        }


        //////////Return Pricing DEFAULT VIEW
        public ViewResult pricing()
        {
            return View();


        }

        //////////Return Services DEFAULT VIEW
        public ViewResult contact()
        {
            return View();


        }



        ////////// Index View Home with data
        //public ViewResult Index()
        //{
        //    FetchData();
        //    return View(userslist);
        //}




        //////////// LOGIN POST
        //[HttpPost]
        //public ActionResult login(login ln)
        //{

        //    string conString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=PROJECT_DB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //    SqlConnection con = new SqlConnection(conString);
        //    string query = $" Select * from Users where (email = '{ln.log}' ) AND pass='{ln.pass}'";
        //    SqlCommand cmd = new SqlCommand(query, con);



        //    if (ModelState.IsValid)
        //    {

        //        con.Open();
        //        SqlDataReader de = cmd.ExecuteReader();
        //        if (de.HasRows)
        //        {



        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {


        //            ViewBag.Message = "Sorry! You entered wrong credentials";
        //            return View();
        //        }
        //    }
        //    else
        //    {
        //        return View();
        //    }


        //}




        ////////// SIGNUP POST
        [HttpPost]
        public ActionResult signup(string a)
        {

            if (ModelState.IsValid)
            {

                //using (Project_DbContext db = new Project_DbContext())
                //{

                //    //db.Users.Add(S);

                //}

                return RedirectToAction("Login", "Home");


            }
            else
            {
                return View(a);
            }

        }
    }
}