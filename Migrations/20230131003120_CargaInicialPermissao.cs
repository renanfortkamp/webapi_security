using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapisecurity.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialPermissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                                 "INSERT " +
                                 "INTO Permissao" +
                                     "(nome) " +
                                 "VALUES" +
                                     "('Funcionario')," +
                                     "('Gerente')," +
                                     "('Administrador')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
