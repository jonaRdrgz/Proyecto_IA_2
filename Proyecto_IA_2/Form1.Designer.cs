namespace Proyecto_IA_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.agentsDataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loadAgents = new System.Windows.Forms.Button();
            this.mostrarAgents = new System.Windows.Forms.Button();
            this.ShowRequestedServices = new System.Windows.Forms.Button();
            this.LoadRequestedServices = new System.Windows.Forms.Button();
            this.requestedServicesDataGridView = new System.Windows.Forms.DataGridView();
            this.idService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.agentsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestedServicesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // agentsDataGridView
            // 
            this.agentsDataGridView.AllowUserToAddRows = false;
            this.agentsDataGridView.AllowUserToDeleteRows = false;
            this.agentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.agentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.agentName,
            this.agentService});
            this.agentsDataGridView.Location = new System.Drawing.Point(12, 50);
            this.agentsDataGridView.Name = "agentsDataGridView";
            this.agentsDataGridView.ReadOnly = true;
            this.agentsDataGridView.Size = new System.Drawing.Size(399, 348);
            this.agentsDataGridView.TabIndex = 0;
            this.agentsDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.agentsDataGridView_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 25;
            // 
            // agentName
            // 
            this.agentName.HeaderText = "Name of agent";
            this.agentName.Name = "agentName";
            this.agentName.ReadOnly = true;
            this.agentName.Width = 155;
            // 
            // agentService
            // 
            this.agentService.HeaderText = "Service of agent";
            this.agentService.Name = "agentService";
            this.agentService.ReadOnly = true;
            this.agentService.Width = 175;
            // 
            // loadAgents
            // 
            this.loadAgents.Location = new System.Drawing.Point(12, 21);
            this.loadAgents.Name = "loadAgents";
            this.loadAgents.Size = new System.Drawing.Size(95, 23);
            this.loadAgents.TabIndex = 2;
            this.loadAgents.Text = "Load agents";
            this.loadAgents.UseVisualStyleBackColor = true;
            this.loadAgents.Click += new System.EventHandler(this.loadAgents_Click);
            // 
            // mostrarAgents
            // 
            this.mostrarAgents.Location = new System.Drawing.Point(113, 21);
            this.mostrarAgents.Name = "mostrarAgents";
            this.mostrarAgents.Size = new System.Drawing.Size(75, 23);
            this.mostrarAgents.TabIndex = 3;
            this.mostrarAgents.Text = "Show";
            this.mostrarAgents.UseVisualStyleBackColor = true;
            this.mostrarAgents.Click += new System.EventHandler(this.mostrarAgents_Click);
            // 
            // ShowRequestedServices
            // 
            this.ShowRequestedServices.Location = new System.Drawing.Point(570, 21);
            this.ShowRequestedServices.Name = "ShowRequestedServices";
            this.ShowRequestedServices.Size = new System.Drawing.Size(75, 23);
            this.ShowRequestedServices.TabIndex = 6;
            this.ShowRequestedServices.Text = "Show";
            this.ShowRequestedServices.UseVisualStyleBackColor = true;
            this.ShowRequestedServices.Click += new System.EventHandler(this.ShowRequestedServices_Click);
            // 
            // LoadRequestedServices
            // 
            this.LoadRequestedServices.Location = new System.Drawing.Point(432, 21);
            this.LoadRequestedServices.Name = "LoadRequestedServices";
            this.LoadRequestedServices.Size = new System.Drawing.Size(132, 23);
            this.LoadRequestedServices.TabIndex = 5;
            this.LoadRequestedServices.Text = "Load requested services";
            this.LoadRequestedServices.UseVisualStyleBackColor = true;
            this.LoadRequestedServices.Click += new System.EventHandler(this.LoadRequestedServices_Click);
            // 
            // requestedServicesDataGridView
            // 
            this.requestedServicesDataGridView.AllowUserToAddRows = false;
            this.requestedServicesDataGridView.AllowUserToDeleteRows = false;
            this.requestedServicesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestedServicesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idService,
            this.customerName,
            this.serviceCode});
            this.requestedServicesDataGridView.Location = new System.Drawing.Point(432, 50);
            this.requestedServicesDataGridView.Name = "requestedServicesDataGridView";
            this.requestedServicesDataGridView.ReadOnly = true;
            this.requestedServicesDataGridView.Size = new System.Drawing.Size(399, 348);
            this.requestedServicesDataGridView.TabIndex = 4;
            // 
            // idService
            // 
            this.idService.HeaderText = "ID";
            this.idService.Name = "idService";
            this.idService.ReadOnly = true;
            this.idService.Width = 25;
            // 
            // customerName
            // 
            this.customerName.HeaderText = "Customer Name";
            this.customerName.Name = "customerName";
            this.customerName.ReadOnly = true;
            this.customerName.Width = 155;
            // 
            // serviceCode
            // 
            this.serviceCode.HeaderText = "Service Code";
            this.serviceCode.Name = "serviceCode";
            this.serviceCode.ReadOnly = true;
            this.serviceCode.Width = 175;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(756, 404);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Calculate";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 435);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.ShowRequestedServices);
            this.Controls.Add(this.LoadRequestedServices);
            this.Controls.Add(this.requestedServicesDataGridView);
            this.Controls.Add(this.mostrarAgents);
            this.Controls.Add(this.loadAgents);
            this.Controls.Add(this.agentsDataGridView);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.agentsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestedServicesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView agentsDataGridView;
        private System.Windows.Forms.Button loadAgents;
        private System.Windows.Forms.Button mostrarAgents;
        private System.Windows.Forms.Button ShowRequestedServices;
        private System.Windows.Forms.Button LoadRequestedServices;
        private System.Windows.Forms.DataGridView requestedServicesDataGridView;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentService;
        private System.Windows.Forms.DataGridViewTextBoxColumn idService;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceCode;
    }
}