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
            CRUD.cmd.Parameters.AddWithValue("lesao_cranial", cboxLesaoCranial.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("tempo_cranial", txtTempoCranial.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("espec_cranial", txtEspecCranial.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("lesao_coluna", cboxLesaoColuna.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("tempo_coluna", txtTempoColuna.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("espec_coluna", txtEspecColuna.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("lesao_coronarias", cboxLesaoCoronarias.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("tempo_coronarias", txtTempoCoronaria.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("espec_coronarias", txtEspecCoronarias.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("cirurgias", cboxCirurgias.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("tempo_cirurgias", txtTempoCirurgias.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("espec_cirurgias", txtEspecCirurgias.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("diabetes", cboxDiabetes.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("tempo_diabetes", txtTempoDiabetes.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("queixa_principal", txtQueixaPrincipal.Text.Trim());

        }
        // INSERT dos dados. Cadastro Cliente.
        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            CRUD.sql = "UPDATE INFOCOMPLEMENTARES SET PRESSAO = @Pressao, OBSPRESSAO = @ObsPressao, MEDICACAO = @Medicacao, LESAO_CRANIAL = @lesao_cranial, TEMPO_CRANIAL = @tempo_cranial, ESPEC_CRANIAL = @espec_cranial, LESAO_COLUNA = @lesao_coluna," +
                " TEMPO_COLUNA = @tempo_coluna, ESPEC_COLUNA = @espec_coluna, LESAO_CORONARIAS = @lesao_coronarias, TEMPO_CORONARIAS = @tempo_coronarias, ESPEC_CORONARIAS = @espec_coronarias, CIRURGIAS = @cirurgias, TEMPO_CIRURGIAS = @tempo_cirurgias," +
                " ESPEC_CIRURGIAS = @espec_cirurgias, DIABETES = @diabetes, TEMPO_DIABETES = @tempo_diabetes, QUEIXA_PRINCIPAL = @queixa_principal WHERE CODCLIENTE = " + txtID.Text + ";";
            Executar(CRUD.sql, "Update");

            FormAtualizarAvaliacaoReflexopodal formAtualizarAvaliacaoReflexopodal = new FormAtualizarAvaliacaoReflexopodal();
            formAtualizarAvaliacaoReflexopodal.txtID.Text = txtID.Text;
            formAtualizarAvaliacaoReflexopodal.Show();

            this.Close();
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
            CRUD.sql = "SELECT * FROM INFOCOMPLEMENTARES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            //CRUD.sql = "SELECT * FROM CLIENTES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "' AND Senha = '" + txtSenha.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            DataGridView dgv = dataGridView1;

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;

            cboxPressao.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtObsPressao.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtMedicacao.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            cboxLesaoCranial.Text = Convert.ToString(dgv.CurrentRow.Cells[5].Value);
            txtTempoCranial.Text = Convert.ToString(dgv.CurrentRow.Cells[6].Value);
            txtEspecCranial.Text = Convert.ToString(dgv.CurrentRow.Cells[7].Value);
            cboxLesaoColuna.Text = Convert.ToString(dgv.CurrentRow.Cells[8].Value);
            txtTempoColuna.Text = Convert.ToString(dgv.CurrentRow.Cells[9].Value);
            txtEspecColuna.Text = Convert.ToString(dgv.CurrentRow.Cells[10].Value);
            cboxLesaoCoronarias.Text = Convert.ToString(dgv.CurrentRow.Cells[11].Value);
            txtTempoCoronaria.Text = Convert.ToString(dgv.CurrentRow.Cells[12].Value);
            txtEspecCoronarias.Text = Convert.ToString(dgv.CurrentRow.Cells[13].Value);
            cboxCirurgias.Text = Convert.ToString(dgv.CurrentRow.Cells[14].Value);
            txtTempoCirurgias.Text = Convert.ToString(dgv.CurrentRow.Cells[15].Value);
            txtEspecCirurgias.Text = Convert.ToString(dgv.CurrentRow.Cells[16].Value);
            cboxDiabetes.Text = Convert.ToString(dgv.CurrentRow.Cells[17].Value);
            txtTempoDiabetes.Text = Convert.ToString(dgv.CurrentRow.Cells[18].Value);
            txtQueixaPrincipal.Text = Convert.ToString(dgv.CurrentRow.Cells[19].Value);

            dgv.Visible = false;
        }
    }
}
