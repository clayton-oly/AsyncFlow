namespace AsyncFlow.Gateway.Events
{
    public record ProdutoCreatedEvent(
        Guid Id,
        string Name,
        string Email
    );
}
