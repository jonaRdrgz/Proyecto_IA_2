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
    public partial class Agents : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView agentsDataGridView = new DataGridView();
        private Button LoadButton = new Button();
        private Button ShowButton = new Button();
        private IEnumerable<Agent> agents;

        public Agents()
        {
            this.Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            
        }

     
  
        private void LoadButton_Click(object sender, EventArgs e)
        {

            LoadAgentsFromXML();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            showTableAgents();
        }

        private void SetupLayout()
        {
           this.Size = new Size(600, 500);

            LoadButton.Text = "Load Agents";
            LoadButton.Location = new Point(10, 10);
            LoadButton.Click += new EventHandler(LoadButton_Click);

            ShowButton.Text = "Show Agents";
            ShowButton.Location = new Point(100, 10);
            ShowButton.Click += new EventHandler(ShowButton_Click);

            buttonPanel.Controls.Add(LoadButton);
            buttonPanel.Controls.Add(ShowButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(agentsDataGridView);

            agentsDataGridView.ColumnCount = 3;            // Rows

            agentsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            agentsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            agentsDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(agentsDataGridView.Font, FontStyle.Bold);

            agentsDataGridView.Name = "agentsDataGridView";
            agentsDataGridView.Location = new Point(8, 8);
            agentsDataGridView.Size = new Size(600, 500);
            agentsDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            agentsDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            agentsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            agentsDataGridView.GridColor = Color.Black;
            agentsDataGridView.RowHeadersVisible = false;

            //           Headers
            agentsDataGridView.Columns[0].Name = "ID";
            agentsDataGridView.Columns[0].MinimumWidth = 20;
            agentsDataGridView.Columns[1].Name = "Name of Agent";
            agentsDataGridView.Columns[1].MinimumWidth = 120;
            agentsDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            agentsDataGridView.Columns[2].Name = "Services of the Agent";
            agentsDataGridView.Columns[2].MinimumWidth = 120;
            agentsDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            agentsDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            agentsDataGridView.MultiSelect = false;
            agentsDataGridView.Dock = DockStyle.Fill;
            agentsDataGridView.ScrollBars = ScrollBars.Vertical;
        }

        private void LoadAgentsFromXML()
        {
            agentsDataGridView.Rows.Clear();
            agentsDataGridView.Refresh();
            agents = Program.LoadAgents();

        }

        private void showTableAgents() {
            foreach (Agent agent in agents)
            {
                string[] agentInfo = {"","", "" };
                IEnumerable<string> listOfServices = agent.ServiceList;
                agentInfo[0] = agent.ID;
                agentInfo[1] = agent.Name;
                string serviceListSTR = "";
                foreach (string service in listOfServices)
                {
                    serviceListSTR += service + ", " ;
                }
                agentInfo[2] = serviceListSTR;
                agentsDataGridView.Rows.Add(agentInfo);
            }
        }

    }
}

