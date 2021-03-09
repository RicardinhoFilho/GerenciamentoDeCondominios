using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Repositorios
{
    public class FuncaoRepositorio :  RepositorioGenerico<Funcao>, IFuncaoRepositorio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IFuncaoRepositorio _funcaoRepositorio;
        public FuncaoRepositorio(IUsuarioRepositorio usuarioRepositorio,  Contexto contexto) : base(contexto)
        {

        }
    }
}
