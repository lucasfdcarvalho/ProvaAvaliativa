using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class Cliente
    {
        public int ID { get; private set; }

        public string Nome { get; private set; }

        public string Email { get; private set; }

        public string CPF { get; private set; }

        public Cliente(int iD, string nome, string email, string cPF)
        {
            ValidarId(iD);
            ValidarNome(nome);
            ValidarEmail(email);
            ValidarCpf(cPF);

            this.ID = iD;
            this.Nome = nome;
            this.Email = email;
            this.CPF = cPF;
        }

        private void ValidarId(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID do cliente inválido");
            }
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Nome do cliente inválido");
            }
        }

        private void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("E-mail do cliente inválido");
            }
        }

        private void ValidarCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
            {
                throw new Exception("CPF inválido");
            }
        }
    }
}
