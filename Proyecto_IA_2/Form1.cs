using Proyecto_IA_2.Source;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_IA_2
{

    public partial class Form1 : Form
    {
        private List<Agent> agents;
        private List<RequestedService> requestedServices;
        public Form1()
        {
            InitializeComponent();
        }

        private void loadAgents_Click(object sender, EventArgs e)
        {
            try
            {
                agentsDataGridView.Rows.Clear();
                agentsDataGridView.Refresh();
                agents = Program.LoadAgents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when loading agents");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void mostrarAgents_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Agent agent in agents)
                {
                    string[] agentInfo = { "", "", "" };
                    IEnumerable<string> listOfServices = agent.ServiceList;
                    agentInfo[0] = agent.ID;
                    agentInfo[1] = agent.Name;
                    string serviceListSTR = "";
                    foreach (string service in listOfServices)
                    {
                        serviceListSTR += service + ", ";
                    }
                    agentInfo[2] = serviceListSTR;
                    agentsDataGridView.Rows.Add(agentInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load the agents first");
            }


        }

        private void agentsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadRequestedServices_Click(object sender, EventArgs e)
        {
            try
            {

                requestedServicesDataGridView.Rows.Clear();
                requestedServicesDataGridView.Refresh();
                requestedServices = Program.LoadRequestedServices();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when loading requested services");
            }

        }

        private void ShowRequestedServices_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (RequestedService service in requestedServices)
                {
                    string[] serviceInfo = { "", "", "" };
                    serviceInfo[0] = service.ID;
                    serviceInfo[1] = service.CustomerName;
                    serviceInfo[2] = service.ServiceCode;
                    requestedServicesDataGridView.Rows.Add(serviceInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load the services first");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                GeneticAlgorithm a = new GeneticAlgorithm(agents, requestedServices);
                a.CreateInitialPopulation();
                a.CalculateFitnessGenes();
                for (int i = 0; i < a.GenerationsNumber; i++)
                {
                    a.CreateNextGeneration();
                    a.CalculateFitnessGenes();
                }


                Console.WriteLine(a.BestGenByGeneration());

                Form2 frm = new Form2();
                frm.Show();
                frm.cargarGen(a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load the services and agents first");
            }

            

        }
    }
}
