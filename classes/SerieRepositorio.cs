using System.Collections.Generic;

namespace DIOFLIX
{
    public class SerieRepositorio : IRepositorio<Series>
    {
        private List<Series> listaSeries = new List<Series>();
        public void atualizar(int id, Series entidade)
        {
            listaSeries[id] = entidade;
        }
        public void excluir(int id)
        {
            listaSeries[id].excluir();
        }
        public void inserir(Series entidade)
        {
            listaSeries.Add(entidade);
        }
        public List<Series> Lista()
        {
            return listaSeries;
        }
        public int proximoId()
        {
            return listaSeries.Count;
        }
        public Series retornarPorId(int id)
        {
            return listaSeries[id];
        }
    }
}