using MySql.Data.MySqlClient;
namespace Aplicativotest
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.ToLower();
                string senha = txtSenha.Text.ToLower();

                if (usuario != "" && senha != "")
                {

                    string conexaoB = "Server=localhost; Database=sistemaLogin; Uid=root; pwd='';";

                    MySqlConnection conexao = new MySqlConnection(conexaoB);

                    conexao.Open();

                    string consultaU = "select * from usuarios where usuario = @usuario and senha = @senha ";
                    MySqlCommand comandSQL = new MySqlCommand(consultaU, conexao);
                    comandSQL.Parameters.AddWithValue("@usuario", usuario);
                    comandSQL.Parameters.AddWithValue("@senha", senha);

                    int registro = Convert.ToInt32(comandSQL.ExecuteScalar());

                    if (registro > 0)
                    {
                        MessageBox.Show("Login realizado com sucesso!","Sucesso",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    }
                    else
                    {
                        MessageBox.Show("Usuario ou senha invalidos!","Invalido",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                    conexao.Close();
                }
                else
                {
                    MessageBox.Show("Prencha os campos coretamente","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar o login" + ex.Message);

            }
        }

        private void btnCadasto_Click(object sender, EventArgs e)
        {
            Cadastro telacadastro = new Cadastro();
            telacadastro.Show();
            this.Hide();

        }
    }
}
