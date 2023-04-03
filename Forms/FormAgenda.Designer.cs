namespace Projeto_18___Clinica_Maia_Center.Forms
{
    partial class FormAgenda
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
            this.GoogleAgenda = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.GoogleAgenda)).BeginInit();
            this.SuspendLayout();
            // 
            // GoogleAgenda
            // 
            this.GoogleAgenda.AllowExternalDrop = true;
            this.GoogleAgenda.CreationProperties = null;
            this.GoogleAgenda.DefaultBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(108)))), ((int)(((byte)(104)))));
            this.GoogleAgenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GoogleAgenda.Location = new System.Drawing.Point(0, 0);
            this.GoogleAgenda.Name = "GoogleAgenda";
            this.GoogleAgenda.Size = new System.Drawing.Size(800, 450);
            this.GoogleAgenda.Source = new System.Uri("http://calendar.google.com/", System.UriKind.Absolute);
            this.GoogleAgenda.TabIndex = 0;
            this.GoogleAgenda.ZoomFactor = 1D;
            // 
            // FormAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(108)))), ((int)(((byte)(104)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GoogleAgenda);
            this.Name = "FormAgenda";
            this.Text = "Agenda";
            ((System.ComponentModel.ISupportInitialize)(this.GoogleAgenda)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 GoogleAgenda;
    }
}