
using DataAccessLayer;
using MySomething.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MySomething.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();          

            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserViewModel usr)
        {
            if (!ModelState.IsValid)
            {
                return View(usr);
            }


            //UserRepository rep = new UserRepository();
            //
            //User userDataModel = new User();userDataModel.CreateDate = usr.CreateDate;
            //userDataModel.IsDeleted = false;
            //userDataModel.Name = usr.Name;
            //userDataModel.Surname = usr.Surname;
            //userDataModel.Type = usr.Type;
            //userDataModel.Username = usr.Username;
            //userDataModel.Password = usr.Password;
            //rep.Add(userDataModel);

            UserRepository rep = new UserRepository();
            User userDataModel = new User();

            string serializerStr = JsonConvert.SerializeObject(usr);
            userDataModel = JsonConvert.DeserializeObject<User>(serializerStr);
            //  userDataModel = JsonConvert.DeserializeObject<User>(JsonConvert.SerializeObject(usr));
            rep.Add(userDataModel);

            return RedirectToAction("Index");
            
        }
    }
}