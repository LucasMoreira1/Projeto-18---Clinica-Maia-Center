using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_18___Clinica_Maia_Center.Forms
{
    public partial class FormProduto : Form
    {
        public FormProduto()
        {
            InitializeComponent();
        }

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
            CRUD.cmd.Parameters.AddWithValue("nome_produto", txtNomeProduto.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("valor_produto", txtValorProduto.Text.Trim());
        }

        private void FormProduto_Load(object sender, EventArgs e)
        {
            CRUD.sql = "SELECT * FROM PRODUTOS ORDER BY CODPRODUTO;";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);


            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            DataGridView dgv = dataGridView1;

            dgv.DataSource = dt;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeProduto.Text.Trim()) || string.IsNullOrEmpty(txtValorProduto.Text.Trim()))
            {
                MessageBox.Show("Por favor insira o Nome e Valor do Produto", "Dados Obrigatórios",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CRUD.sql = "INSERT INTO PRODUTOS(NOME_PRODUTO, VALOR_PRODUTO) Values(@nome_produto, @valor_produto);";
            Executar(CRUD.sql, "Insert");


            MessageBox.Show("Produto: " + txtNomeProduto.Text + ". Cadastrado com sucesso.", "Cadastro",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditarProduto_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dataGridView1;
            
            txtID.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
            txtNomeProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);
            txtValorProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);

        }

        private void btnExcluirProduto_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = dataGridView1;

            txtID.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
            txtNomeProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);
            txtValorProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = dataGridView1;

            txtID.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
            txtNomeProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);
            txtValorProduto.Text = Convert.ToString(dgv.CurrentRow.Cells[2].Value);
        }
    }
}
