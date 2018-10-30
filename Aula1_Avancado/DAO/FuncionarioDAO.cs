using Aula1_Avancado.Modelos; //importa modelos (funcionario)
using System.Data.SqlClient; //importa utilização de comandos SQL
using Aula1_Avancado.Banco;

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

                }

            }


        }

    }
}
