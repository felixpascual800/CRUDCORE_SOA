using System.Data.SqlClient;

namespace CRUDCORE.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion() {


            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public static object Usuarios { get; internal set; }

        public string getCadenaSQL() {
            return cadenaSQL;
        }



    }
}
