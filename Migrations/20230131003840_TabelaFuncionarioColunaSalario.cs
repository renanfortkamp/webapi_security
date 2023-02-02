using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapisecurity.Migrations
{
    /// <inheritdoc />
    public partial class TabelaFuncionarioColunaSalario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "salario",
                table: "Funcionarios",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salario",
                table: "Funcionarios");
        }
    }
}
