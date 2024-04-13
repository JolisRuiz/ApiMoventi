using Dominio;
using Servicio.Interfaces;
using Servicio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PresentacionWebMvc.Controllers
{
    public class ComplejoController : Controller
    {
        private IJefeOrganizacionServicio JefeOrganizacionServicio;
        private IComplejoDeportivoServicio ComplejoDeportivoServicio;

        public ComplejoController() {
            this.JefeOrganizacionServicio = new JefeOrganizacionServicio();
            this.ComplejoDeportivoServicio = new ComplejoDeportivoServicio();
        }

        public ComplejoController(IJefeOrganizacionServicio _JefeOrganizacionServicio, IComplejoDeportivoServicio _ComplejoDeportivoServicio)
        {
            this.JefeOrganizacionServicio = _JefeOrganizacionServicio;
            this.ComplejoDeportivoServicio = _ComplejoDeportivoServicio;
        }

        #region Jefe
        [HttpGet]
        public ActionResult MantenedorJefe(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            List<JefeOrganizacion> Lista = JefeOrganizacionServicio.ListaJefeOrganizacion();
            return View(Lista);
        }

        [HttpGet]
        public ActionResult NuevoEditarJefe(int JefeOrganizacionId)
        {
            if (JefeOrganizacionId > 0)
            {
                JefeOrganizacion jefe = JefeOrganizacionServicio.ObtenerJefeOrganizacion(JefeOrganizacionId);
                return View(jefe);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult NuevoEditarJefe(JefeOrganizacion jefe)
        {
            try
            {
                entUsuario us = (entUsuario)Session["usuario"];
                int usuarioId = us.idUsuario;
                int resultado = JefeOrganizacionServicio.RegistrarEditarJefeOrganizacion(jefe, usuarioId);

                if (resultado > 0)
                {
                    return RedirectToAction("MantenedorJefe", "Complejo", new { mensaje = "Se registró Satisfactoriamente" });
                }
                else {
                    ViewBag.mensaje = "No se puedo registrar";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensaje = ex.Message });
            }
        }
     
        public ActionResult EliminarJefe(int JefeOrganizacionId)
        {
            try
            {
                entUsuario us = (entUsuario)Session["usuario"];
                int usuarioId = us.idUsuario;

                int resultado = JefeOrganizacionServicio.EliminarJefeOrganizacion(JefeOrganizacionId, usuarioId);
                if (resultado > 0)
                {
                    return RedirectToAction("MantenedorJefe", "Complejo", new { mensaje = "Se eliminó Satisfactoriamente" });
                }
                else
                {
                    ViewBag.mensaje = "No se puedo eliminar";
                    return View();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { mensaje = e.Message });
            }
        }
        #endregion

        #region Complejo Deportivo
        public ActionResult MantenedorComplejo(string mensaje)
        {
            ViewBag.mensaje = mensaje;
            List<ComplejoDeportivo> Lista = ComplejoDeportivoServicio.ListarComplejoDeportivo();
            return View(Lista);
        }

        [HttpGet]
        public ActionResult NuevoEditarComplejo(int ComplejoDeportivoId)
        {

            List<JefeOrganizacion> ListaJefe = JefeOrganizacionServicio.ListaJefeOrganizacion();
            var lstJefes = new SelectList(ListaJefe, "JefeOrganizacionId", "NombreJefe");
            ViewBag.ListaJefeOrganizacion = lstJefes;

            List<TipoComplejo> ListaTipoComplejo = ComplejoDeportivoServicio.ListarTipoComplejo(); 
            var lstTipoComplejo = ListaTipoComplejo;
            ViewBag.ListaTipoComplejo = new SelectList(lstTipoComplejo, "TipoComplejoId", "NombreTipoComplejo"); 

            List<TipoDeporte> ListaTipoDeporte = ComplejoDeportivoServicio.ListarTipoDeporte();
            var lstTipoDeporte = ListaTipoDeporte;
            ViewBag.ListaTipoDeporte = new SelectList(lstTipoDeporte, "TipoDeporteId", "TipoDeporteNombre");

            if (ComplejoDeportivoId > 0)
            {
                ComplejoDeportivo complejo = ComplejoDeportivoServicio.ObtenerComplejoDeportivo(ComplejoDeportivoId);
                return View(complejo);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult NuevoEditarComplejo(ComplejoDeportivo complejo)
        {
            try
            {
                entUsuario us = (entUsuario)Session["usuario"];
                int usuarioId = us.idUsuario;
                int resultado = ComplejoDeportivoServicio.RegistrarEditarComplejoDeportivo(complejo, usuarioId);

                if (resultado > 0)
                {
                    return RedirectToAction("MantenedorComplejo", "Complejo", new { mensaje = "Se registró Satisfactoriamente" });
                }
                else
                {
                    ViewBag.mensaje = "No se puedo registrar";
                    return View();
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { mensaje = ex.Message });
            }
        }

        public ActionResult EliminarComplejo(int ComplejoDeportivoId)
        {
            try
            {
                entUsuario us = (entUsuario)Session["usuario"];
                int usuarioId = us.idUsuario;

                int resultado = ComplejoDeportivoServicio.EliminarComplejoDeportivo(ComplejoDeportivoId, usuarioId);
                if (resultado > 0)
                {
                    return RedirectToAction("MantenedorComplejo", "Complejo", new { mensaje = "Se eliminó Satisfactoriamente" });
                }
                else
                {
                    ViewBag.mensaje = "No se puedo eliminar";
                    return View();
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Error", new { mensaje = e.Message });
            }
        }

        #endregion
    }
}
