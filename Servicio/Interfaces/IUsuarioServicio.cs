using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces
{
    public interface IUsuarioServicio
    {
        entUsuario VerificarAccesoIntranet(String prmstrLogin, String prmstrPassw);

    }
}
