using Dominio;
using Servicio.Interfaces;
using Servicio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.IO;
using System.Data;

namespace PresentacionWebMvc.Controllers
{
    public class AlmacenController : Controller
    {
        public AlmacenController()
        {
        }

        public ActionResult Principal()
        {
            return View();
        }

	}
}