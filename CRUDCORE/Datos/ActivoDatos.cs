using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{

    public class ActivoDatos
    {
        public List<ActivoModel> Listar()
        {
            var activos = new List<ActivoModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarActivos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        activos.Add(new ActivoModel
                        {
                            IdActivo = Convert.ToInt32(dr["IdActivo"]),
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Estado = dr["Estado"].ToString()
                        });
                    }
                }
            }

            return activos;
        }

        public ActivoModel Obtener(int IdActivo)
        {
            var activo = new ActivoModel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerActivo", conexion);
                cmd.Parameters.AddWithValue("IdActivo", IdActivo);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        activo.IdActivo = Convert.ToInt32(dr["IdActivo"]);
                        activo.Nombre = dr["Nombre"].ToString();
                        activo.Descripcion = dr["Descripcion"].ToString();
                        activo.Estado = dr["Estado"].ToString();
                    }
                }
            }

            return activo;
        }

        public bool Guardar(ActivoModel activo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarActivo", conexion);
                    cmd.Parameters.AddWithValue("Nombre", activo.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", activo.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", activo.Estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(ActivoModel activo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarActivo", conexion);
                    cmd.Parameters.AddWithValue("IdActivo", activo.IdActivo);
                    cmd.Parameters.AddWithValue("Nombre", activo.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", activo.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", activo.Estado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Eliminar(int IdActivo)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarActivo", conexion);
                    cmd.Parameters.AddWithValue("IdActivo", IdActivo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }
    }
}
