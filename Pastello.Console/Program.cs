using System;
using Pastello;

namespace Pastello.Console
{
    class Program
    {
        static IngredienteRepositorio repositorio = new IngredienteRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            {
                while (opcaoUsuario.ToUpper() != "X")
                {
                    switch (opcaoUsuario)
                    {
                        case "1":
                            ListarIngredientes();
                            break;
                        case "2":
                            InserirIngrediente();
                            break;
                        case "3":
                            AtualizarIngrediente();
                            break;
                        case "4":
                            ExcluirIngrediente();
                            break;
                        case "5":
                            VisualizarIngrediente();
                            break;
                        case "C":
                            System.Console.Clear();
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                            // TODO Ao invés de sair da aplicação, solicitar nova resposta
                    }

                    opcaoUsuario = ObterOpcaoUsuario();
                }
                System.Console.WriteLine("Obrigado por usar nossos serviços!");
            }

            static void ListarIngredientes()
            {
                System.Console.WriteLine("LISTA DE INGREDIENTES ATIVOS:");

                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    System.Console.WriteLine("Não há ingredientes cadastrados ativos!");
                    return;
                }

                foreach (var ingrediente in lista)
                {
                    var excluido = ingrediente.retornaExcluido();

                    // Foi necessário mudar o método apresentado pelo professor no projeto, talvez por conta da versão do framework - a dele é net core 3.1, e aqui uso net 5.
                    // Método conforme escrito pelo professor em 3.1:
                    // System.Console.WriteLine("#ID {0}: - {1} - {3}", ingrediente.retornaId(), ingrediente.retornaNome(), (excluido ? "*Excluido*" : ""));

                    if (!excluido)
                    {
                        System.Console.WriteLine($"#ID {ingrediente.retornaId()} - {ingrediente.retornaNome()}");
                    }
                    // Além da atualizar a forma de concatenação, dessa forma o método também deixa de listar itens excluídos, ao invés de apenas descrever a exclusão

                }
            }

            static void InserirIngrediente()
            {
                System.Console.WriteLine("NOVO CADASTRO:");

                foreach (int i in Enum.GetValues(typeof(Qualidade)))
                {
                    System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Qualidade), i));
                }
                System.Console.Write("Tipo/Qualidade: ");
                int entradaQualidade = int.Parse(System.Console.ReadLine());

                System.Console.Write("Nome do ingrediente: ");
                string entradaNome = System.Console.ReadLine();

                System.Console.Write("Custo do quilo: ");
                int entradaCustoKg = int.Parse(System.Console.ReadLine());

                System.Console.Write("Peso, em gramas, de 1 porção: ");
                int entradaPesoPorcao = int.Parse(System.Console.ReadLine());

                System.Console.Write("Custo de 1 porção: ");
                int entradaCustoPorcao = int.Parse(System.Console.ReadLine());

                Ingrediente novoIngrediente = new Ingrediente(id: repositorio.ProximoId(),
                                                                qualidade: (Qualidade)entradaQualidade,
                                                                nome: entradaNome,
                                                                custokg: entradaCustoKg,
                                                                pesoporcao: entradaPesoPorcao,
                                                                custoporcao: entradaCustoPorcao);

                repositorio.Insere(novoIngrediente);

                System.Console.WriteLine("");
                System.Console.WriteLine("Ingrediente cadastrado com sucesso!");

            }

            static void AtualizarIngrediente()
            {
                System.Console.Write("ID do ingrediente a atualizar: ");
                int indiceIngrediente = int.Parse(System.Console.ReadLine());

                foreach (int i in Enum.GetValues(typeof(Qualidade)))
                {
                    System.Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Qualidade), i));
                }
                System.Console.Write("Tipo/Qualidade: ");
                int entradaQualidade = int.Parse(System.Console.ReadLine());

                System.Console.Write("Nome do ingrediente: ");
                string entradaNome = System.Console.ReadLine();

                System.Console.Write("Custo do quilo: ");
                int entradaCustoKg = int.Parse(System.Console.ReadLine());

                System.Console.Write("Peso, em gramas, de 1 porção: ");
                int entradaPesoPorcao = int.Parse(System.Console.ReadLine());

                System.Console.Write("Custo de 1 porção: ");
                int entradaCustoPorcao = int.Parse(System.Console.ReadLine());
                // TODO transformar esse trecho em um método para ser reaproveitado por inserir e atualizar

                Ingrediente atualizaIngrediente = new Ingrediente(id: indiceIngrediente,
                                                                qualidade: (Qualidade)entradaQualidade,
                                                                nome: entradaNome,
                                                                custokg: entradaCustoKg,
                                                                pesoporcao: entradaPesoPorcao,
                                                                custoporcao: entradaCustoPorcao);

                repositorio.Atualiza(indiceIngrediente, atualizaIngrediente);

                System.Console.WriteLine("");
                System.Console.WriteLine("Ingrediente atualizado com sucesso!");
            }

            static void ExcluirIngrediente()
            {
                System.Console.Write("ID do ingrediente: ");
                int indiceIngrediente = int.Parse(System.Console.ReadLine());

                // TODO incluir confirmação de exclusão

                repositorio.Exclui(indiceIngrediente);

                System.Console.WriteLine("");
                System.Console.WriteLine("Ingrediente excluído!");
            }

            static void VisualizarIngrediente()
            {
                System.Console.Write("ID do ingrediente: ");
                int indiceIngrediente = int.Parse(System.Console.ReadLine());

                var ingrediente = repositorio.RetornaPorId(indiceIngrediente);

                System.Console.WriteLine(ingrediente);
            }

            static string ObterOpcaoUsuario()
            {
                System.Console.WriteLine();
                System.Console.WriteLine("MR. PASTELLO ao seu dispor");
                System.Console.WriteLine("Manda a braba: o que quer fazer?");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Listar ingredientes ativos");
                System.Console.WriteLine("2. Cadastrar novo ingrediente");
                System.Console.WriteLine("3. Atualizar cadastro de ingrediente");
                System.Console.WriteLine("4. Excluir ingrediente");
                System.Console.WriteLine("5. Visualizar ingrediente");
                System.Console.WriteLine("C. Limpar tela");
                System.Console.WriteLine("X. Sair");
                System.Console.WriteLine();

                string opcaoUsuario = System.Console.ReadLine().ToUpper();
                System.Console.WriteLine();
                return opcaoUsuario;
            }
        }
    }
}
