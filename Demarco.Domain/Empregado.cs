using System;
using System.Collections.Generic;
using System.Text;

namespace Demarco.Domain
{
    public class Empregado: BaseEntity
    {
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public Empregado(int id, string cpf, string nome, DateTime dataNascimento)
        {
            this.ID = id;
            this.CPF = cpf;
            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }

        public Empregado() { }

    }
}
