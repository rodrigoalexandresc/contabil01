using Fluxo.SharedKernel.Lancamentos;

namespace Fluxo.Core.Lancamentos.Mappers
{
    public static class LancamentoToLancamentoCreatedMessageMap
    {
        public static LancamentoCreatedMessage MapToLancamentoCreatedMessage(this Lancamento o) =>
            new LancamentoCreatedMessage
            {
                LancamentoId = o.Id,
                DataMovimentacao = o.DataMovimentacao,
                FormaPagamento = o.FormaPagamento != null ? o.FormaPagamento.Descricao : string.Empty,
                GrupoConsolidacao = o.TipoLancamento.Grupo,
                TipoLancamento = o.TipoLancamento.Descricao,
                TipoOperacao = (int)o.TipoLancamento.TipoOperacaoPadrao,
                Valor = o.Valor,
            };
    }
}
