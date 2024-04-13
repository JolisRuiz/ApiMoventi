using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ComplejoDeportivo
    {
        public ComplejoDeportivo() { }
        public int ComplejoDeportivoId { get; set; }
        public string CodigoComplejo { get; set; }
        public string NombreComplejo { get; set; }
        public decimal PresupuestoAproximado { get; set; }
        public string Localizacion { get; set; }
        public JefeOrganizacion JefeOrganizacion { get; set; }
        public decimal AreaTotalOcupada { get; set; }
        public TipoComplejo TipoComplejo { get; set; }
        public TipoDeporte TipoDeporte { get; set; }
        public bool Estado { get; set; }
    }
}
