using Contactos_CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace Contactos_CRUDCORE.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var oLista = new List<ContactoModel>(); // Esta variable va a conterner la lista de contactos 

            var newConexion = new Conexion(); // Con esta variable vamos a obtener la cadena SQL para conectarnos a la base de datos 

            using (var conexion = new SqlConnection(newConexion.getCadenaSQL()))
            {
                conexion.Open(); // Abrimos la cadena de ejecucion 
                // Ahora procedemos a poner los comandos  a ejecutar
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);// Vamos a ejecutar el procedimiento sp_listar previamente declarado en la base de datos sql
                cmd.CommandType = CommandType.StoredProcedure;// Estamos especificando que es un procedimiento almacenado lo que vamos a ejecutar 

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oLista.Add(new ContactoModel
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString(),
                        }) ;
                    }
                }
            }
            return oLista;
        }

        public ContactoModel ObtenerByID(int ID)
        {
            var oContacto = new ContactoModel();

            var newConexion = new Conexion();

            using (var conexion = new SqlConnection(newConexion.getCadenaSQL()))
            {
                conexion.Open();
                
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {

                        oContacto.ID= Convert.ToInt32(reader["ID"]);
                        oContacto.Nombre = reader["Nombre"].ToString();
                        oContacto.Correo = reader["Correo"].ToString();
                        oContacto.Telefono = reader["Telefono"].ToString();
                        
                    }
                }
            }
            return oContacto;
        }

        public bool Guardar (ContactoModel oContacto)
        {
            bool respuesta;
            try
            {
                var newconexion = new Conexion();
                using (var conexion = new SqlConnection(newconexion.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch (Exception e) 
            {
                string Error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool respuesta;

            try
            {
                var newConexion = new Conexion();//Optener la cadena de conexion sql
                
                using ( var conexion = new SqlConnection(newConexion.getCadenaSQL()))
                {
                    conexion.Open();

                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("ID", oContacto.ID);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();// Vamos a ejecutar el procedimiento estructurado

                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string Error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool Eliminar( int ID )
        {
            bool respuesta;

            try
            {
                var newConexion = new Conexion();

                using ( var conexion = new SqlConnection(newConexion.getCadenaSQL()) )
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("ID", ID );
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }
            catch ( Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }


            return respuesta;
        }

    }
}
