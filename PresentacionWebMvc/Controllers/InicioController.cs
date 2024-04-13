using Dominio;
using Servicio.Interfaces;
using Servicio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicio;

namespace PresentacionWebMvc.Controllers
{
    public class InicioController : Controller
    {
        private IUsuarioServicio Usuarioservicio;

        public InicioController()
        {
            this.Usuarioservicio = new UsuarioServicio();
        }

        public InicioController(IUsuarioServicio _usuarioServicio)
        {
            this.Usuarioservicio = _usuarioServicio;
        }

        public ActionResult Index(String mensaje)
        {
            ViewBag.mensaje = mensaje;
            return View();
        }

        public ActionResult VerificarAcceso(FormCollection form)
        { 
            try
            {
                String Usuario = form["txtUsuario"];
                String Password = form["txtPassword"];
                entUsuario u = Usuarioservicio.VerificarAccesoIntranet(Usuario, Password);
                Session["usuario"] = u;
                
                return RedirectToAction("Principal", "Almacen");


            }
            catch (ApplicationException x)
            {
                ViewBag.mensaje = x.Message;
                return RedirectToAction("Index", "Inicio", new { mensaje = x.Message });
            }
            catch (Exception e)
            {

                return RedirectToAction("Index", "Inicio", new { mensaje = e.Message });
            }
        }
	}
}