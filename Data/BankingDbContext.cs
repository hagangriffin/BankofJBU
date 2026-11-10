using BlazorServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerApp.Data;

public sealed class BankingDbContext(DbContextOptions<BankingDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasIndex(client => client.Username).IsUnique();
            entity.Property(client => client.Username).HasMaxLength(100).IsRequired();
            entity.Property(client => client.Password).IsRequired();
            entity.Property(client => client.FullName).HasMaxLength(200).IsRequired();
            entity.Property(client => client.Email).HasMaxLength(320).IsRequired();
            entity.Property(client => client.Balance).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.Property(transaction => transaction.Type).HasMaxLength(50).IsRequired();
            entity.Property(transaction => transaction.Amount).HasPrecision(18, 2);
            entity.HasOne(transaction => transaction.Client)
                .WithMany(client => client.Transactions)
                .HasForeignKey(transaction => transaction.ClientId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
