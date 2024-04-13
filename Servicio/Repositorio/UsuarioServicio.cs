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
    public class UsuarioServicio:IUsuarioServicio
    {
        private IUsuarioRepositorio repositorio;

        public UsuarioServicio() : this(new UsuarioRepositorio()){ }

        public UsuarioServicio(IUsuarioRepositorio _repositorio)
        {
            this.repositorio = _repositorio;
        }
        public Dominio.entUsuario VerificarAccesoIntranet(String prmstrLogin, String prmstrPassw)
        {
            try
            {                
                entUsuario u = repositorio.VerificarAccesoIntranet(prmstrLogin, prmstrPassw);
                if (u == null)
                {
                    throw new ApplicationException("Usuario o password no valido");
                }
                if (!u.Estado)
                {
                    throw new ApplicationException("Usuario Bloqueado");
                }               
                
                return u;
            }
            catch (ApplicationException ae)
            {
                throw ae;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
