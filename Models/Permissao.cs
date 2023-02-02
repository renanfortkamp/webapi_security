using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_security.Models
{
    public class Permissao
    {
        [Column("id")]
        public int Id {get;set;}
        
        [Column("nome")]
        public string Nome {get;set;}


    }
}