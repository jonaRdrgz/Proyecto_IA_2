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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        internal void cargarGen(GeneticAlgorithm a)
        {
            foreach (Agent r in a.BestGenByGeneration().AgentList.AsEnumerable())
            {
                dgSalida.Rows.Add(r.ID,r.Name,r.EarnedCommission,r.WorkTime,r.JobCounter);
                Console.WriteLine(r);
            }
        }
    }
}
