using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi_security.Dto
{
    public class AlterarSalario
    {
        [Column("salario")]
        public decimal Salario { get; set; } 
    }
}