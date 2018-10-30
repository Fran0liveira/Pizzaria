using Aula1_Avancado.DAO;
using Aula1_Avancado.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula1_Avancado.Telas
{
    public partial class frm_cliente1 : Form
    {
        int id;
        public frm_cliente1()
        {
            InitializeComponent();
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
                    //Aqui estou chamando(instanciando) minha classe que possui os atributos ou caracteristicas do meu Cliente
                    Cliente obj = new Cliente();
                    obj.Nome_cli = txtNome.Text;//Aqui estamos atribuindo o valor escrito no campo Nome ao atributo da nome_aluno da classe Cliente
                    obj.Tel_cli = txtEmail.Text;
                    obj.Cel_cli = txtEndereco.Text;


                    ClienteDAO alunodao = new ClienteDAO();//Aqui estou instanciando a classe alunoDAO para pegar o metodo que insere aluno
                    id = alunodao.InserirCliente(obj);//Aqui chamei meu metodo e estou jogando o id que foi criado quando inseri o aluno

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
                    Cliente obj = new Cliente();
                    obj.Id_cli = Convert.ToInt32(txtId.Text);
                    obj.Nome_cli = txtNome.Text;//Aqui estamos atribuindo o valor escrito no campo Nome ao atributo da nome_aluno da classe Cliente
                    obj.Tel_cli = txtEmail.Text;
                    obj.Cel_cli = txtEndereco.Text;


                    ClienteDAO alunodao = new ClienteDAO();//Aqui estou instanciando a classe alunoDAO para pegar o metodo que insere aluno
                    alunodao.alterarCliente(obj);//Aqui chamei meu metodo e estou jogando o id que foi criado quando inseri o aluno

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
                    Cliente obj = new Cliente();
                    obj.Id_cli = Convert.ToInt32(txtId.Text);

                    ClienteDAO alunodao = new ClienteDAO();//Aqui estou instanciando a classe alunoDAO para pegar o metodo que insere aluno
                    alunodao.deletarCliente(obj);//Aqui chamei meu metodo e estou jogando o id que foi criado quando inseri o aluno
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