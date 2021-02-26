using GerenciadorCondominios.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Repositorios
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        private readonly Contexto _contexto;//Injeção de depêndencia, não preciso INTANCIAR  nossa classe para utiliza-la, basta passar seu valor via construtor como vamos fazer abaixo

        public RepositorioGenerico(Contexto contexto)//Agora graças ao nosso construtor nosso contexto está utilizavel 
        {
            _contexto = contexto;
        }
        public async Task Atualizar(TEntity entity)
        {
            try
            {
                _contexto.Set<TEntity>().Update(entity);//Atualizando a tabela
                await _contexto.SaveChangesAsync();//como nosso método é assincrono, precisamos utilizar wait para salvarmos nosso contexto
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(TEntity entity)
        {
            try
            {
                _contexto.Set<TEntity>().AddRange(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Excluir(int id)
        {
            var entity = await PegarPeloId(id);//Utilizamos a função pegar pelo id para identificar o elemento requerido
            _contexto.Set<TEntity>().Remove(entity);
            await _contexto.SaveChangesAsync();
        }

        public async Task Excluir(string id)
        {
            var entity = await PegarPeloId(id);//Utilizamos a função pegar pelo id para identificar o elemento requerido
            _contexto.Set<TEntity>().Remove(entity);
            await _contexto.SaveChangesAsync();
        }

        public async Task Inserir(TEntity entity)
        {
            try
            {
                await _contexto.AddAsync(entity);//a partir do parâmetro quem vem, entity consegue destinguir a qual tabela estamos nos referindo
                await _contexto.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<TEntity> PegarPeloId(int id)
        {
            try
            {
                return await _contexto.Set<TEntity>().FindAsync(id);//Retornamos o elemento pelo id 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> PegarPeloId(string id)
        {
            try
            {
                return await _contexto.Set<TEntity>().FindAsync(id);//Retornamos o elemento pelo id 
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> PegarTodos()
        {
            try
            {
                return await _contexto.Set<TEntity>().ToListAsync();//Retornar lista de elementos
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
