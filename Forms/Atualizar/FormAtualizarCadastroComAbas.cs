using Google.Apis.Calendar.v3.Data;
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
    public partial class FormAtualizarCadastroComAbas : Form
    {
        public FormAtualizarCadastroComAbas()
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
            CRUD.cmd.Parameters.AddWithValue("datanascimento", Convert.ToDateTime(txtDataNasc.Text.Trim()));
            CRUD.cmd.Parameters.AddWithValue("telefone", txtTelefone.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("email", txtEmail.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("profissao", txtProfissao.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("ocupacao", txtOcupacao.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("cpf", txtCPF.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("estado_civil", txtEstadoCivil.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("filhos", txtFilhos.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("indicacao", txtIndicacao.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("religiao", txtReligiao.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("cep", txtCEP.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("logradouro", txtLogradouro.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("numero", txtNumero.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("complemento", txtComplemento.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("bairro", txtBairro.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("cidade", txtCidade.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("estado", txtEstado.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("cod_prod", txtCodProduto.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("nome_prod", txtNomeProduto.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("valor_prod", txtValorProduto.Text.Trim());

            // AVAL REFLEXOPODAL
            CRUD.cmd.Parameters.AddWithValue("CODCLIENTE", txtID.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("TERAPEUTA", txtTerapeuta.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("QUEIXACLIENTE", txtQueixaCliente.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("OBSADICIONAIS", txtObsAdicionais.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("NERVOSO", txtNervoso.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("GLAUDULAR", txtGlandular.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("LINFATICO", txtLinfatico.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("CIRULATORIO", txtCirculatorio.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("CARDIACO", txtCardiaco.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("RESPIRATORIO", txtRespiratorio.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("DIGESTIVO", txtDigestorio.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("URINARIO", txtUrinario.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("REPRODUTOR", txtReprodutor.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("ESQUELETICO", txtEsqueletico.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("MUSCULAR", txtMuscular.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("PRIORIDADES", txtPrioridades.Text.Trim());

            // INFO COMPLEMENTARES
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
            txtDataNasc.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtTelefone.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtEmail.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            txtProfissao.Text = Convert.ToString(dgv.CurrentRow.Cells[5].Value);
            txtCPF.Text = Convert.ToString(dgv.CurrentRow.Cells[6].Value);

            CRUD.sql = "SELECT * FROM ADICIONAIS_CADASTRO WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt2 = CRUD.PerformCRUD(CRUD.cmd);

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt2;

            txtOcupacao.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtEstadoCivil.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtFilhos.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            txtIndicacao.Text = Convert.ToString(dgv.CurrentRow.Cells[5].Value);
            txtReligiao.Text = Convert.ToString(dgv.CurrentRow.Cells[6].Value);
            txtCEP.Text = Convert.ToString(dgv.CurrentRow.Cells[7].Value);
            txtLogradouro.Text = Convert.ToString(dgv.CurrentRow.Cells[8].Value);
            txtNumero.Text = Convert.ToString(dgv.CurrentRow.Cells[9].Value);
            txtComplemento.Text = Convert.ToString(dgv.CurrentRow.Cells[10].Value);
            txtBairro.Text = Convert.ToString(dgv.CurrentRow.Cells[11].Value);
            txtCidade.Text = Convert.ToString(dgv.CurrentRow.Cells[12].Value);
            txtEstado.Text = Convert.ToString(dgv.CurrentRow.Cells[13].Value);


            CRUD.sql = "SELECT * FROM COMPRAS WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt3 = CRUD.PerformCRUD(CRUD.cmd);

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt3;

            txtCodProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtNomeProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtValorProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);


            dgv.Visible = false;
        }

        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                MessageBox.Show("Por favor insira o Nome completo", "Dados Obrigatórios",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "UPDATE CLIENTES SET nome = @nome, datanascimento = @datanascimento, telefone = @telefone, email = @email, profissao = @profissao, cpf = @cpf WHERE CODCLIENTE = " + txtID.Text + ";";
            Executar(CRUD.sql, "Update");

            CRUD.sql = "UPDATE ADICIONAIS_CADASTRO SET OCUPACAO = @ocupacao, ESTADO_CIVIL = @estado_civil, FILHOS = @filhos, INDICACAO = @indicacao, RELIGIAO = @religiao, CEP = @cep,  LOGRADOURO = @logradouro, NUMERO = @numero, COMPLEMENTO = @complemento, BAIRRO = @bairro, CIDADE = @cidade, ESTADO = @estado  WHERE CODCLIENTE = " + txtID.Text + ";";
            Executar(CRUD.sql, "Update");

            CRUD.sql = "UPDATE COMPRAS SET COD_PRODUTO = @cod_prod, NOME_PRODUTO = @nome_prod, VALOR_PRODUTO = @valor_prod WHERE CODCLIENTE = " + txtID.Text + ";";
            Executar(CRUD.sql, "Update");

            CRUD.sql = "UPDATE AVALIACAOREFLEXOPODAL SET TERAPEUTA = @TERAPEUTA, QUEIXACLIENTE = @QUEIXACLIENTE, OBSADICIONAIS = @OBSADICIONAIS, NERVOSO = @NERVOSO, GLAUDULAR = @GLAUDULAR, LINFATICO = @LINFATICO, CIRULATORIO = @CIRULATORIO," +
                " CARDIACO = @CARDIACO, RESPIRATORIO = @RESPIRATORIO, DIGESTIVO = @DIGESTIVO, URINARIO = @URINARIO, REPRODUTOR = @REPRODUTOR, ESQUELETICO = @ESQUELETICO, MUSCULAR = @MUSCULAR, PRIORIDADES = @PRIORIDADES WHERE CODCLIENTE = " + txtID.Text + ";";
            Executar(CRUD.sql, "Update");

        }

        private void btnCEP_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                string xml = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", txtCEP.Text);

                ds.ReadXml(xml);

                txtLogradouro.Text = ds.Tables[0].Rows[0]["logradouro"].ToString();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString();
                txtCidade.Text = ds.Tables[0].Rows[0]["cidade"].ToString();
                txtEstado.Text = ds.Tables[0].Rows[0]["uf"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao buscar CEP");
            }
        }

        private void txtCodProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Pesquisar_produto();
        }
        private void Pesquisar_produto()
        {
            CRUD.sql = "SELECT * FROM PRODUTOS WHERE CODPRODUTO = '" + txtCodProduto.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            DataGridView dgv = dataGridView1;

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;

            txtNomeProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);
            txtValorProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);

            dgv.Visible = false;
        }

        private void FormAtualizarCadastroComAbas_Load(object sender, EventArgs e)
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
            txtDataNasc.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtTelefone.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtEmail.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            txtProfissao.Text = Convert.ToString(dgv.CurrentRow.Cells[5].Value);
            txtCPF.Text = Convert.ToString(dgv.CurrentRow.Cells[6].Value);

            CRUD.sql = "SELECT * FROM ADICIONAIS_CADASTRO WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt2 = CRUD.PerformCRUD(CRUD.cmd);
            
            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt2;

            txtOcupacao.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtEstadoCivil.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtFilhos.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            txtIndicacao.Text = Convert.ToString(dgv.CurrentRow.Cells[5].Value);
            txtReligiao.Text = Convert.ToString(dgv.CurrentRow.Cells[6].Value);
            txtCEP.Text = Convert.ToString(dgv.CurrentRow.Cells[7].Value);
            txtLogradouro.Text = Convert.ToString(dgv.CurrentRow.Cells[8].Value);
            txtNumero.Text = Convert.ToString(dgv.CurrentRow.Cells[9].Value);
            txtComplemento.Text = Convert.ToString(dgv.CurrentRow.Cells[10].Value);
            txtBairro.Text = Convert.ToString(dgv.CurrentRow.Cells[11].Value);
            txtCidade.Text = Convert.ToString(dgv.CurrentRow.Cells[12].Value);
            txtEstado.Text = Convert.ToString(dgv.CurrentRow.Cells[13].Value);


            CRUD.sql = "SELECT * FROM COMPRAS WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt3 = CRUD.PerformCRUD(CRUD.cmd);

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt3;

            txtCodProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtNomeProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtValorProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);

            CRUD.sql = "SELECT * FROM AVALIACAOREFLEXOPODAL WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            //CRUD.sql = "SELECT * FROM CLIENTES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "' AND Senha = '" + txtSenha.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt4 = CRUD.PerformCRUD(CRUD.cmd);

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt4;

            txtTerapeuta.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
            txtQueixaCliente.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);
            txtObsAdicionais.Text = Convert.ToString(dgv.CurrentRow.Cells[4].Value);
            txtNervoso.Text = Convert.ToString(dgv.CurrentRow.Cells[5].Value);

            txtGlandular.Text = Convert.ToString(dgv.CurrentRow.Cells[6].Value);
            txtLinfatico.Text = Convert.ToString(dgv.CurrentRow.Cells[7].Value);
            txtCirculatorio.Text = Convert.ToString(dgv.CurrentRow.Cells[8].Value);
            txtCardiaco.Text = Convert.ToString(dgv.CurrentRow.Cells[9].Value);
            txtRespiratorio.Text = Convert.ToString(dgv.CurrentRow.Cells[10].Value);
            txtDigestorio.Text = Convert.ToString(dgv.CurrentRow.Cells[11].Value);
            txtUrinario.Text = Convert.ToString(dgv.CurrentRow.Cells[12].Value);
            txtReprodutor.Text = Convert.ToString(dgv.CurrentRow.Cells[13].Value);
            txtEsqueletico.Text = Convert.ToString(dgv.CurrentRow.Cells[14].Value);
            txtMuscular.Text = Convert.ToString(dgv.CurrentRow.Cells[15].Value);
            txtPrioridades.Text = Convert.ToString(dgv.CurrentRow.Cells[16].Value);

            CRUD.sql = "SELECT * FROM INFOCOMPLEMENTARES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            //CRUD.sql = "SELECT * FROM CLIENTES WHERE CODCLIENTE = '" + txtID.Text.Trim() + "' AND Senha = '" + txtSenha.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt5 = CRUD.PerformCRUD(CRUD.cmd);

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt5;

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
