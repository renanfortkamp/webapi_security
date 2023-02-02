using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapisecurity.Migrations
{
    /// <inheritdoc />
    public partial class CargaInicialFuncionarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                                 "INSERT " +
                                 "INTO Funcionarios" +
                                     "(nome,salario, email, senha, permissaoId) " +
                                 "VALUES" +
                                     "('Funcionário',12546.00, 'funcionario@glass.com.br', 'funcionario123',  1)," +
                                     "('Gerente',23453.89,  'gerente@glass.com.br','gerente123',  2)," +
                                     "('Administrador',36453.34,  'adm@glass.com.br','adm123',  3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
