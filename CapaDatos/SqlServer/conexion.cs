using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public abstract class conexion
    {
        private readonly String conexionString;
        public conexion()
        {
            conexionString = "server=DESKTOP-NS0Q4D2;database=AsistenteVirtual;integrated security=true";
        }
        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(conexionString);
        }
    }
}
