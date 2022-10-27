using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaymoveTeste.Migrations
{
    public partial class nascimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Nascimento",
                table: "Fornecedores",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nascimento",
                table: "Fornecedores");
        }
    }
}
