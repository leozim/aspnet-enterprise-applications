using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using NSE.Core.Messages;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace NSE.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<ValidationResult> EnviarComand<T>(T comando) where T : Command;
    }
}