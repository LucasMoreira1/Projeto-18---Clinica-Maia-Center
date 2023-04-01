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
    public partial class FormInformacoesComplementares : Form
    {
        public FormInformacoesComplementares()
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
            CRUD.sql = "INSERT INTO INFOCOMPLEMENTARES(CODCLIENTE, PRESSAO, OBSPRESSAO, MEDICACAO, LESAO_CRANIAL, TEMPO_CRANIAL, ESPEC_CRANIAL, LESAO_COLUNA, TEMPO_COLUNA, ESPEC_COLUNA, LESAO_CORONARIAS, TEMPO_CORONARIAS, ESPEC_CORONARIAS, CIRURGIAS, TEMPO_CIRURGIAS, ESPEC_CIRURGIAS, DIABETES, TEMPO_DIABETES, QUEIXA_PRINCIPAL) " +
                "Values(@ID, @Pressao, @ObsPressao, @Medicacao, @lesao_cranial, @tempo_cranial, @espec_cranial, @lesao_coluna, @tempo_coluna, @espec_coluna, @lesao_coronarias, @tempo_coronarias, @espec_coronarias, @cirurgias, @tempo_cirurgias, @espec_cirurgias, @diabetes, @tempo_diabetes, @queixa_principal);";
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

        private void FormInformacoesComplementares_Load(object sender, EventArgs e)
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
