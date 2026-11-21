using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using MediatR;
using NSE.Core.Messages;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace NSE.Core.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await  _mediator.Publish(evento);
        }

        public async Task<ValidationResult> EnviarComand<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }
    }
}