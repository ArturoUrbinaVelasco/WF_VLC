namespace WF_VLC
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tsbtn_play = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_stop = new System.Windows.Forms.ToolStripButton();
            this.tsbtn_find_capturadora = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ts_cmbDevices = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsbtn_play
            // 
            this.tsbtn_play.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_play.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_play.Image")));
            this.tsbtn_play.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_play.Name = "tsbtn_play";
            this.tsbtn_play.Size = new System.Drawing.Size(23, 22);
            this.tsbtn_play.Text = "Play";
            this.tsbtn_play.Click += new System.EventHandler(this.tsbtn_play_Click);
            // 
            // tsbtn_stop
            // 
            this.tsbtn_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_stop.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_stop.Image")));
            this.tsbtn_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_stop.Name = "tsbtn_stop";
            this.tsbtn_stop.Size = new System.Drawing.Size(23, 22);
            this.tsbtn_stop.Text = "Stop";
            this.tsbtn_stop.Click += new System.EventHandler(this.tsbtn_stop_Click);
            // 
            // tsbtn_find_capturadora
            // 
            this.tsbtn_find_capturadora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtn_find_capturadora.Image = ((System.Drawing.Image)(resources.GetObject("tsbtn_find_capturadora.Image")));
            this.tsbtn_find_capturadora.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtn_find_capturadora.Name = "tsbtn_find_capturadora";
            this.tsbtn_find_capturadora.Size = new System.Drawing.Size(23, 22);
            this.tsbtn_find_capturadora.Text = "find_capturadora";
            this.tsbtn_find_capturadora.Click += new System.EventHandler(this.tsbtn_find_capturadora_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtn_play,
            this.tsbtn_stop,
            this.tsbtn_find_capturadora,
            this.ts_cmbDevices});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ts_cmbDevices
            // 
            this.ts_cmbDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ts_cmbDevices.Name = "ts_cmbDevices";
            this.ts_cmbDevices.Size = new System.Drawing.Size(121, 25);
            this.ts_cmbDevices.Sorted = true;
            this.ts_cmbDevices.DropDownClosed += new System.EventHandler(this.ts_cmbDevices_DropDownClosed);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reproductor de Video";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tsbtn_play;
        private System.Windows.Forms.ToolStripButton tsbtn_stop;
        private System.Windows.Forms.ToolStripButton tsbtn_find_capturadora;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox ts_cmbDevices;
    }
}

