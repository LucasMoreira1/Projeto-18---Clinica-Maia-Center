using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_18___Clinica_Maia_Center.Forms
{
    public partial class FormCadastro : Form
    {
        public FormCadastro()
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
        // INSERT dos dados. Cadastro Cliente.
        private void btnSalvarCadastro_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                MessageBox.Show("Por favor insira o Nome completo", "Dados Obrigatórios",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "INSERT INTO CLIENTES(nome, datanascimento, telefone, email, profissao, cpf) Values(@nome, @datanascimento, @telefone, @email, @profissao, @cpf);";
            Executar(CRUD.sql, "Insert");

            CRUD.sql = "SELECT LAST_INSERT_ID()";

            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);


            DataGridView dgv = dataGridView1;
            dgv.Visible = true;
            dgv.DataSource = dt;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            string NumeroRegistro = dgv.CurrentCell.Value.ToString();
            dgv.Visible = false;
            txtID.Text = NumeroRegistro;

            CRUD.sql = "INSERT INTO ADICIONAIS_CADASTRO(CODCLIENTE, OCUPACAO, ESTADO_CIVIL, FILHOS, INDICACAO, RELIGIAO, CEP, LOGRADOURO, NUMERO, COMPLEMENTO, BAIRRO, CIDADE, ESTADO)" +
                " Values(" + txtID.Text + ", @ocupacao, @estado_civil, @filhos, @indicacao, @religiao, @cep, @logradouro, @numero, @complemento, @bairro, @cidade, @estado);";
            Executar(CRUD.sql, "Insert");

            CRUD.sql = "INSERT INTO COMPRAS(CODCLIENTE, COD_PRODUTO, NOME_PRODUTO, VALOR_PRODUTO)" +
                " Values(" + txtID.Text + ", @cod_prod, @nome_prod, @valor_prod);";
            Executar(CRUD.sql, "Insert");

            FormInformacoesComplementares formInformacoesComplementares = new FormInformacoesComplementares();
            formInformacoesComplementares.txtID.Text = txtID.Text;
            formInformacoesComplementares.Show();

            //MessageBox.Show("Cliente " + NumeroRegistro + " cadastrado com sucesso.", "Cadastro",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
