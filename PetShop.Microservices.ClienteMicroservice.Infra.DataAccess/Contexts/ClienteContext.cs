using Microsoft.EntityFrameworkCore;
using PetShop.Microservices.ClienteMicroservice.Domain.AggregatesModel.ClienteAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Microservices.ClienteMicroservice.Infra.DataAccess.Contexts
{
    public class ClienteContext :DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=tcp:petshop-cliente-microservice-db-server-sergio.database.windows.net,1433;Initial Catalog=PetShop-Cliente-Microservice-Db;Persist Security Info=False;User ID=sergio;Password=123mudar!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
