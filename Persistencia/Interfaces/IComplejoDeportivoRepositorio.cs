using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Interfaces
{
    public interface IComplejoDeportivoRepositorio
    {
        List<TipoComplejo> ListarTipoComplejo();
        List<TipoDeporte> ListarTipoDeporte();
        List<ComplejoDeportivo> ListarComplejoDeportivo();
        int RegistrarEditarComplejoDeportivo(ComplejoDeportivo complejoDeportivo, int usuarioId);
        ComplejoDeportivo ObtenerComplejoDeportivo(int complejoDeportivoId);
        int EliminarComplejoDeportivo(int complejoDeportivoId, int usuarioId);
    }
}
