using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorCondominios.Extensions
{
    public static class ConfiguracaoCookiesExtension
    {
        public static void ConfigurarCookies(this IServiceCollection service)
        {
            service.ConfigureApplicationCookie(opcoes =>
            {
                opcoes.Cookie.Name = "IdentityCookie";
                opcoes.Cookie.HttpOnly = true;
                opcoes.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                opcoes.LoginPath = "/Usuarios/Login";
                opcoes.AccessDeniedPath = "/Usuarios/AcessoNegado";
            });
        }
    }
}