using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_security.Dto
{
    public class FuncionarioRequest
    {
        [Column("nome")]
        public string Nome { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("salario")]
        public decimal Salario { get; set; }

        [Column("permissaoId")]
        public int PermissaoId { get; set; }
    }
}
