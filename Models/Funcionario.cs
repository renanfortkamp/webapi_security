using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_security.Models
{
    public class Funcionario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("salario")]
        public decimal Salario { get; set; }

        [Column("email")]
        public string Email { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        public  Permissao Permissao { get; set; }

        [Column("permissaoId")]
        public int PermissaoId { get; set; }
    }
}