using System;

namespace DIOFLIX
{
    class Program
    {
       static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = obterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                       inserirSerie();
                       break;

                    case "2":
                        excluirSerie();
                        break;

                    case "3":
                       listarSeries();
                       break;

                    case "4" :
                       visualizarSerie();
                        break;

                    case "5":
                        atualizarSerie();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();                       
                }
            opcaoUsuario = obterOpcaoUsuario();    
            }
        }
        private static string obterOpcaoUsuario ()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo a DIOFLIX!");
            Console.WriteLine("Informe a opcao desejada:");
            Console.WriteLine("1 - Inserir nova serie.");
            Console.WriteLine("2 - Excluir serie.");
            Console.WriteLine("3 - Listar serie(s).");
            Console.WriteLine("4 - Visualizar serie(s).");
            Console.WriteLine("5 - Atualizar serie.");
            Console.WriteLine("C - Limpar tela.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;            
        }
        private static void inserirSerie()
            {
              Console.WriteLine("Inserir nova serie! ");

               foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.Write("Escolha um dos gêneros acima: ");
            int opcaoGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o titulo da serie: ");
            string opcaoTitulo = Console.ReadLine();

            Console.Write("Informe o ano de inicio da serie: ");
            int anoInicio = int.Parse(Console.ReadLine());

            Console.Write("Informe a descricao da serie: ");
            string opcaoDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: repositorio.proximoId(),
                                          genero: (Genero)opcaoGenero,
                                          titulo: opcaoTitulo,
                                          ano: anoInicio,
                                          descricao: opcaoDescricao);

            repositorio.inserir(novaSerie);                              
        }
         private static void excluirSerie()
         {
             Console.Write("Informe o ID da serie desejada: ");
             int idEscolha = int.Parse(Console.ReadLine());

             repositorio.excluir(idEscolha);
         } 
        private static void listarSeries()
        {
            Console.WriteLine("Lista de series:");

            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada!");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornarExcluido();
                Console.WriteLine("#ID {0} - {1} - {2}", serie.retornarId(), serie.retornarTitulo(), (excluido ? "*Excluido*" : " "));
            }
        }
          private static void visualizarSerie()
         {
             Console.Write("Informe o ID da serie desejada: ");
             int idEscolha = int.Parse(Console.ReadLine());

             var serie = repositorio.retornarPorId(idEscolha);

             Console.WriteLine(serie);
         }
         private static void atualizarSerie()
        {
             Console.Write("Informe o ID da serie desejada: ");
             int idEscolha = int.Parse(Console.ReadLine());

             foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine();
            Console.Write("Escolha um dos gêneros acima: ");
            int opcaoGenero = int.Parse(Console.ReadLine());

            Console.Write("Informe o titulo da serie: ");
            string opcaoTitulo = Console.ReadLine();

            Console.Write("Informe o ano de inicio da serie: ");
            int anoInicio = int.Parse(Console.ReadLine());

            Console.Write("Informe a descricao da serie: ");
            string opcaoDescricao = Console.ReadLine();

            Series novaSerie = new Series(id: idEscolha,
                                          genero: (Genero)opcaoGenero,
                                          titulo: opcaoTitulo,
                                          ano: anoInicio,
                                          descricao: opcaoDescricao);

            repositorio.atualizar(idEscolha, novaSerie);
         }     
    }
}