﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.Extensions
{
    public static class ConfiguracaoIdentityExtension
    {
        public static void ConfigurNomeUuario(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(opcoes =>
            {
                opcoes.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                opcoes.User.RequireUniqueEmail = true;//Não podemkos ter email repetidos em nosso banco de dados
            });
        }
        public static void ConfigurarSemnhaDoUsuario(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(opcoes =>
            {
                opcoes.Password.RequireDigit = true;
                opcoes.Password.RequireLowercase = true;
                opcoes.Password.RequiredLength = 8;
                opcoes.Password.RequireNonAlphanumeric = true;
                opcoes.Password.RequireUppercase = true;
                opcoes.Password.RequiredUniqueChars = 0;//posso ter caracteres repetidos.
            });
        }
    }
}