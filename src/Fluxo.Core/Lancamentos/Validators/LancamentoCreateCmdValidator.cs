using FluentValidation;
using Fluxo.Core.Lancamentos.Commands;

namespace Fluxo.Core.Lancamentos.Validators
{
    public class LancamentoCreateCmdValidator : AbstractValidator<LancamentoCreateCmd>
    {
        public LancamentoCreateCmdValidator()
        {
            RuleFor(o => o.DataMovimentacao).NotEmpty().GreaterThan(DateTime.Now.AddDays(-1));
            RuleFor(o => o.Historico).NotEmpty();
            RuleFor(o => o.TipoLancamentoId).NotEmpty();
            RuleFor(o => o.Valor).NotEmpty().GreaterThan(0);
        }
    }
}
