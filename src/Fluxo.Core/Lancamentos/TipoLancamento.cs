namespace Fluxo.Core.Lancamentos
{
    public class TipoLancamento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string HistoricoPadrao { get; set; }
        public TipoOperacaoEnum TipoOperacaoPadrao { get; set; }
        public string Grupo { get; set; }
    }
}
