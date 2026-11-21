using System;
using MediatR;
using NSE.Core.Messages;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace NSE.Core.Mediator
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}