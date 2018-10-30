using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1_Avancado.Modelos
{
    public class Aluno
    {
        private int id_aluno;
        private string nome_aluno;
        private string email_aluno;
        private string endereco_aluno;

        public int Id_aluno { get; set; }
        public string Nome_aluno { get; set; }
        public string Email_aluno { get; set; }
        public string Endereco_aluno { get; set; }
    }
}
