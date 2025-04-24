using Demarco.DTOs;
using FluentValidation;
using System;

namespace Demarco.Application.Validators
{
    public class UsuarioDTOValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioDTOValidator()
        {

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("O email é obrigatório.")
               .EmailAddress().WithMessage("O email informado não é válido.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória");

        }
    }
}
