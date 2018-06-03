using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto_IA_2.Source;

namespace Proyecto_IA_2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agents agentsForm = new Agents();

            this.Hide();
            agentsForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RequestServices requestServicesForm = new RequestServices();

            this.Hide();
            requestServicesForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TODO
        }

    }
}
