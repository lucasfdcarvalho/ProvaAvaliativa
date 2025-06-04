using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaAvaliativa
{
    public class Produto
    {
        public int ID { get; private set; }

        public string Nome { get; private set; }

        public double Preco { get; private set; }

        public string Categoria { get; private set; }

        public Produto(int iD, string nome, double preco, string categoria)
        {
            ValidarId(iD);
            ValidarNome(nome);
            ValidarPreco(preco);
            ValidarCategoria(categoria);

            this.ID = iD;
            this.Nome = nome;
            this.Preco = preco;
            this.Categoria = categoria;
        }

        private void ValidarId(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID do produto inválido");
            }
        }

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Nome do produto inválido");
            }
        }

        private void ValidarPreco(double preco)
        {
            if (preco <= 0)
            {
                throw new Exception("Preço do produto inválido");
            }
        }

        private void ValidarCategoria(string categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria))
            {
                throw new Exception("Categoria do produto inválida");
            }
        }
    }
}
