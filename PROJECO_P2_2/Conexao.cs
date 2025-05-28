using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace PROJECO_P2_2
{
    internal class Conexao
    {
        private MySqlConnection conn;

        public Conexao()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SistemaExamesConnectionString"].ConnectionString;
            conn = new MySqlConnection(connectionString);
        }

        public MySqlConnection Abrir()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
            return conn;
        }

        public void Fechar()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }
    }
}
