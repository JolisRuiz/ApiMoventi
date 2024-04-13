using Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;
using System.Data;
namespace Persistencia.Repositorio
{
    public class UsuarioRepositorio:IUsuarioRepositorio
    {

        public Dominio.entUsuario VerificarAccesoIntranet(string prmstrLogin, string prmstrPassw)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            entUsuario u = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.ValidarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pUsuario", prmstrLogin);
                cmd.Parameters.AddWithValue("@pClave", prmstrPassw);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entUsuario();
                    u.idUsuario = Convert.ToInt32(dr["UsuarioId"]);
                    u.Usuario = dr["Usuario"].ToString();
                    u.Estado = Convert.ToBoolean(dr["Estado"]);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            finally { cmd.Connection.Close(); }
            return u;
        }
    }
}
