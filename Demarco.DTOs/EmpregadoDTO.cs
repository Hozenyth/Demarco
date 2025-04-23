using System;

namespace Demarco.DTOs
{
    public class EmpregadoDTO
    {
        public int ID { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
    }
}
