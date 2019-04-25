namespace CDSTabIndexPackage.CDSTabIndex
{
    partial class frmTabIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTabIndex));
            this.lstTab = new System.Windows.Forms.ListBox();
            this.btnAcima = new System.Windows.Forms.Button();
            this.btnAbaixo = new System.Windows.Forms.Button();
            this.btnAplica = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lstTab
            // 
            this.lstTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTab.FormattingEnabled = true;
            this.lstTab.Location = new System.Drawing.Point(12, 12);
            this.lstTab.Name = "lstTab";
            this.lstTab.Size = new System.Drawing.Size(258, 329);
            this.lstTab.TabIndex = 0;
            this.lstTab.SelectedIndexChanged += new System.EventHandler(this.lstTab_SelectedIndexChanged);
            // 
            // btnAcima
            // 
            this.btnAcima.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAcima.Location = new System.Drawing.Point(276, 11);
            this.btnAcima.Name = "btnAcima";
            this.btnAcima.Size = new System.Drawing.Size(62, 24);
            this.btnAcima.TabIndex = 1;
            this.btnAcima.Text = "Up (-)";
            this.btnAcima.UseVisualStyleBackColor = true;
            this.btnAcima.Click += new System.EventHandler(this.btnAcima_Click);
            // 
            // btnAbaixo
            // 
            this.btnAbaixo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAbaixo.Location = new System.Drawing.Point(276, 41);
            this.btnAbaixo.Name = "btnAbaixo";
            this.btnAbaixo.Size = new System.Drawing.Size(62, 24);
            this.btnAbaixo.TabIndex = 2;
            this.btnAbaixo.Text = "Down (+)";
            this.btnAbaixo.UseVisualStyleBackColor = true;
            this.btnAbaixo.Click += new System.EventHandler(this.btnAbaixo_Click);
            // 
            // btnAplica
            // 
            this.btnAplica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplica.Location = new System.Drawing.Point(276, 292);
            this.btnAplica.Name = "btnAplica";
            this.btnAplica.Size = new System.Drawing.Size(62, 23);
            this.btnAplica.TabIndex = 3;
            this.btnAplica.Text = "Apply";
            this.btnAplica.UseVisualStyleBackColor = true;
            this.btnAplica.Click += new System.EventHandler(this.btnAplica_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(276, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(62, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancel";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "© 2019 Carlos dos Santos.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 367);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(97, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.carloscds.net";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(141, 367);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(129, 13);
            this.linkLabel2.TabIndex = 8;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "www.cds-software.com.br";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmTabIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 391);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplica);
            this.Controls.Add(this.btnAbaixo);
            this.Controls.Add(this.btnAcima);
            this.Controls.Add(this.lstTab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTabIndex";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TabIndex Designer";
            this.Load += new System.EventHandler(this.frmTabIndex_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmTabIndex_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ListBox lstTab;
        private System.Windows.Forms.Button btnAcima;
        private System.Windows.Forms.Button btnAbaixo;
        private System.Windows.Forms.Button btnAplica;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}