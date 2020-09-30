using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Capa.DAL
{
    public class DBConnection
    {
        private static string cn = "server=(localdb)\\Servidor;database=BDGEmpresa1TE;uid=sa;pwd=sql";

        public SqlConnection getConn()
        {
            return new SqlConnection(cn);
        }

        public SqlCommand getCmd(string sql,SqlConnection con)
        {
            return new SqlCommand(sql, con as SqlConnection);
        }
    }
}
