namespace BlazorServerApp.Models;

public sealed class Client
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public DateTime CreatedUtc { get; set; }

    public ICollection<Transaction> Transactions { get; } = new List<Transaction>();
}
