using Aula1_Avancado.Banco;
using Aula1_Avancado.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aula1_Avancado.DAO
{
   
    public class AlunoDAO
        
    {
        //Variavel Global para amazenar o ID
        int seuId;
       
        //Metodo que realiza o cadastro do aluno
        public int InserirAluno(Aluno obj)
        {
           //Aqui estamos chamando a a classe que conecta com o banco
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazenar um comando sql
                    string cmdsql = $"insert into TB_ALUNO" +
                                       $"(nome_aluno,email_aluno,endereco_aluno)" +
                                       $"values ('{obj.Nome_aluno}'," +
                                       $"'{obj.Email_aluno}'," +
                                       $"'{obj.Endereco_aluno}') SELECT SCOPE_IDENTITY()";

                    SqlCommand executesql = new SqlCommand(cmdsql, connection);

                    connection.Open();

                    // Retorna apenas um valor após a execução de uma consulta ou neste caso uma inserção
                    seuId = Convert.ToInt32(executesql.ExecuteScalar());
                    
                    MessageBox.Show("Cadastro Efetuado com Sucesso");


                    connection.Close();

                    
                }
                catch(Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                finally
                {
                    connection.Close();
                }
                //Return tem que ser fora do Try...Catch pois quando esta dentro ele nao é identificado
                return seuId;

            }

        }

        public void alterarAluno(Aluno obj)
        {
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazenar um comando sql
                    string cmdsql = $"update TB_ALUNO set " +
                                       $"nome_aluno = '{obj.Nome_aluno}'," +
                                       $"email_aluno = '{obj.Email_aluno}'," +
                                       $"endereco_aluno = '{obj.Endereco_aluno}'" +
                                       $"where id_aluno ='{obj.Id_aluno}' ";


                    SqlCommand executesql = new SqlCommand(cmdsql, connection);

                    connection.Open();


                    executesql.ExecuteNonQuery();


                    MessageBox.Show("Alteração Efetuada com Sucesso");


                    connection.Close();


                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }

        public void deletarAluno(Aluno obj)
        {
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazenar um comando sql
                    string cmdsql = $"delete from TB_ALUNO "+
                                    $"where id_aluno ='{obj.Id_aluno}' ";


                    SqlCommand executesql = new SqlCommand(cmdsql, connection);

                    connection.Open();


                    executesql.ExecuteNonQuery();


                    MessageBox.Show("Exclusão Efetuada com Sucesso");


                    connection.Close();


                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
        }
    }
}
