namespace AsyncFlow.Core.Events
{
    public record ProdutoCreatedEvent(
        Guid Id,
        string Name,
        string Email
    );
}
