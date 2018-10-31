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
   
    public class ClienteDAO
        
    {
        //Variavel Global para amazenar o ID
        int seuId;
       
        //Metodo que realiza o cadastro do aluno
        public int InserirCliente(Cliente obj)
        {
           //Aqui estamos chamando a a classe que conecta com o banco
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazenar um comando sql
                    string cmdsql = $"insert into cliente" +
                                       $"(nome_cli,tel_cli,cel_cli)" +
                                       $"values ('{obj.Nome_cli}'," +
                                       $"'{obj.Tel_cli}'," +
                                       $"'{obj.Cel_cli}') SELECT SCOPE_IDENTITY()";

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

        public void alterarCliente(Cliente obj)
        {
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazenar um comando sql
                    string cmdsql = $"update cliente set " +
                                       $"nome_cli = '{obj.Nome_cli}'," +
                                       $"tel_cli = '{obj.Tel_cli}'," +
                                       $"cel_aluno = '{obj.Cel_cli}'" +
                                       $"where id_cli ='{obj.Id_cli}' ";


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

        public void deletarCliente(Cliente obj)
        {
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazenar um comando sql
                    string cmdsql = $"delete from cliente "+
                                    $"where id_cli ='{obj.Id_cli}' ";


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
