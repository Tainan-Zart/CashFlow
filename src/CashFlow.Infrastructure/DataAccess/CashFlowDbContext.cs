using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess;
public class CashFlowDbContext : DbContext 
{

    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=CashFlowDb;User Id=postgres;Password=admin;");
    }

}
