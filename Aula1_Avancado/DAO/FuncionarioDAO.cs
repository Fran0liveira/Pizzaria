using Aula1_Avancado.Modelos; //importa modelos (funcionario)
using System.Data.SqlClient; //importa utilização de comandos SQL
using Aula1_Avancado.Banco;
using System;
using System.Windows.Forms;

namespace Aula1_Avancado.DAO
{
    public class FuncionarioDAO
    {
        //Variável global para armazenar o ID
        int seuId;

        //Método que realiza cadastro do aluno
        public int InserirFuncionario(Funcionario obj)
        {
            //Aqui estamos chamando a a classe que conecta com o banco
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazena um comando sql
                    string cmdsql = $" INSERT INTO Funcionario" +
                                    $" (nome_func, tel_func, cel_func, car_traba_func, end_func)" +
                                    $" values ('{obj.Nome_func}'," +
                                    $"'{obj.Tel_func}'" +
                                    $"'{obj.Cel_func}" +
                                    $"'{obj.Car_traba_func}'" +
                                    $"'{obj.End_func}' SELECT SCOPE IDENTITY()";

                    SqlCommand executesql = new SqlCommand(cmdsql, connection);

                    connection.Open();

                    // Retorna apenas um valor após a execução de uma consulta ou neste caso uma inserção
                    seuId = Convert.ToInt32(executesql.ExecuteScalar());

                    MessageBox.Show("Cadastro efetuado com Sucesso!");

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
                // Return tem que ser fora do Try...Catch pois quando esta dentro ele nao é identificado
                return seuId;
            }
        }
        public void alterarFuncionario(Funcionario obj)
        {
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazenar um comando sql
                    string cmdsql = $"UPDATE Funcionario SET" +
                                    $"nome_Func = '{obj.Nome_func}'" +
                                    $"tel_func = '{obj.Tel_func}'" +
                                    $"cel_func = '{obj.Cel_func}'" +
                                    $"car_traba_func = '{obj.Car_traba_func}'" +
                                    $"end_func = '{obj.End_func}'";

                    SqlCommand executesql = new SqlCommand(cmdsql, connection);

                    connection.Open();

                    executesql.ExecuteNonQuery();

                    MessageBox.Show("Alteração efetuada com sucesso!");

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
        public void deletarFuncionario(Funcionario obj)
        {
            using (var connection = new SqlConnection(ConnectionFactory.SQLConnectionString))
            {
                try
                {
                    //Variavel que armazenar um comando sql
                    string cmdsql = $"DELETE FROM Funcionario" +
                                    $"WHERE id_cli = '{obj.Id_func}' ";

                    SqlCommand executesql = new SqlCommand(cmdsql, connection);

                    connection.Open();

                    executesql.ExecuteNonQuery();

                    MessageBox.Show("Exclusão efetuada com sucesso!");

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




