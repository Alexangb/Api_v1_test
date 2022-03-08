using Application.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;


namespace Application.Infraestructure.Data
{
    public class DUser
    {
        public async Task<IEnumerable<EUser>> ListarUsuario(string estado)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "listar_usuarios";
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Connection = cnx;

                SqlDataReader reader = cmd.ExecuteReader();
                var lista = new List<EUser>();
                while (reader.Read())
                {
                    lista.Add(new EUser
                    {
                        IdUser = Convert.ToInt32(reader["idusuario"]),
                        IdRol = Convert.ToInt32(reader["idrol"]),
                        Name = reader["nombres"].ToString(),
                        LastName = reader["apellido"].ToString(),
                        Email = reader["email"].ToString(),
                        date_of_birth = Convert.ToDateTime(reader["fecha_naci"].ToString()),
                        Phone = reader["telefono"].ToString(),
                        State = reader["estado"].ToString(),
                        //Codigo = reader["codigo"].ToString(),
                        NameRol = reader["rol"].ToString()

                    }); ;

                    ;
                }
                return lista;
            }
        }


        public async Task<IEnumerable<EUser>> PaginarUsuarios(int? pagina_inicio, int? pagina_final, string estado)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "paginado_usuario";

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pagina", pagina_inicio);
                cmd.Parameters.AddWithValue("@cantPagina", pagina_final);
                cmd.Parameters.AddWithValue("@estado", estado);
                cmd.Connection = cnx;

                SqlDataReader reader = cmd.ExecuteReader();
                var lista = new List<EUser>();
                while (reader.Read())
                {
                    lista.Add(new EUser
                    {
                        IdUser = Convert.ToInt32(reader["idusuario"]),
                        IdRol = Convert.ToInt32(reader["idrol"]),
                        Name = reader["nombres"].ToString(),
                        LastName = reader["apellido"].ToString(),
                        Email = reader["email"].ToString(),
                        date_of_birth = Convert.ToDateTime(reader["fecha_naci"].ToString()),
                        Phone = reader["telefono"].ToString(),
                        State = reader["estado"].ToString(),
                        //Codigo = reader["codigo"].ToString(),
                        NameRol = reader["rol"].ToString()

                    }); ;

                    ;
                }
                return lista;
            }
        }
        public async Task<IEnumerable<EUser>> GetUserID(int id)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "obtener_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = cnx;

                SqlDataReader reader = cmd.ExecuteReader();
                var lista = new List<EUser>();
                while (reader.Read())
                {
                    lista.Add(new EUser
                    {
                        IdUser = Convert.ToInt32(reader["idusuario"]),
                        IdRol = Convert.ToInt32(reader["idrol"]),
                        Name = reader["nombres"].ToString(),
                        LastName = reader["apellido"].ToString(),
                        Email = reader["email"].ToString(),
                        date_of_birth = Convert.ToDateTime(reader["fecha_naci"].ToString()),
                        Phone = reader["telefono"].ToString(),
                        State = reader["estado"].ToString(),
                        //Codigo = reader["codigo"].ToString(),
                        NameRol = reader["rol"].ToString()

                    }); ;

                    ;
                }
                return lista;
            }
        }

        public async Task<IEnumerable<EUser>> ObtenerUsuarioPalabra(string palabra)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "filtrar_usuarios";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@palabra",palabra);
                cmd.Connection = cnx;

                SqlDataReader reader = cmd.ExecuteReader();
                var lista = new List<EUser>();
                while (reader.Read())
                {
                    lista.Add(new EUser
                    {
                        IdUser = Convert.ToInt32(reader["idusuario"]),
                        IdRol = Convert.ToInt32(reader["idrol"]),
                        Name = reader["nombres"].ToString(),
                        LastName = reader["apellido"].ToString(),
                        Email = reader["email"].ToString(),
                        date_of_birth = Convert.ToDateTime(reader["fecha_naci"].ToString()),
                        Phone = reader["telefono"].ToString(),
                        State = reader["estado"].ToString(),
                        //Codigo = reader["codigo"].ToString(),
                        NameRol = reader["rol"].ToString()

                    }); ;

                    ;
                }
                return lista;
            }
        }

        public async Task<bool> Crear(EUser u)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insertar_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idrol", u.IdRol);
                cmd.Parameters.AddWithValue("@nombres", u.Name);
                cmd.Parameters.AddWithValue("@apellido", u.LastName);
                cmd.Parameters.AddWithValue("@email", u.Email);
                cmd.Parameters.AddWithValue("@fecha_naci", u.date_of_birth);
                cmd.Parameters.AddWithValue("@telefono", u.Phone);
                cmd.Parameters.AddWithValue("@estado", u.State);
             
                cmd.Connection = cnx;
                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
                //return filasAfectadas;
                


            }
        }
        public async Task<bool> Editar(EUser u)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "editar_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", u.IdUser);
                cmd.Parameters.AddWithValue("@idrol", u.IdRol);
                cmd.Parameters.AddWithValue("@nombres", u.Name);
                cmd.Parameters.AddWithValue("@apellido", u.LastName);
                cmd.Parameters.AddWithValue("@email", u.Email);
                cmd.Parameters.AddWithValue("@fecha_naci", u.date_of_birth);
                cmd.Parameters.AddWithValue("@telefono", u.Phone);
                cmd.Parameters.AddWithValue("@estado", u.State);
              
                cmd.Connection = cnx;


                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;


            }
        }


        public async Task<bool> EliminarL(int id)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "eliminarL_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", id);
              
                cmd.Connection = cnx;


                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;


            }
        }

        public async Task<bool> Eliminar(int id)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "eliminar_usuario";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idusuario", id);

                cmd.Connection = cnx;


                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;


            }
        }


    }
}
