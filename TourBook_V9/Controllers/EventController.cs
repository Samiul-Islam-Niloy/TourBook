using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TourBook_V9.Models;
using System.Security.Cryptography;
using System.Data.Entity.Validation;


namespace TourBook_V9.Controllers
{

    
    public class EventController : Controller
    {
        public DB_EntitiesEvent _dbc = new DB_EntitiesEvent();
        public EventNameList x = new EventNameList();
        public DB_Entities Euser = new DB_Entities();
        private readonly EventNameList _cc;
        private readonly DB_EntitiesEvent _xx;
        private readonly CreateEvent _zz;
      
        public EventController()
        {
            
        }
        public EventController(EventNameList cc)
        {
            _cc = cc;
        }
        [HttpGet]
        public ActionResult Notification(EventNameList cc)
        {
            
            var results = cc.NameList.ToList();
            return View(results);
        }

        /////update
        ///
       
        public ActionResult Edit(int id,User vv)
        {
            using (var context = new DB_Entities())
            {
                var data = context.Users.Where(x => x.idUser == id).SingleOrDefault();
                return View(data);
            }
           
        }

       
        [HttpPost]
        public ActionResult Edit( updateUser model)
        {
            using (var context = new updateUserEntities())
            {

                // particular record from a database 
                var data = context.Users.FirstOrDefault(x => x.idUser == model.idUser);
                              
              
                    data.mobile = model.mobile;
                    data.location = model.location;
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.Email = model.Email;
                    data.dob = model.dob;
                    data.marital = model.marital;
                    data.gender = model.gender;
                    data.bio = model.bio;

                    context.SaveChanges();
                
               
                return View();
            }
        }

        //////join////
        ///


        public ActionResult Join(int id, CreateEvent vv, updateUser model)
        {


            using (var context = new DB_EntitiesEvent())
            {
                var data = context.Events.Where(x => x.EventID == id).SingleOrDefault();



                if (data.total_member > 0 && data.total_member != 0)
                {

                    data.total_member = data.total_member - 1;
                    context.SaveChanges();
                }


                using (var context2 = new updateUserEntities())
                {
                    string tem = @Session["Email"].ToString();
                    var data2 = context2.Users.Where(x => x.Email == tem).SingleOrDefault();

                    data2.REvent = id.ToString();


                    context2.SaveChanges();

                    //return RedirectToAction("Homepage");

                }



                return View(data);
            }
        }
        /////////show members
        ///




        public ActionResult Members(int id, DB_Entities mm)
        {


           
                string tempo = id.ToString();
                var results = mm.Users.Where(x => x.REvent == tempo).ToList();



            return View(results);
            
        }




        /// ////search
        public EventController(CreateEvent zz)
        {
            _zz =zz;
        }
        public EventController(DB_EntitiesEvent xx)
        {
            _xx = xx;
        }



        
        public ActionResult Details(int id, DB_EntitiesEvent mm)
        {



            var results = mm.Events.Where(x => x.EventID == id).ToList();
            return View(results);


        }


        [HttpGet]
        public ActionResult Homepage(DB_EntitiesEvent mm)
        {



            var results = mm.Events.ToList();
            return View(results);


        }

        // GET: Event
        public ActionResult Index()
        {
            //ViewBag.Name = @Session["FullName"].ToString();
            return View();
        }

        public ActionResult Create(CreateEvent ec1 , EventNameInput ec2)
        {
            ec2.Name = @Session["FullName"].ToString();
           
            ec1.EventCreator= @Session["FullName"].ToString();

            if (ec1.Time != null)
            {
               

                _dbc.Configuration.ValidateOnSaveEnabled = false;
                x.Configuration.ValidateOnSaveEnabled = false;
                _dbc.Events.Add(ec1);
                x.NameList.Add(ec2);
                _dbc.SaveChanges();
                x.SaveChanges();
                ViewBag.message = "Record " + ec1.EventID + " saved";
                return View(ec1);
              

            }

            



            return View();
            //return RedirectToAction("Index");
            
        }

        public ActionResult info(DB_Entities mm)
        {

           string test = @Session["Email"].ToString();

            var results = mm.Users.Where(x => x.Email == test).ToList();
          //  var results = mm.Users.ToList();
            return View(results);


        }

    }
}