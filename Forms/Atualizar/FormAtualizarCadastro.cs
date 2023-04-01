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

namespace Projeto_18___Clinica_Maia_Center.Forms
{
    public partial class FormAtualizarCadastro : Form
    {
        public FormAtualizarCadastro()
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
            CRUD.cmd.Parameters.AddWithValue("nome", txtNome.Text.Trim());
            //CRUD.cmd.Parameters.AddWithValue("rg", txtRG.Text.Trim());
            //CRUD.cmd.Parameters.AddWithValue("cpf", txtCPF.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("telefone", txtTelefone.Text.Trim());

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

        private void FormAtualizarCadastro_Load(object sender, EventArgs e)
        {
            CRUD.sql = "SELECT * FROM CLIENTES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            //CRUD.sql = "SELECT * FROM CLIENTES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "' AND Senha = '" + txtSenha.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            DataGridView dgv = dataGridView1;

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;

            txtNome.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);
            //txtCPF.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtDataNasc.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtTelefone.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtEmail.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            txtProfissao.Text = Convert.ToString(dgv.CurrentRow.Cells[5].Value);



            dgv.Visible = false;
        }

        private void btnSalvarCadastro_Click_1(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            //{
            //    MessageBox.Show("Por favor insira o Nome completo", "Dados Obrigatórios",
            //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            //CRUD.sql = "INSERT INTO CLIENTES(nome, datanascimento, telefone, email, profissao) Values(@nome, @datanascimento, @telefone, @email, @profissao);";
            //Executar(CRUD.sql, "Insert");

            //CRUD.sql = "SELECT LAST_INSERT_ID()";

            //CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            //DataTable dt = CRUD.PerformCRUD(CRUD.cmd);


            //DataGridView dgv = dataGridView1;
            //dgv.Visible = true;
            //dgv.DataSource = dt;
            //dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            //string NumeroRegistro = dgv.CurrentCell.Value.ToString();
            //dgv.Visible = false;
            //txtID.Text = NumeroRegistro;

            FormInformacoesComplementares formInformacoesComplementares = new FormInformacoesComplementares();
            formInformacoesComplementares.txtID.Text = txtID.Text;
            formInformacoesComplementares.Show();
        }

        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            FormInformacoesComplementares formInformacoesComplementares = new FormInformacoesComplementares();
            formInformacoesComplementares.txtID.Text = txtID.Text;
            formInformacoesComplementares.Show();
        }
    }
}
