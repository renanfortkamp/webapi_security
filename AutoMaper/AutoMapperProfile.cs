using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using webapi_security.Dto;
using webapi_security.Models;

namespace webapi_security.AutoMaper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<FuncionarioRequest, Funcionario>();
            CreateMap<Funcionario, FuncionarioRequest>().AfterMap((src, dest) =>
            {
                dest.Nome = src.Nome;
                dest.Email = src.Email;
                dest.Senha = src.Senha;
                dest.Salario = src.Salario;
                dest.PermissaoId = src.PermissaoId;
                
            });
            CreateMap<AlterarSalario, Funcionario>();
            CreateMap<Funcionario, NomePermissao>().AfterMap((src, dest) =>
            {
                dest.Nome = src.Nome;
                switch (src.PermissaoId)
                {
                    case 1:
                        dest.Permissao = "Funcionario";
                        break;
                    case 2:
                        dest.Permissao = "Gerente";
                        break;
                    case 3:
                        dest.Permissao = "Administrador";
                        break;
                }
            });

        }
    }
}