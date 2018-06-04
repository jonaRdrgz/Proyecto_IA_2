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
            Gen gen = a.BestGenByGeneration();
            Dictionary<string, List<string>> dictionary = a.GetDictionary(gen);
            foreach (Agent r in gen.AgentList.AsEnumerable())
            {
                string nl = Environment.NewLine;
                string RS = "";
                foreach(string str in dictionary[r.ID].AsEnumerable())
                {
                    RequestedService rs;
                    Service s;
                    rs = (from t in a.RequestedServiceList
                          where t.ID == str
                          select t).FirstOrDefault();
                    s = (from ss in XMLData.GetInstance().XMLServices
                         where ss.Code == rs.ServiceCode select ss).FirstOrDefault();

                    RS += "Order ID: " + rs.ID + ", Customer: " + rs.CustomerName +
                           ", Service: " + rs.ServiceCode + ", Time: " + s.Time + ", Commission: " + s.Commission + nl;
                }



                dgSalida.Rows.Add(r.ID,r.Name,r.EarnedCommission,r.WorkTime, RS);
                dgSalida.Rows[dgSalida.Rows.Count - 1].Height = dictionary[r.ID].Count * 30;
                Console.WriteLine(r);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
