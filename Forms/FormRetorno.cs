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
    public partial class FormRetorno : Form
    {
        public FormRetorno()
        {
            InitializeComponent();
        }
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
            CRUD.cmd.Parameters.AddWithValue("CODCLIENTE", txtID.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("NOME", txtNome.Text.Trim());
            CRUD.cmd.Parameters.AddWithValue("TEXTO_RETORNO", txtRetorno.Text.Trim());
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CRUD.sql = "UPDATE RETORNO SET TEXTO_RETORNO = @TEXTO_RETORNO WHERE CODCLIENTE = " + txtID.Text + ";";
            Executar(CRUD.sql, "Update");

            this.Close();
        }

        private void FormRetorno_Load(object sender, EventArgs e)
        {
            CRUD.sql = "SELECT * FROM RETORNO WHERE CODCLIENTE = '" + txtID.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            DataGridView dgv = dataGridView1;
            
            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;

            if (dgv.Rows.Count == 1)
            {
                btnSalvar.Visible = true;
                btnAtualizar.Visible = false;
                dgv.Visible = false;
                return;
            }

            btnSalvar.Visible = false;
            btnAtualizar.Visible = true;

            txtRetorno.Text = Convert.ToString(dgv.CurrentRow.Cells[3].Value);


            dgv.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            CRUD.sql = "INSERT INTO RETORNO(CODCLIENTE, NOME, TEXTO_RETORNO) Values(@CODCLIENTE, @NOME, @TEXTO_RETORNO);";
            Executar(CRUD.sql, "Insert");

            this.Close();

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
    }
}
