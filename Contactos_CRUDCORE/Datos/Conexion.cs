using System.Data.SqlClient;

namespace Contactos_CRUDCORE.Datos
{
    public class Conexion
    {
        // Con esta clase optemos la cadena de conexion que esta en nuestro archivo settings.json
        private string cadenaSQL = string.Empty;
        //Constructor de la clase
        public Conexion()
        {
            // var nos permite crear una variable de cualquier tipo se va a convertir al tipo de dato que le asignemos
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
            // Una vez creado el builder le asignamos a la cadenaSQL la seccion del builder que queremos acceder

        }
        public string getCadenaSQL()//Este metodo el string que contiene la conexion obtenida
        {
            return cadenaSQL;
        }
    }
}
