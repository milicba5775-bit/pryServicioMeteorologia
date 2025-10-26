namespace pryServicioMeteorologia
{
    partial class frmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInicio));
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblTemperaturas = new System.Windows.Forms.Label();
            this.tvwUbicaciones = new System.Windows.Forms.TreeView();
            this.lvwTemperaturas = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtpFecha = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(46, 134);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(120, 28);
            this.lblUbicacion.TabIndex = 0;
            this.lblUbicacion.Text = "Ubicaciones";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(49, 57);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(64, 28);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha";
            // 
            // lblTemperaturas
            // 
            this.lblTemperaturas.AutoSize = true;
            this.lblTemperaturas.Location = new System.Drawing.Point(446, 117);
            this.lblTemperaturas.Name = "lblTemperaturas";
            this.lblTemperaturas.Size = new System.Drawing.Size(135, 28);
            this.lblTemperaturas.TabIndex = 2;
            this.lblTemperaturas.Text = "Temperaturas";
            // 
            // tvwUbicaciones
            // 
            this.tvwUbicaciones.Location = new System.Drawing.Point(40, 184);
            this.tvwUbicaciones.Name = "tvwUbicaciones";
            this.tvwUbicaciones.Size = new System.Drawing.Size(304, 401);
            this.tvwUbicaciones.TabIndex = 4;
            // 
            // lvwTemperaturas
            // 
            this.lvwTemperaturas.HideSelection = false;
            this.lvwTemperaturas.Location = new System.Drawing.Point(440, 148);
            this.lvwTemperaturas.Name = "lvwTemperaturas";
            this.lvwTemperaturas.Size = new System.Drawing.Size(531, 458);
            this.lvwTemperaturas.TabIndex = 6;
            this.lvwTemperaturas.UseCompatibleStateImageBehavior = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(993, 26);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(172, 20);
            this.lblEstado.Text = "Provincia: - | Localidad: -";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Checked = true;
            this.dtpFecha.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(130, 57);
            this.dtpFecha.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFecha.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(228, 29);
            this.dtpFecha.TabIndex = 8;
            this.dtpFecha.Value = new System.DateTime(2025, 10, 26, 18, 58, 25, 877);
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(993, 666);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvwTemperaturas);
            this.Controls.Add(this.tvwUbicaciones);
            this.Controls.Add(this.lblTemperaturas);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblUbicacion);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmInicio";
            this.Text = "Meteorología";
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblTemperaturas;
        private System.Windows.Forms.TreeView tvwUbicaciones;
        private System.Windows.Forms.ListView lvwTemperaturas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFecha;
    }
}