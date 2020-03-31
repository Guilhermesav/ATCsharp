using System;
using System.Collections.Generic;
using System.Linq;
using Dominio;
using Repositorios;
using Repositorios.CriarRepositorio;
using Repositorios.Interface;
using Repositorios.LinkedList;
using Repositorios.List;
using Repositorios.Tipos;

namespace Tp3Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string escolha;
            var repositorio = CriarRepositorio.Criar();
            do
            {

                repositorio.NiverDoDia(DateTime.Today);

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("A. Pesquisar amigos");
                Console.WriteLine("B. Adicionar amigo");
                Console.WriteLine("C. Deletar amigo");
                Console.WriteLine("D. Sair");
                escolha = Console.ReadLine();
                escolha.ToLower();
                if (escolha == "a")
                {
                    Console.WriteLine("Escreva o nome da pessoa");
                    string nomePessoa = Console.ReadLine();
                    var resultadoPesquisa = repositorio.Pesquisar(nomePessoa);
                    if (resultadoPesquisa.Count == 0)
                    {
                        Console.WriteLine("Pessoa não encontrada");
                        Console.WriteLine("Retorando ao menu...");
                    }
                    if (resultadoPesquisa.Count > 0)
                    {
                        Console.WriteLine($"Informe o número do Amigo que deseja ver:");
                        for (var index = 0; index < resultadoPesquisa.Count; index++)
                            Console.WriteLine($"{index} - amigo: {resultadoPesquisa[index].Nome}");

                        ushort indexAExibir;
                        if (!ushort.TryParse(Console.ReadLine(), out indexAExibir) || indexAExibir >= resultadoPesquisa.Count)
                        {
                            Console.WriteLine($"Opcao inválida!");

                            break;
                        }

                        if (indexAExibir < resultadoPesquisa.Count)
                        {
                            var amigo = resultadoPesquisa[indexAExibir];

                            var aniversario = amigo.JaFezAniversario();

                            Console.WriteLine("Dados do Amigo:");
                            Console.WriteLine($"Nome: {amigo.Nome}");
                            Console.WriteLine($"Sobrenome: {amigo.SobreNome}");
                            Console.WriteLine($"Data de nascimento:{amigo.DataNascimento}");
                            Console.WriteLine($"{aniversario}");
                            Console.WriteLine("Deseja alterar as informações deste amigo? (s/n)");
                            var confAlt = Console.ReadLine();
                            confAlt.ToLower();
                            if (confAlt == "s")
                            {
                                Console.WriteLine("Qual informação deseja alterar?");
                                Console.WriteLine("A. Nome");
                                Console.WriteLine("B. Sobrenome");
                                Console.WriteLine("C. Data de Nascimento");
                                Console.WriteLine("D. Não desejo fazer alterações");
                                var opAlteracao = Console.ReadLine();
                                opAlteracao.ToLower();
                                switch (opAlteracao)
                                {
                                    case "a":
                                        {
                                            Console.WriteLine($"Nome atual:{amigo.Nome}");
                                            Console.WriteLine("Insira o novo nome:");
                                            string novoNome = Console.ReadLine();
                                            repositorio.EditNome(amigo, novoNome);
                                            Console.WriteLine("Nome Alterado, retornando ao menu princpial");
                                            break;
                                        }
                                    case "b":
                                        {
                                            Console.WriteLine($"Nome atual:{amigo.Nome}");
                                            Console.WriteLine("Insira o novo nome:");
                                            string novoSobrenome = Console.ReadLine();
                                            repositorio.EditNome(amigo, novoSobrenome);
                                            Console.WriteLine("Sobrenome Alterada, retornando ao menu princpial");
                                            break;
                                        }
                                    case "c":
                                        {
                                            Console.WriteLine($"Nome atual:{amigo.Nome}");
                                            Console.WriteLine("Insira o novo nome:");
                                            string novaDataNascimento = Console.ReadLine();
                                            Convert.ToDateTime(novaDataNascimento);
                                            repositorio.EditNome(amigo, novaDataNascimento);
                                            Console.WriteLine("Data de Nascimento alterada, retornando ao menu princpial");
                                            break;
                                        }
                                    case "d":
                                        {
                                            Console.WriteLine("Edição cancelada, retornando ao menu principal");
                                            break;
                                        }
                                }
                            }
                            else if (confAlt == "n")
                            {
                                Console.WriteLine("Retornando ao menu principal, pressione qualquer tecla");
                                Console.ReadKey();
                                break;
                            }
                            Console.WriteLine("Pressione qualquer tecla para sair");
                            Console.ReadKey();
                        }
                    }
                }
                if (escolha == "b")
                {
                    Console.WriteLine("Escreva o nome do amigo que deseja adicionar:");
                    string nomeAmigo = Console.ReadLine();

                    Console.WriteLine("Escreva o sobrenome do amigo que deseja adicionar:");
                    string sobrenomeAmigo = Console.ReadLine();

                    Console.WriteLine("Insira a data de nascimento da pessoa:");
                    string dataNiver = Console.ReadLine();

                    var niverDateTime = Convert.ToDateTime(dataNiver);

                    Console.WriteLine($"Nome completo:{nomeAmigo + sobrenomeAmigo}");
                    Console.WriteLine($"Data de Nascimento: {niverDateTime}");
                    Console.WriteLine("Confirmar informações?");
                    Console.WriteLine("Pressione s para SIM e n para NÃO");
                    var confirmacao = Console.ReadLine();
                    confirmacao.ToLower();
                    if (confirmacao == "s")
                    {
                        var amigo = new Amigo(nomeAmigo, sobrenomeAmigo, niverDateTime);

                        repositorio.Adicionar(amigo);

                        Console.WriteLine("Amigo adicionado");
                        Console.WriteLine("Voltando ao menu principal");

                    }
                    else if (confirmacao == "n")
                    {
                        Console.WriteLine("Dados descartados");
                        Console.WriteLine("Voltando ao menu principal");
                    }
                    else
                    {
                        Console.WriteLine("Opção invalida");
                        Console.WriteLine("Voltando ao menu principal");
                    }
                }
                if (escolha == "C")
                {
                    Console.WriteLine("Escreva o nome da pessoa");
                    string nomePessoa = Console.ReadLine();
                    List<Amigo> resultadoPesquisa = repositorio.Pesquisar(nomePessoa);
                    if (resultadoPesquisa.Count == 0)
                    {
                        Console.WriteLine("Pessoa não encontrada");
                        Console.WriteLine("Retorando ao menu...");
                    }
                    if (resultadoPesquisa.Count > 0)
                    {
                        Console.WriteLine($"Informe o número do amigo que deseja deletar para exibir os seus detalhes:");
                        for (var index = 0; index < resultadoPesquisa.Count; index++)
                            Console.WriteLine($"{index} - amigo: {resultadoPesquisa[index].Nome}");

                        ushort indexAExibir;
                        if (!ushort.TryParse(Console.ReadLine(), out indexAExibir) || indexAExibir >= resultadoPesquisa.Count)
                        {
                            Console.WriteLine($"Opcao inválida!");

                            break;
                        }

                        if (indexAExibir < resultadoPesquisa.Count)
                        {
                            var amigoAExibir = resultadoPesquisa[indexAExibir];

                            var aniversario = amigoAExibir.JaFezAniversario();

                            Console.WriteLine("Dados do amigo:");
                            Console.WriteLine($"Nome: {amigoAExibir.Nome}");
                            Console.WriteLine($"Sobrenome: {amigoAExibir.SobreNome}");
                            Console.WriteLine($"Data de nascimento:{amigoAExibir.DataNascimento}");

                            Console.WriteLine("Deseja deletar este amigo?:");
                            Console.WriteLine("Pressione s para SIM e n para NÃO");
                            var confirmacao = Console.ReadLine();
                            confirmacao.ToLower();
                            if (confirmacao == "s")
                            {
                                Console.WriteLine("Este amigo será deletado");
                                repositorio.Delete(amigoAExibir);

                                Console.WriteLine("Pressione qualquer tecla para retonar ao menu principal");
                                Console.ReadKey();
                                break;
                            }
                            else if (confirmacao == "n")
                            {
                                Console.WriteLine("Este amigo não será deletado");

                                Console.WriteLine("Pressione qualquer tecla para retonar ao menu principal");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Opção Invalida");
                                Console.WriteLine("Pressione qualquer tecla para retonar ao menu principal");
                                Console.ReadKey();
                            }

                        }
                    }
                }
                if (escolha == "d")
                {
                    Console.WriteLine("Finalizando o programa");
                }
            } while (escolha != "d");

        }


    }
}
