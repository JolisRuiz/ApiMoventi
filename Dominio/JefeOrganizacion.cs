using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class JefeOrganizacion
    {
        public JefeOrganizacion() { }
        public int JefeOrganizacionId { get; set; }
        public string NombreJefe { get; set; }
        public bool Estado { get; set; }
    }
}
