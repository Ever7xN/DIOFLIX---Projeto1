using System.Collections.Generic;

namespace DIOFLIX
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T retornarPorId(int id);
         void inserir(T entidade);
         void excluir(int id);
         void atualizar(int id, T entidade);
         int proximoId();        
    }
}