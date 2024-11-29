namespace RPG
{
    partial class Configuracoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracoes));
            this.lblConfig = new System.Windows.Forms.Label();
            this.btnOff = new System.Windows.Forms.Button();
            this.lblVolumeGeral = new System.Windows.Forms.Label();
            this.btnOn = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblConfig
            // 
            this.lblConfig.BackColor = System.Drawing.Color.Transparent;
            this.lblConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfig.ForeColor = System.Drawing.Color.White;
            this.lblConfig.Location = new System.Drawing.Point(3, 18);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Size = new System.Drawing.Size(393, 69);
            this.lblConfig.TabIndex = 6;
            this.lblConfig.Text = "Configurações";
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.Color.White;
            this.btnOff.Image = ((System.Drawing.Image)(resources.GetObject("btnOff.Image")));
            this.btnOff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOff.Location = new System.Drawing.Point(193, 10);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(40, 40);
            this.btnOff.TabIndex = 5;
            this.btnOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.Click += new System.EventHandler(this.BtnOff_Click);
            // 
            // lblVolumeGeral
            // 
            this.lblVolumeGeral.AutoSize = true;
            this.lblVolumeGeral.BackColor = System.Drawing.Color.Transparent;
            this.lblVolumeGeral.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolumeGeral.ForeColor = System.Drawing.Color.White;
            this.lblVolumeGeral.Location = new System.Drawing.Point(22, 20);
            this.lblVolumeGeral.Name = "lblVolumeGeral";
            this.lblVolumeGeral.Size = new System.Drawing.Size(119, 20);
            this.lblVolumeGeral.TabIndex = 4;
            this.lblVolumeGeral.Text = "Volume geral:";
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.Color.White;
            this.btnOn.Image = ((System.Drawing.Image)(resources.GetObject("btnOn.Image")));
            this.btnOn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOn.Location = new System.Drawing.Point(147, 10);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(40, 40);
            this.btnOn.TabIndex = 9;
            this.btnOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOn.UseVisualStyleBackColor = false;
            this.btnOn.Click += new System.EventHandler(this.BtnOn_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.White;
            this.btnVoltar.ForeColor = System.Drawing.Color.Black;
            this.btnVoltar.Location = new System.Drawing.Point(239, 13);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(134, 35);
            this.btnVoltar.TabIndex = 33;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblConfig);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 109);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblVolumeGeral);
            this.panel2.Controls.Add(this.btnOff);
            this.panel2.Controls.Add(this.btnVoltar);
            this.panel2.Controls.Add(this.btnOn);
            this.panel2.Location = new System.Drawing.Point(13, 129);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 66);
            this.panel2.TabIndex = 35;
            // 
            // Configuracoes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(428, 211);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Configuracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Label lblVolumeGeral;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}