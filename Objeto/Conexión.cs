using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Objeto
{
    public class Conexión
    {
        public SqlConnection LeerDatos()
        {
            SqlConnection cn = new SqlConnection
                (ConfigurationManager.ConnectionStrings["Alexis"].ConnectionString);
            if (cn.State == ConnectionState.Open)
            {
                cn.Close();
            }
            else
            {
                cn.Open();
            }
            return cn;
        }
    }
}
