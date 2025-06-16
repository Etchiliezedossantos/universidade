using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PROJECO_P2_2
{
    public partial class F_datas : Form
    {
        public F_datas()
        {
            InitializeComponent();
        }

        private void F_datas_Load(object sender, EventArgs e)
        {
            string connStr = "Server=127.0.0.1;Port=3306;Database=sistema_exames;Uid=root;Pwd=;";
            string sql = "SELECT Id, DataExame, Periodo FROM exames";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);

                    // Formata a data se quiser mostrar como dd/MM/yyyy
                    dataGridView1.Columns["DataExame"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
        }

        
    }
}
