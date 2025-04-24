using Demarco.DTOs;
using FluentValidation;
using System;

namespace Demarco.Application.Validators
{
    public class EmpregadoDTOValidator : AbstractValidator<EmpregadoDTO>
    {
        public EmpregadoDTOValidator()
        {
           
            RuleFor(x => x.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve ter 11 dígitos.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(data => data <= DateTime.Today.AddYears(-18))
                .WithMessage("O empregado deve ser maior de idade (18+).");
        }
    }
}
