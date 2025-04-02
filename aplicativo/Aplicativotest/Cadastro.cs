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

namespace Aplicativotest
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void btnCadastro_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                if (usuario != "" && senha != "")
                {
                    string conexaoB = "Server=localhost; Database=sistemaLogin; Uid=root; pwd='';";
                    using (MySqlConnection conexao = new MySqlConnection(conexaoB))
                    {

                        conexao.Open();

                        string query = "INSERT INTO usuarios (usuario, senha) VALUES (@usuario, @senha)";

                        using (MySqlCommand comando = new MySqlCommand(query, conexao))
                        {
                            comando.Parameters.AddWithValue("@usuario", usuario);
                            comando.Parameters.AddWithValue("@senha", senha);
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Login telaLogin = new Login();
                    telaLogin.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Preencha os campos corretamente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o cadastro" + ex.Message);
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
