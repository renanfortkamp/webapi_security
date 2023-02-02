using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi_security.Models;

namespace webapi_security.Context
{
    public class RhContext : DbContext
    {
        public RhContext(DbContextOptions<RhContext> options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
       
        
    }
}