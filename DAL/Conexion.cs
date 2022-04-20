using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        private static SqlConnection conexion = new SqlConnection(@"Data Source=DESKTOP-EMKELS3;Initial Catalog=Turnos;User ID=sa;Password=1234");

        public static SqlConnection AbrirConexion()
        {
            if (conexion.State == ConnectionState.Closed)           
                conexion.Open();
            return conexion;            
        }

        public static SqlConnection CerrarConexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Close();
            return conexion;
        }
    }
}
