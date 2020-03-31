using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Repositorios.Interface;
using Repositorios.CriarRepositorio;
using Repositorios.Tipos;
using Dominio;

namespace Repositorios.LinkedList
{
    public class AmigoLinkedListRepositorio : IAmigoRepositorio
    {
        private static LinkedList<Amigo> amigoLista = new LinkedList<Amigo>();
        private const string Arquivo = @"C:\Users\PICHAU\Desktop\FAculdade\amigos.txt";

        public AmigoLinkedListRepositorio()
        {
            CarregarLista();
        }


        private void CarregarLista()
        {
            if (!File.Exists(Arquivo))
                File.Create(Arquivo).Close();

            var linhas = File.ReadAllLines(Arquivo);

            foreach (var linha in linhas)
            {
                var info = linha.Split("|");

                var dataNascimento = DateTime.Parse(info[2]);
                var amigo = new Amigo(info[0], info[1], dataNascimento);

                amigoLista.AddFirst(amigo);
            }
        }

        public List<Amigo> Pesquisar(string termoDePesquisa)
        {
            return amigoLista.Where(x => x.Nome.ToUpper().Contains(termoDePesquisa.ToUpper()))                                          
                                                         .ToList();
        }
      

        public void Adicionar(Amigo amigo)
        {
            amigoLista.AddFirst(amigo);
            File.WriteAllLines(Arquivo, amigoLista.Select(carro => carro.ToString()));
        }

        public void Delete(Amigo amigo)
        {
            amigoLista.Remove(amigo);
            File.WriteAllLines(Arquivo, amigoLista.Select(amigo => amigo.ToString()));
        }
        public void EditNome(Amigo amigo,string novoNome)
        {
            var infoAmigo = amigo;
            Console.WriteLine("Insira o novo nome");
            novoNome = Console.ReadLine();
            amigo.Nome = novoNome;
            File.WriteAllLines(Arquivo, amigoLista.Select(amigo => amigo.ToString()));
        }
        public void EditSobrenome(Amigo amigo, string novoSobrenome)
        {
            var infoAmigo = amigo;
            Console.WriteLine("Insira o novo nome");
            novoSobrenome = Console.ReadLine();
            amigo.SobreNome = novoSobrenome;
            File.WriteAllLines(Arquivo, amigoLista.Select(amigo => amigo.ToString()));
        }
        public void EditDataNascimento(Amigo amigo, string novaData)
        {
            var infoAmigo = amigo;
            Console.WriteLine("Insira o novo nome");
            novaData = Console.ReadLine();
            var novaDataDateTime = Convert.ToDateTime(novaData);
            amigo.DataNascimento = novaDataDateTime;
            File.WriteAllLines(Arquivo, amigoLista.Select(amigo => amigo.ToString()));
        }
        public void NiverDoDia(DateTime hoje)
        {
            foreach (var amigo in amigoLista)
            {
                Console.WriteLine("Aniversariantes do dia:");
                if (DateTime.Today.DayOfYear - amigo.DataNascimento.DayOfYear == 0)
                {
                    Console.WriteLine($"{amigo}");

                }
            }

        }

    }
}
