using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_18___Clinica_Maia_Center
{
    public partial class FormPaginaInicial : Form
    {
        private Form activeForm;

        public FormPaginaInicial()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Clicar e arrastar tela pela barra de titulo
        private void panelFormTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Clicar e arrastar tela pelo logo
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Botões de controle. Minimizar, Maximizar e Sair.

        // Minimizar
        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // Maximizar
        public void Maximizar()
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Maximizar();
        }
        // Sair
        private void label1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        // Mensagem de boas vindas.
        private void FormPaginaInicial_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = "Bem vindo(a) de volta " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtNomeLogin.Text.ToLower());
        }

        // Função para abrir a página dentro do painel central.
        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormCentral.Controls.Add(childForm);
            panelFormCentral.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitulo.Text = childForm.Text;
        }

        // Menu Lateral
        private void btnPaginaInicial_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormInicio());
            // Altera texto do título do sistema.
            //lblTitulo.Text = "Página Inicial";
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormClientes());
            // Altera texto do título do sistema.
            //lblTitulo.Text = "Clientes";
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormDashboard());
            // Altera texto do título do sistema.
            //lblTitulo.Text = "Dashboard";
        }

        private void btnVisualizarLogs_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormVisualizarLogs());
            // Altera texto do título do sistema.
            //lblTitulo.Text = "Logs";
        }

        private void btnAgenda_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormAgenda());
            // Altera texto do título do sistema.
            //lblTitulo.Text = "Agenda";
        }
    }
}
