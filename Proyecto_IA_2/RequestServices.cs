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
    public partial class RequestServices : Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView requestedServicesDataGridView = new DataGridView();
        private Button LoadButton = new Button();
        private Button ShowButton = new Button();
        private IEnumerable<RequestedService> requestedServices;

        public RequestServices()
        {
            this.Load += new EventHandler(RequestServices_Load);
        }

        private void RequestServices_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();

        }



        private void LoadButton_Click(object sender, EventArgs e)
        {

            LoadRequestedServicesFromXML();
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            showTableRequestedServices();
        }

        private void SetupLayout()
        {
            this.Size = new Size(600, 500);

            LoadButton.Text = "Load Requested Services";
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
            this.Controls.Add(requestedServicesDataGridView);

            requestedServicesDataGridView.ColumnCount = 3;            // Rows

            requestedServicesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            requestedServicesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            requestedServicesDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(requestedServicesDataGridView.Font, FontStyle.Bold);

            requestedServicesDataGridView.Name = "requestedServicesDataGridView";
            requestedServicesDataGridView.Location = new Point(100, 100);
            requestedServicesDataGridView.Size = new Size(600, 500);
            requestedServicesDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            requestedServicesDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            requestedServicesDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            requestedServicesDataGridView.GridColor = Color.Black;
            requestedServicesDataGridView.RowHeadersVisible = false;

            //           Headers
            requestedServicesDataGridView.Columns[0].Name = "ID";
            requestedServicesDataGridView.Columns[0].MinimumWidth = 20;
            requestedServicesDataGridView.Columns[1].Name = "Customer Name";
            requestedServicesDataGridView.Columns[1].MinimumWidth = 120;
            requestedServicesDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            requestedServicesDataGridView.Columns[2].Name = "Services Code";
            requestedServicesDataGridView.Columns[2].MinimumWidth = 120;
            requestedServicesDataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            requestedServicesDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            requestedServicesDataGridView.MultiSelect = false;
            requestedServicesDataGridView.Dock = DockStyle.Fill;
            requestedServicesDataGridView.ScrollBars = ScrollBars.Vertical;
            requestedServicesDataGridView.Visible = false;
        }

        private void LoadRequestedServicesFromXML()
        {
            requestedServicesDataGridView.Rows.Clear();
            requestedServicesDataGridView.Refresh();
            requestedServicesDataGridView.Visible = false;
            requestedServices = Program.LoadRequestedServices();

        }

        private void showTableRequestedServices()
        {
            foreach (RequestedService service in requestedServices)
            {
                string[] serviceInfo = { "", "", "" };
                serviceInfo[0] = service.ID;
                serviceInfo[1] = service.CustomerName;
                serviceInfo[2] = service.ServiceCode;
                requestedServicesDataGridView.Rows.Add(serviceInfo);
            }
            requestedServicesDataGridView.Visible = true;
        }

    }

}
