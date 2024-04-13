using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoDeporte
    {
        public TipoDeporte() { }
        public int TipoDeporteId { get; set; }
        public string TipoDeporteNombre { get; set; }
        public bool Estado { get; set; }
    }
}
