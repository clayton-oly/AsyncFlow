using AsyncFlow.Core.Events;
using MassTransit;

namespace AsyncFlow.Core.Consumer
{
    public class ProdutoCreatedConsumer
        : IConsumer<ProdutoCreatedEvent>
    {
        public async Task Consume(
            ConsumeContext<ProdutoCreatedEvent> context)
        {
            var message = context.Message;

            Console.WriteLine(
                $"Produto recebido: {message.Name}");

            await Task.CompletedTask;
        }
    }
}