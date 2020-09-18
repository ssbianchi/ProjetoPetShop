using Microsoft.EntityFrameworkCore;
using PetShop.Microservices.AdotarMicroservice.Domain.AggregatesModel.AdotarAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AdotarMicroservice.Infra.DataAccess.Contexts
{
    public class AdotarContext : DbContext
    {
        public DbSet<Adotar> Adocoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:petshop-adotar-microservice-db-server-sergio.database.windows.net,1433;Initial Catalog=PetShop-Adotar-Microservice-Db;Persist Security Info=False;User ID=sergio;Password=123mudar!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
