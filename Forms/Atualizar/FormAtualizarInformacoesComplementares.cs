using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_18___Clinica_Maia_Center.Forms.Atualizar
{
    public partial class FormAtualizarInformacoesComplementares : Form
    {
        public FormAtualizarInformacoesComplementares()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Comando SQL para Executar CRUD.
        private void Executar(string mySQL, string param)
        {
            CRUD.cmd = new MySqlCommand(mySQL, CRUD.con);
            AddParametros(param);
            CRUD.PerformCRUD(CRUD.cmd);
        }
        // Definição dos parametros para comandos CRUD.
        private void AddParametros(string str)
        {
            //Identificação Autor
            CRUD.cmd.Parameters.AddWithValue("ID", txtID.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("Pressao", cboxPressao.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("ObsPressao", txtObsPressao.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("Medicacao", txtMedicacao.Text.Trim());

        }
        // INSERT dos dados. Cadastro Cliente.
        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            CRUD.sql = "INSERT INTO INFOCOMPLEMENTARES(CODCLIENTE, PRESSAO, OBSPRESSAO, MEDICACAO) Values(@ID, @Pressao, @ObsPressao, @Medicacao);";
            Executar(CRUD.sql, "Insert");

            FormAvaliacaoReflexopodal formAvaliacaoReflexopodal = new FormAvaliacaoReflexopodal();
            formAvaliacaoReflexopodal.txtID.Text = txtID.Text;
            formAvaliacaoReflexopodal.Show();
        }

        private void panelFormTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelCadastro_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormAtualizarInformacoesComplementares_Load(object sender, EventArgs e)
        {
            //CRUD.sql = "SELECT * FROM INFOCOMPLEMENTARES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            ////CRUD.sql = "SELECT * FROM CLIENTES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "' AND Senha = '" + txtSenha.Text.Trim() + "'";
            //CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            //DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            //DataGridView dgv = dataGridView1;

            //dgv.Visible = true;
            //dgv.AutoGenerateColumns = true;
            //dgv.DataSource = dt;

            //cboxPressao.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            //txtObsPressao.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            //txtMedicacao.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            ////txtTelefone.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);



            //dgv.Visible = false;
        }
    }
}
