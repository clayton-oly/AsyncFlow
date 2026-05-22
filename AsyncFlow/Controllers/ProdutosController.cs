using AsyncFlow.Core.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AsyncFlow.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public ProdutosController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var userCreatedEvent = new ProdutoCreatedEvent(
                Guid.NewGuid(),
                "Clayton",
                "teste@gmail.com"
            );

            await _publishEndpoint.Publish(userCreatedEvent);

            return Ok("Evento publicado");
        }

    }
}
