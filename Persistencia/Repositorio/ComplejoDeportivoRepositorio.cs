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
    public class ComplejoDeportivoRepositorio : IComplejoDeportivoRepositorio
    {
        public List<TipoComplejo> ListarTipoComplejo()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<TipoComplejo> Lista = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.ListarTipoComplejo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                Lista = new List<TipoComplejo>();

                while (dr.Read())
                {
                    TipoComplejo m = new TipoComplejo();
                    m.TipoComplejoId = Convert.ToInt16(dr["TipoComplejoId"]);
                    m.NombreTipoComplejo = dr["NombreTipoComplejo"].ToString();
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

        public List<TipoDeporte> ListarTipoDeporte()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<TipoDeporte> Lista = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.ListarTipoDeporte", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                Lista = new List<TipoDeporte>();

                while (dr.Read())
                {
                    TipoDeporte m = new TipoDeporte();
                    m.TipoDeporteId = Convert.ToInt16(dr["TipoDeporteId"]);
                    m.TipoDeporteNombre = dr["NombreDeporte"].ToString();
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
        public List<ComplejoDeportivo> ListarComplejoDeportivo()
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<ComplejoDeportivo> Lista = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.ListarComplejosDeportivos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                Lista = new List<ComplejoDeportivo>();

                while (dr.Read())
                {
                    ComplejoDeportivo c = new ComplejoDeportivo();
                    c.ComplejoDeportivoId = Convert.ToInt16(dr["ComplejoDeportivoId"]);
                    c.CodigoComplejo = dr["CodigoComplejo"].ToString();
                    c.NombreComplejo = dr["NombreComplejo"].ToString();
                    c.PresupuestoAproximado = Convert.ToDecimal(dr["PresupuestoAproximado"]);
                    c.Localizacion = dr["Localizacion"].ToString();

                    JefeOrganizacion j = new JefeOrganizacion();
                    j.JefeOrganizacionId = Convert.ToInt16(dr["JefeOrganizacionId"]);
                    j.NombreJefe = dr["NombreJefe"].ToString();
                    c.JefeOrganizacion = j;

                    TipoComplejo tc = new TipoComplejo();
                    tc.TipoComplejoId = Convert.ToInt16(dr["TipoComplejoId"]);
                    tc.NombreTipoComplejo = dr["NombreTipoComplejo"].ToString();
                    c.TipoComplejo = tc;

                    TipoDeporte t = new TipoDeporte();
                    t.TipoDeporteId = Convert.ToInt16(dr["TipoDeporteId"]);
                    t.TipoDeporteNombre = dr["NombreDeporte"].ToString();
                    c.TipoDeporte = t;

                    c.AreaTotalOcupada = Convert.ToDecimal(dr["AreaTotalOcupada"]);
                    c.Estado = Convert.ToBoolean(dr["Estado"]);
                    Lista.Add(c);

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

        public int RegistrarEditarComplejoDeportivo(ComplejoDeportivo complejoDeportivo, int usuarioId)
        {
            int resultado = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.CrearEditarComplejoDeportivo", cn);
                cmd.Parameters.AddWithValue("@pComplejoDeportivoId", complejoDeportivo.ComplejoDeportivoId);
                cmd.Parameters.AddWithValue("@pCodigoComplejo", complejoDeportivo.CodigoComplejo);
                cmd.Parameters.AddWithValue("@pNombreComplejo", complejoDeportivo.NombreComplejo);
                cmd.Parameters.AddWithValue("@pPresupuestoAproximado", complejoDeportivo.PresupuestoAproximado);
                cmd.Parameters.AddWithValue("@pLocalizacion", complejoDeportivo.Localizacion);
                cmd.Parameters.AddWithValue("@pJefeOrganizacionId", complejoDeportivo.JefeOrganizacion.JefeOrganizacionId);
                cmd.Parameters.AddWithValue("@pAreaTotalOcupada", complejoDeportivo.AreaTotalOcupada);
                cmd.Parameters.AddWithValue("@pTipoComplejoId", complejoDeportivo.TipoComplejo.TipoComplejoId);
                cmd.Parameters.AddWithValue("@pTipoDeporteId", complejoDeportivo.TipoDeporte.TipoDeporteId);
                cmd.Parameters.AddWithValue("@pUsuarioId", usuarioId);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    resultado = Convert.ToInt32(dr["ComplejoDeportivoId"]);
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

        public ComplejoDeportivo ObtenerComplejoDeportivo(int complejoDeportivoId)
        {
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            ComplejoDeportivo c = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.ObtenerComplejoDeportivo", cn);
                cmd.Parameters.AddWithValue("@pComplejoDeportivoId", complejoDeportivoId);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                c = new ComplejoDeportivo();

                while (dr.Read())
                {
                    c.ComplejoDeportivoId = Convert.ToInt16(dr["ComplejoDeportivoId"]);
                    c.CodigoComplejo = dr["CodigoComplejo"].ToString();
                    c.NombreComplejo = dr["NombreComplejo"].ToString();
                    c.PresupuestoAproximado = Convert.ToDecimal(dr["PresupuestoAproximado"]);
                    c.Localizacion = dr["Localizacion"].ToString();

                    JefeOrganizacion j = new JefeOrganizacion();
                    j.JefeOrganizacionId = Convert.ToInt16(dr["JefeOrganizacionId"]);
                    j.NombreJefe = dr["NombreJefe"].ToString();
                    c.JefeOrganizacion = j;

                    TipoComplejo tc = new TipoComplejo();
                    tc.TipoComplejoId = Convert.ToInt16(dr["TipoComplejoId"]);
                    tc.NombreTipoComplejo = dr["NombreTipoComplejo"].ToString();
                    c.TipoComplejo = tc;

                    TipoDeporte t = new TipoDeporte();
                    t.TipoDeporteId = Convert.ToInt16(dr["TipoDeporteId"]);
                    t.TipoDeporteNombre = dr["NombreDeporte"].ToString();
                    c.TipoDeporte = t;

                    c.AreaTotalOcupada = Convert.ToDecimal(dr["AreaTotalOcupada"]);
                    c.Estado = Convert.ToBoolean(dr["Estado"]);
                    
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
            return c;
        }

        public int EliminarComplejoDeportivo(int complejoDeportivoId, int usuarioId)
        {
            int resultado = 0;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("RTMoventi.EliminarComplejoDeportivo", cn);
                cmd.Parameters.AddWithValue("@pComplejoDeportivoId", complejoDeportivoId);
                cmd.Parameters.AddWithValue("@pUsuarioId", usuarioId);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    resultado = Convert.ToInt32(dr["ComplejoDeportivoId"]);
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
