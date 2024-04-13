using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionWebMvc.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(String mensaje)
        {
            ViewBag.mensajito = mensaje;
            return View();
        }
	}
}