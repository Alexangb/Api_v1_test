using Application.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infraestructure.Data
{
    public class DRol
    {
        public async Task<IEnumerable<ERol>> ListarRol()
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "listar_roles";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cnx;

                SqlDataReader reader = cmd.ExecuteReader();
                var lista = new List<ERol>();
                while (reader.Read())
                {
                    lista.Add(new ERol
                    {
                       
                        IDrol = Convert.ToInt32(reader["idrol"]),
                        Rol = reader["rol"].ToString(),
                       

                    }); 

                    
                }
                return lista;
            }
        }

        public async Task<IEnumerable<ERol>> GetRolID(int id)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Obtener_rol";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = cnx;

                SqlDataReader reader = cmd.ExecuteReader();
                var lista = new List<ERol>();
                while (reader.Read())
                {
                    lista.Add(new ERol
                    {
                      
                        IDrol = Convert.ToInt32(reader["idrol"]),
                        Rol = reader["rol"].ToString()
                       

                    }); 

                    
                }
                return lista;
            }
        }

        //public async Task<IEnumerable<EUser>> ObtenerUsuarioPalabra(string palabra)
        //{
        //    using (SqlConnection cnx = new SqlConnection())
        //    {
        //        cnx.ConnectionString = Connection_sql.Cadenacnx();
        //        cnx.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "filtrar_usuarios";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@palabra", palabra);
        //        cmd.Connection = cnx;

        //        SqlDataReader reader = cmd.ExecuteReader();
        //        var lista = new List<EUser>();
        //        while (reader.Read())
        //        {
        //            lista.Add(new EUser
        //            {
        //                IdUser = Convert.ToInt32(reader["idusuario"]),
        //                IdRol = Convert.ToInt32(reader["idrol"]),
        //                Name = reader["nombres"].ToString(),
        //                LastName = reader["apellido"].ToString(),
        //                Email = reader["email"].ToString(),
        //                date_of_birth = Convert.ToDateTime(reader["fecha_naci"].ToString()),
        //                Phone = reader["telefono"].ToString(),
        //                State = reader["estado"].ToString(),
        //                Image = reader["imagen"].ToString(),
        //                NameRol = reader["rol"].ToString()

        //            }); ;

        //            ;
        //        }
        //        return lista;
        //    }
        //}

        public async Task<bool> Crear(ERol u)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insertar_rol";
                cmd.CommandType = CommandType.StoredProcedure;
              
                cmd.Parameters.AddWithValue("@rol", u.Rol);
                
                cmd.Connection = cnx;
                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;
                //return filasAfectadas;



            }
        }
        public async Task<bool> Editar(ERol u)
        {
            using (SqlConnection cnx = new SqlConnection())
            {
                cnx.ConnectionString = Connection_sql.Cadenacnx();
                cnx.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "editar_rol";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idrol", u.IDrol);
                cmd.Parameters.AddWithValue("@rol", u.Rol);
               
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
                cmd.CommandText = "eliminar_rol";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idrol", id);

                cmd.Connection = cnx;


                int rows = await cmd.ExecuteNonQueryAsync();
                return rows > 0;


            }
        }

        //public async Task<bool> Eliminar(int id)
        //{
        //    using (SqlConnection cnx = new SqlConnection())
        //    {
        //        cnx.ConnectionString = Connection_sql.Cadenacnx();
        //        cnx.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandText = "eliminar_usuario";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@idusuario", id);

        //        cmd.Connection = cnx;


        //        int rows = await cmd.ExecuteNonQueryAsync();
        //        return rows > 0;


        //    }
        //}
    }
}
