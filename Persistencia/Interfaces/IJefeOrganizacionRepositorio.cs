using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interfaces
{
    public interface IJefeOrganizacionRepositorio
    {
        List<JefeOrganizacion> ListaJefeOrganizacion();
        int RegistrarEditarJefeOrganizacion(JefeOrganizacion jefe, int usuarioId);
        JefeOrganizacion ObtenerJefeOrganizacion(int id);
        int EliminarJefeOrganizacion(int jefeId, int usuarioId);
    }
}
