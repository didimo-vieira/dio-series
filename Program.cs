using System;

namespace dio.series
{
    class Program
    {
        static RepositorioSeries repositorio = new RepositorioSeries();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while ( opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSeries();
                        break;
                    case "3":
                        AtualizarSeries();
                        break;
                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                        VisualizarSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;                                            

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Agradecemos por prestigiar nossoa plataforma.");
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da série:");
            int indiceSeries = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSeries);
        }

        private static void VisualizarSeries()
        {
            Console.Write("Digite o id da série:");
            int indiceSeries = int.Parse(Console.ReadLine());

            var Serie = repositorio.RetornaPorId(indiceSeries);

            Console.WriteLine(Serie);
        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da série:");
            int indiceSeries = int.Parse(Console.ReadLine());

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero descrito nas opções existentes:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título de acordo com o gênero escolhido:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSeries = new Serie(id: indiceSeries,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);

            repositorio.Atualiza(indiceSeries, atualizaSeries);                                                        
        }
        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série cadastrada.");
                return;
            }    

            foreach (var Serie in lista)
            {
                var excluido = Serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", Serie.retornaId(), Serie.retornaTitulo(), (excluido ? "*Excluída*" : ""));
            }
        }

        private static void InserirSeries()
        {
            Console.WriteLine("Inserir nova Série");
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} -{1}", i, Enum.GetName(typeof(Genero), i));
            }   
            Console.Write("Digite o gênero descrito nas opções existentes:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título de acordo com o gênero escolhido:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da Série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série:");
            string entradaDescricao = Console.ReadLine();

            Serie novoSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novoSerie);                                                        
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DIO Series!");
            Console.WriteLine("Selecione uma opção:");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("2 - Inserir nova Série");
            Console.WriteLine("3 - Atualizar Série");
            Console.WriteLine("4 - Excluir Série");
            Console.WriteLine("5 - Visualizar Série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        } 
    }      
}