namespace Proyecto_IA_2
{
    partial class Form2
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
            this.dgSalida = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EarnedCommission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobCounter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalida)).BeginInit();
            this.SuspendLayout();
            // 
            // dgSalida
            // 
            this.dgSalida.AllowUserToAddRows = false;
            this.dgSalida.AllowUserToDeleteRows = false;
            this.dgSalida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSalida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.EarnedCommission,
            this.WorkTime,
            this.JobCounter});
            this.dgSalida.Location = new System.Drawing.Point(3, 3);
            this.dgSalida.Name = "dgSalida";
            this.dgSalida.ReadOnly = true;
            this.dgSalida.Size = new System.Drawing.Size(636, 341);
            this.dgSalida.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            // 
            // EarnedCommission
            // 
            this.EarnedCommission.HeaderText = "Earned Commission";
            this.EarnedCommission.Name = "EarnedCommission";
            // 
            // WorkTime
            // 
            this.WorkTime.HeaderText = "Work Time";
            this.WorkTime.Name = "WorkTime";
            this.WorkTime.ReadOnly = true;
            // 
            // JobCounter
            // 
            this.JobCounter.HeaderText = "Job Counter";
            this.JobCounter.Name = "JobCounter";
            this.JobCounter.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 351);
            this.Controls.Add(this.dgSalida);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.dgSalida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn EarnedCommission;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobCounter;
    }
}