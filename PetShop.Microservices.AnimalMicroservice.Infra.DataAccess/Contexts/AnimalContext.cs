using Microsoft.EntityFrameworkCore;
using PetShop.Microservices.AnimalMicroservice.Domain.AggregatesModel.AnimalAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.AnimalMicroservice.Infra.DataAccess.Contexts
{
    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:petshop-animal-microservice-db-server-sergio.database.windows.net,1433;Initial Catalog=PetShop-Animal-Microservice-Db;Persist Security Info=False;User ID=sergio;Password=123mudar!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
