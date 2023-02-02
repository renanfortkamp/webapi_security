using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_security.Models;

namespace webapi_security.Services
{
    public interface ITokenService
    {
        string GerarToken(Funcionario funcionario);
        
    }
}