using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using Models;

namespace MyProject.Data
{
    public class Context : DbContext
    {
        public DbSet<Models.Product> Products { get; set; }
        public DbSet<Models.Almox> Almox {get; set;}
        public DbSet<Models.Saldo> Saldos {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Aqui voce troca o caminho pro teu banco de dados!!
            var connectionString = "server=localhost;database=productscsharp;user=root;password=Wheniparkmyrr_1234";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
