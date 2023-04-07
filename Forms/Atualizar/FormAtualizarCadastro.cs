using MySql.Data.MySqlClient;
using Projeto_18___Clinica_Maia_Center.Forms.Atualizar;
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
            CRUD.cmd.Parameters.AddWithValue("datanascimento", txtDataNasc.Text.Trim());
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



            FormAtualizarInformacoesComplementares formAtualizarInformacoesComplementares = new FormAtualizarInformacoesComplementares();
            formAtualizarInformacoesComplementares.txtID.Text = txtID.Text;
            formAtualizarInformacoesComplementares.Show();
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
    }
}
