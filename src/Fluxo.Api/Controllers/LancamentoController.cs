using Fluxo.Core.Lancamentos.Commands;
using Fluxo.Core.Lancamentos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fluxo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LancamentoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LancamentoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] LancamentoQuery query)
        {
            var lancamentos = await _mediator.Send(query);
            return Ok(lancamentos);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LancamentoCreateCmd command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("ReenviarConsolidacao")]
        public async Task<IActionResult> ReenviarConsolidacao(LancamentoReenvioCmd cmd)
        {
            await _mediator.Send(cmd);

            return Ok();
        }
    }
}
