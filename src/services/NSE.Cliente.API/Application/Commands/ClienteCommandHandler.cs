using System.Threading;
using System.Threading.Tasks;
using FluentValidation.Results;
using MediatR;
using NSE.Core.Mediator;
using NSE.Cliente.API.Models;

namespace NSE.Cliente.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;
            
            var cliente = new Models.Cliente(message.Id, message.Nome, message.Email, message.Cpf);
            
            // Validações de negocio!
            if (true) // Ja existe cliente com o CPF informado
            {
                AdicionarErro("Este CPF já estpa em uso.");
                return ValidationResult;
            }
            
            // Persistir no banco!
            
            return message.ValidationResult;
        }
    }
}