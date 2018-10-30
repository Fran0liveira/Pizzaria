using Aula1_Avancado.DAO;
using Aula1_Avancado.Modelos;
using System;
using System.Windows.Forms;

namespace Aula1_Avancado
{
    public partial class Form1 : Form
    {
        //Variavel Global pode ser usada por qualquer metodo presente nesta classe
        int id;
        public Form1()
        {
            InitializeComponent();
            txtId.Enabled = false;//Estou dizendo que quando inicializar meu programa este campo estara  desabilitado
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Aqui esta verificando se todos os campos na tela estão preenchidos, ou seja, vazios ou não.
            if (txtNome.Text == string.Empty ||
                txtEmail.Text == string.Empty ||
                txtEndereco.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Oficina C#", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                //Try...Catch uma forma de tentar realizar uma ação, caso algo esteja errado será exibida uma mensagem
                try
                {
                    //Aqui estou chamando(instanciando) minha classe que possui os atributos ou caracteristicas do meu Aluno
                    Aluno obj = new Aluno();
                    obj.Nome_aluno = txtNome.Text;//Aqui estamos atribuindo o valor escrito no campo Nome ao atributo da nome_aluno da classe Aluno
                    obj.Email_aluno = txtEmail.Text;
                    obj.Endereco_aluno = txtEndereco.Text;


                    AlunoDAO alunodao = new AlunoDAO();//Aqui estou instanciando a classe alunoDAO para pegar o metodo que insere aluno
                    id = alunodao.InserirAluno(obj);//Aqui chamei meu metodo e estou jogando o id que foi criado quando inseri o aluno

                    txtId.Text = Convert.ToString(id);//Aqui estou convertentod o id e colocando ele dentro do campo id


                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAlterar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == string.Empty ||
                txtEmail.Text == string.Empty ||
                txtEndereco.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!", "Oficina C#", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                //Try...Catch uma forma de tentar realizar uma ação, caso algo esteja errado será exibida uma mensagem
                try
                {
                    Aluno obj = new Aluno();
                    obj.Id_aluno = Convert.ToInt32(txtId.Text);
                    obj.Nome_aluno = txtNome.Text;//Aqui estamos atribuindo o valor escrito no campo Nome ao atributo da nome_aluno da classe Aluno
                    obj.Email_aluno = txtEmail.Text;
                    obj.Endereco_aluno = txtEndereco.Text;


                    AlunoDAO alunodao = new AlunoDAO();//Aqui estou instanciando a classe alunoDAO para pegar o metodo que insere aluno
                    alunodao.alterarAluno(obj);//Aqui chamei meu metodo e estou jogando o id que foi criado quando inseri o aluno

                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void txtExcluir_Click(object sender, EventArgs e)
        {
            if (txtId.Text == String.Empty)
            {
                MessageBox.Show("Selecione um aluno", "Oficina C#", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                //Try...Catch uma forma de tentar realizar uma ação, caso algo esteja errado será exibida uma mensagem
                try
                {
                    Aluno obj = new Aluno();
                    obj.Id_aluno = Convert.ToInt32(txtId.Text);

                    AlunoDAO alunodao = new AlunoDAO();//Aqui estou instanciando a classe alunoDAO para pegar o metodo que insere aluno
                    alunodao.deletarAluno(obj);//Aqui chamei meu metodo e estou jogando o id que foi criado quando inseri o aluno
                    limpar();
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        public void limpar()
        {
            txtId.Text = "";
            txtEmail.Text = "";
            txtEndereco.Text = "";
            txtNome.Text = "";
        }
    }
}
