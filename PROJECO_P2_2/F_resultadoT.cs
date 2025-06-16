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
    public partial class F_resultadoT : Form
    {
        public F_resultadoT()
        {
            InitializeComponent();
        }

        private void F_resultadoT_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=127.0.0.1;Port=3306;Database=sistema_exames;Uid=root;Pwd=;";
            string query = "SELECT NomeCompleto, NumeroBI, NotaFinal nota FROM candidatos WHERE estado = 'finalizado';";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            }
        }
    }
}
