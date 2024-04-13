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
    public class ComplejoDeportivoServicio : IComplejoDeportivoServicio
    {
        private IComplejoDeportivoRepositorio repositorio;
        public ComplejoDeportivoServicio() : this(new ComplejoDeportivoRepositorio()) { }
        public ComplejoDeportivoServicio(IComplejoDeportivoRepositorio _repositorio)
        {
            this.repositorio = _repositorio;
        }

        public int EliminarComplejoDeportivo(int complejoDeportivoId, int usuarioId)
        {
            try
            {
                return repositorio.EliminarComplejoDeportivo(complejoDeportivoId, usuarioId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<ComplejoDeportivo> ListarComplejoDeportivo()
        {
            try
            {
                return repositorio.ListarComplejoDeportivo();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<TipoComplejo> ListarTipoComplejo()
        {
            try
            {
                return repositorio.ListarTipoComplejo();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<TipoDeporte> ListarTipoDeporte()
        {
            try
            {
                return repositorio.ListarTipoDeporte();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ComplejoDeportivo ObtenerComplejoDeportivo(int complejoDeportivoId)
        {
            return repositorio.ObtenerComplejoDeportivo(complejoDeportivoId);
        }

        public int RegistrarEditarComplejoDeportivo(ComplejoDeportivo complejoDeportivo, int usuarioId)
        {
            try
            {
                return repositorio.RegistrarEditarComplejoDeportivo(complejoDeportivo, usuarioId);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
