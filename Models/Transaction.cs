namespace BlazorServerApp.Models;

public sealed class Transaction
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedUtc { get; set; }

    public Client Client { get; set; } = null!;
}
