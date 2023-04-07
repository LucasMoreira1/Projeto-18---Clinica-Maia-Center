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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }
        // Abrir formulário de cadastro.
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            FormCadastro formCadastro = new FormCadastro();
            formCadastro.Show();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CRUD.sql = "SELECT * FROM CLIENTES ORDER BY CODCLIENTE;";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);


            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            DataGridView dgv = dataGridView1;

            dgv.DataSource = dt;
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void txtPesquisar_Click(object sender, EventArgs e)
        {
            txtPesquisar.Text = "";
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            CRUD.sql = "SELECT * FROM CLIENTES WHERE Nome LIKE '%" + txtPesquisar.Text.Trim() + "%' ORDER BY CODCLIENTE;";

            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);

            DataGridView dgv = dataGridView1;

            dgv.MultiSelect = false;
            dgv.AutoGenerateColumns = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DataSource = dt;

            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = dataGridView1;
            FormAtualizarCadastro formAtualizarCadastro = new FormAtualizarCadastro();
            formAtualizarCadastro.txtID.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);

            formAtualizarCadastro.Show();
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnPesquisar_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dataGridView1;
            FormAtualizarCadastro formAtualizarCadastro = new FormAtualizarCadastro();
            formAtualizarCadastro.txtID.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);

            formAtualizarCadastro.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = dataGridView1;
            txtCODCLIENTE.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dataGridView1;

            if (dgv.Rows.Count == 0)
            {
                return;
            }
            if (string.IsNullOrEmpty(txtCODCLIENTE.Text))
            {
                MessageBox.Show("Por favor, selecione um item da lista.", "Deletar dados",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            int clienteSelecionado = Convert.ToInt32(txtCODCLIENTE.Text);


            if (MessageBox.Show("Tem certeza que deseja deletar os dados selecionados?", "Deletar Dados",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CRUD.sql = "DELETE FROM CLIENTES WHERE CODCLIENTE = " + clienteSelecionado + "";
                CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
                CRUD.PerformCRUD(CRUD.cmd);

                CRUD.sql = "DELETE FROM AVALIACAOREFLEXOPODAL WHERE CODCLIENTE = " + clienteSelecionado + "";
                CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
                CRUD.PerformCRUD(CRUD.cmd);

                CRUD.sql = "DELETE FROM ADICIONAIS_CADASTRO WHERE CODCLIENTE = " + clienteSelecionado + "";
                CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
                CRUD.PerformCRUD(CRUD.cmd);

                CRUD.sql = "DELETE FROM INFOCOMPLEMENTARES WHERE CODCLIENTE = " + clienteSelecionado + "";
                CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
                CRUD.PerformCRUD(CRUD.cmd);

                MessageBox.Show("Cliente deletado com sucesso.", "Deletar dados",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                //loadData();
            }
        }

        private void btnRetorno_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dataGridView1;
            FormRetorno formRetorno = new FormRetorno();
            formRetorno.txtID.Text = Convert.ToString(dgv.CurrentRow.Cells[0].Value);
            formRetorno.txtNome.Text = Convert.ToString(dgv.CurrentRow.Cells[1].Value);

            formRetorno.Show();
        }
    }
}
