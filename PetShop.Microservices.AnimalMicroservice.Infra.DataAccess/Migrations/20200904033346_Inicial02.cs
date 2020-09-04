using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShop.Microservices.AnimalMicroservice.Infra.DataAccess.Migrations
{
    public partial class Inicial02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raça",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "Raca",
                table: "Animals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Raca",
                table: "Animals");

            migrationBuilder.AddColumn<string>(
                name: "Raça",
                table: "Animals",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
