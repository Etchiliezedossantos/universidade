using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJECO_P2_2
{
    public partial class F_PROVAF2 : Form
    {
        public F_PROVAF2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prova_F1 forulario = new Prova_F1();    
            forulario.Show();
        }
    }
}
