using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aula1_Avancado.Telas;

namespace Aula1_Avancado.Telas
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_funcionario obj = new frm_funcionario();
            obj.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_cliente1 obj = new frm_cliente1();
            obj.Show();

        }
    }
}
