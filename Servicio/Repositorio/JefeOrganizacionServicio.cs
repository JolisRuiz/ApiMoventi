using Dominio;
using Persistencia.Interfaces;
using Persistencia.Repositorio;
using Servicio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Repositorio
{
    public class JefeOrganizacionServicio : IJefeOrganizacionServicio
    {
        private IJefeOrganizacionRepositorio repositorio;
        public JefeOrganizacionServicio() : this(new JefeOrganizacionRepositorio()) { }
        public JefeOrganizacionServicio(IJefeOrganizacionRepositorio _repositorio)
        {
            this.repositorio = _repositorio;
        }

        public int EliminarJefeOrganizacion(int jefeId, int usuarioId)
        {
            try
            {
                return repositorio.EliminarJefeOrganizacion(jefeId, usuarioId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<JefeOrganizacion> ListaJefeOrganizacion()
        {
            try
            {
                return repositorio.ListaJefeOrganizacion();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public JefeOrganizacion ObtenerJefeOrganizacion(int id)
        {
            return repositorio.ObtenerJefeOrganizacion(id);
        }

        public int RegistrarEditarJefeOrganizacion(JefeOrganizacion jefe, int usuarioId)
        {
            try
            {
                return repositorio.RegistrarEditarJefeOrganizacion(jefe, usuarioId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
