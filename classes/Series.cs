using System;

namespace DIOFLIX
{
    public class Series : EntidadeBase
    {
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        private Genero Genero { get; set; }
        public Series(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }
        public override string ToString()
        {
           string retorno = "";
           retorno += "Gênero: " + Genero + Environment.NewLine;
           retorno += "Titulo: " + Titulo + Environment.NewLine;
           retorno += "Descricao: " + Descricao + Environment.NewLine;
           retorno += "Ano de inicio: " + Ano + Environment.NewLine;
           return retorno;
        }
        public int retornarId()
        {
            return Id;
        }
        public string retornarTitulo()
        {
            return Titulo;
        }
        public void excluir()
        {
            Excluido = true;
        } 
         public bool retornarExcluido()
        {
            return Excluido;
        }     
    }
}