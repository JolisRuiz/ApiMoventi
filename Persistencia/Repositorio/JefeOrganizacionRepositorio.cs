using Dominio;
using Persistencia.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repositorio
{
    public class JefeOrganizacionRepositorio : IJefeOrganizacionRepositorio
    {
        public List<JefeOrganizacion> ListaJefeOrganizacion()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<JefeOrganizacion> Lista = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.ListarJefe", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                Lista = new List<JefeOrganizacion>();

                while (dr.Read())
                {
                    JefeOrganizacion m = new JefeOrganizacion();
                    m.JefeOrganizacionId = Convert.ToInt16(dr["JefeOrganizacionId"]);
                    m.NombreJefe = dr["NombreJefe"].ToString();
                    m.Estado = Convert.ToBoolean(dr["Estado"]);
                    Lista.Add(m);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return Lista;
        }

        public int RegistrarEditarJefeOrganizacion(JefeOrganizacion jefe, int usuarioId)
        {
            int resultado = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.CrearEditarJefe", cn);
                cmd.Parameters.AddWithValue("@pNombreJefeId", jefe.JefeOrganizacionId);
                cmd.Parameters.AddWithValue("@pNombreJefe", jefe.NombreJefe);
                cmd.Parameters.AddWithValue("@pUsuarioId", usuarioId);                
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    resultado = Convert.ToInt32(dr["UsuarioId"]);
                }

                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        public JefeOrganizacion ObtenerJefeOrganizacion(int id)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            JefeOrganizacion oJefeOrganizacion = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.ObtenerrJefe", cn);
                cmd.Parameters.AddWithValue("@pNombreJefeId", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                oJefeOrganizacion = new JefeOrganizacion();

                while (dr.Read())
                {
                    oJefeOrganizacion.JefeOrganizacionId = Convert.ToInt16(dr["JefeOrganizacionId"]);
                    oJefeOrganizacion.NombreJefe = dr["NombreJefe"].ToString();
                    oJefeOrganizacion.Estado = Convert.ToBoolean(dr["Estado"]);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return oJefeOrganizacion;
        }
        public int EliminarJefeOrganizacion(int jefeId, int usuarioId)
        {
            int resultado = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.EliminarJefe", cn);
                cmd.Parameters.AddWithValue("@pNombreJefeId", jefeId);
                cmd.Parameters.AddWithValue("@pUsuarioId", usuarioId);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    resultado = Convert.ToInt32(dr["UsuarioId"]);
                }

                return resultado;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

    }
}
