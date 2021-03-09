using GerenciadorCondominios.BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario>
    {
        int VerificarSeExisteRegistro();//Verifica se já existema algum usuário em nosso banco de dados, pois neste caso se não existir o primeiro usuário cadatrado em nosso sistema se torna administrador(regra de negócio deste sistema), e é o administrador quem libera acesso para outros usuáriios
        Task LogarUsuario(Usuario usuario, bool lembrar);//Rcebe como paramêtro o próprio usuário e a opçao de "lembrar de mim" ou não
        Task DeslogarUsuario();
        Task<IdentityResult> CriarUsuario(Usuario usuario, string senha);
        Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao);

        Task<Usuario> PegarUsuarioPeloEmail(string email);

        Task AtualizarUsuario(Usuario usuario);

        Task<bool> VerificarSeUsuarioPossuiFuncao(Usuario usuario, string funcao);

        Task<IEnumerable<string>> PegarFuncoesUsuario(Usuario usuario);
        Task<IdentityResult> RemoverFuncoesUsuario(Usuario usuario, IEnumerable<string> funcoes);
        Task<IdentityResult> IncluirUsuarioEmFuncoes(Usuario usuario, IEnumerable<string> funcoes);
    
    
    
    
    
    }
}
