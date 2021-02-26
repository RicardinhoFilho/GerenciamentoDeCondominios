using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Interfaces
{
    //Interface Genérica responsável por garantir a implementação dos métodos abaixo em cada uma de nossas classes(Usuario, Veículo...)
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> PegarTodos();
        Task<TEntity> PegarPeloId(int id);//Possuimos id do tipo inteiro 
        Task<TEntity> PegarPeloId(string id);//Possuimos id do tipo string
        Task Inserir(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Excluir(int id);
        Task Excluir(string id);
    }
}
