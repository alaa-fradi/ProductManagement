using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Domaine.Entities;
using Service;

using System.IO;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        

        //GET : envoyer les donnees au post 
        public ActionResult Index()
        {
            return View();
        }

        // contient le traitement 
        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            if ((userName == "client") && (password == "123321"))
            {
                Session["userName"] = userName;
                return(RedirectToAction("Index", "Products"));
            }
            else { return View(); }
              
            
        }



    }

        
    }
