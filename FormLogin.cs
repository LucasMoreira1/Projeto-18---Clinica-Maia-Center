using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Projeto_18___Clinica_Maia_Center
{
    public partial class FormLogin : Form
    {
        int i;
        string filename = "";
        bool trocarsenha = false;
        MySqlDataReader reader;
        public static MySqlCommand cmd = default(MySqlCommand);

        public FormLogin()
        {
            InitializeComponent();
        }

        private void Executar(string mySQL, string param)
        {
            CRUD.cmd = new MySqlCommand(mySQL, CRUD.con);
            if (trocarsenha == false)
            {
                AddParametros(param);
            }
            CRUD.PerformCRUD(CRUD.cmd);
        }

        private void AddParametros(string str)
        {
            CRUD.cmd.Parameters.Clear();

            FileStream fileStream = File.OpenRead(filename);
            byte[] contents = new byte[fileStream.Length];
            fileStream.Read(contents, 0, (int)contents.Length);
            fileStream.Close();

            CRUD.cmd.Parameters.AddWithValue("LOG_FILE", contents);

            //Identificação Autor
            CRUD.cmd.Parameters.AddWithValue("ID_CLIENTE", "9999");
            CRUD.cmd.Parameters.AddWithValue("NOME_CLIENTE", "LOG_LOGIN");
            //Informações Gerais
            CRUD.cmd.Parameters.AddWithValue("DATA_ATUALIZACAO", Convert.ToDateTime(DateTime.Now));
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            i = 0;

            CRUD.sql = "SELECT * FROM LOGIN WHERE Usuario = '" + txtLogin.Text.Trim() + "' AND Senha = '" + txtSenha.Text.Trim() + "'";
            CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
            DataTable dt = CRUD.PerformCRUD(CRUD.cmd);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            DataGridView dgv = dataGridView1;

            dgv.Visible = true;
            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;
            //string permissao = Convert.ToString(dgv.CurrentRow.Cells[3].Value);



            if (i == 0)
            {
                dgv.Visible = false;
                MessageBox.Show("Usuário ou senha incorretos");
            }
            else
            {
                string permissao = Convert.ToString(dgv.CurrentRow.Cells[3].Value);

                if (permissao == "1")
                {
                    this.Hide();
                    FormPaginaInicial formPaginaInicial = new FormPaginaInicial();
                    formPaginaInicial.txtNomeLogin.Text = txtLogin.Text;
                    formPaginaInicial.txtPermissaoLogin.Text = permissao;
                    //CRIAÇÃO DE LOG
                    //Converter para string a pasta %temp%
                    string dir = Path.GetTempPath();
                    filename = dir + "9999_LOG_LOGIN.txt";
                    //Validar se já existe aquivo LOG
                    CRUD.sql = "SELECT LOG_FILE FROM LOGS WHERE ID_CLIENTE = '9999';";

                    CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
                    DataTable dt2 = CRUD.PerformCRUD(CRUD.cmd);

                    if (dt2.Rows.Count > 0)
                    {
                        //Baixar Documento de LOG
                        bool em = false;
                        CRUD.sql = "SELECT LOG_FILE FROM LOGS WHERE ID_CLIENTE = '9999';";
                        CRUD.con.Open();
                        using (CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con))
                        {
                            using (reader = CRUD.cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    em = true;
                                    byte[] fileData = (byte[])reader.GetValue(0);
                                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
                                    {
                                        using (BinaryWriter bw = new BinaryWriter(fs))
                                        {
                                            bw.Write(fileData);
                                            bw.Close();

                                        }
                                    }

                                }
                            }
                        }
                        CRUD.con.Close();
                        //Escrever no Documento de LOG
                        Logger.WriteLog(filename, "Logou no sistema;", txtLogin.Text);
                        //Atualiza Log existente
                        CRUD.sql = "UPDATE LOGS SET LOG_FILE = @LOG_FILE, DATA_ATUALIZACAO = @DATA_ATUALIZACAO WHERE ID_CLIENTE = @ID_CLIENTE";
                        Executar(CRUD.sql, "Update");
                    }
                    else
                    {
                        //Escrever no Documento de LOG
                        Logger.WriteLog(filename, "Logou no sistema;", txtLogin.Text);
                        //Salvar Documento de LOG
                        CRUD.sql = "INSERT INTO LOGS(ID_CLIENTE,NOME_CLIENTE,LOG_FILE,DATA_ATUALIZACAO)" +
                                    "Values(@ID_CLIENTE, @NOME_CLIENTE, @LOG_FILE, @DATA_ATUALIZACAO)";
                        Executar(CRUD.sql, "Insert");
                    }
                    // Logger.LoginName(txtLogin.Text);
                    //Logger.WriteLog("Login no sistema",txtLogin.Text);

                    formPaginaInicial.Show();

                }
                else
                {
                    this.Hide();
                    FormPaginaInicial formPaginaInicial = new FormPaginaInicial();
                    formPaginaInicial.btnVisualizarLogs.Visible = false;
                    formPaginaInicial.txtNomeLogin.Text = txtLogin.Text;
                    formPaginaInicial.txtPermissaoLogin.Text = permissao;

                    //CRIAÇÃO DE LOG
                    //Converter para string a pasta %temp%
                    string dir = Path.GetTempPath();
                    filename = dir + "9999_LOG_LOGIN.txt";
                    //Validar se já existe aquivo LOG
                    CRUD.sql = "SELECT LOG_FILE FROM LOGS WHERE ID_CLIENTE = '9999';";

                    CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con);
                    DataTable dt2 = CRUD.PerformCRUD(CRUD.cmd);

                    if (dt2.Rows.Count > 0)
                    {
                        //Baixar Documento de LOG
                        bool em = false;
                        CRUD.sql = "SELECT LOG_FILE FROM LOGS WHERE ID_CLIENTE = '9999';";
                        CRUD.con.Open();
                        using (CRUD.cmd = new MySqlCommand(CRUD.sql, CRUD.con))
                        {
                            using (reader = CRUD.cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    em = true;
                                    byte[] fileData = (byte[])reader.GetValue(0);
                                    using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
                                    {
                                        using (BinaryWriter bw = new BinaryWriter(fs))
                                        {
                                            bw.Write(fileData);
                                            bw.Close();

                                        }
                                    }

                                }
                            }
                        }
                        CRUD.con.Close();
                        //Escrever no Documento de LOG
                        Logger.WriteLog(filename, "Logou no sistema;", txtLogin.Text);
                        //Atualiza Log existente
                        CRUD.sql = "UPDATE LOGS SET LOG_FILE = @LOG_FILE, DATA_ATUALIZACAO = @DATA_ATUALIZACAO WHERE ID_CLIENTE = @ID_CLIENTE";
                        Executar(CRUD.sql, "Update");
                    }
                    else
                    {
                        //Escrever no Documento de LOG
                        Logger.WriteLog(filename, "Logou no sistema;", txtLogin.Text);
                        //Salvar Documento de LOG
                        CRUD.sql = "INSERT INTO LOGS(ID_CLIENTE,NOME_CLIENTE,LOG_FILE,DATA_ATUALIZACAO)" +
                                    "Values(@ID_CLIENTE, @NOME_CLIENTE, @LOG_FILE, @DATA_ATUALIZACAO)";
                        Executar(CRUD.sql, "Insert");
                    }

                    formPaginaInicial.Show();
                }
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }

        private void btnTrocarSenha_Click(object sender, EventArgs e)
        {
            trocarsenha = true;
            string nomeUsuario = Interaction.InputBox("Insira seu nome de usuario: ", "Reset de senha");
            string senhaAntiga = Interaction.InputBox("Insira sua senha antiga: ", "Reset de senha");
            string novasenha = Interaction.InputBox("Insira sua nova senha: ", "Reset de senha");
            string confirmasenha = Interaction.InputBox("Confirme sua nova senha: ", "Reset de senha");
            if (novasenha == confirmasenha)
            {
                CRUD.sql = "UPDATE LOGIN SET SENHA = '" + novasenha + "' WHERE USUARIO = '" + nomeUsuario + "' AND SENHA = '" + senhaAntiga + "'";
                Executar(CRUD.sql, "Update");
                MessageBox.Show("Senha alterada com sucesso.");
            }
            else
            {
                MessageBox.Show("Houve um erro ao alterar sua senha, tente novamente.");
            }
            trocarsenha = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
