using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Dominio;
using System.IO;
using Repositorios.Interface;
using Repositorios.Tipos;

namespace Repositorios.List

{
    public class AmigoListRepositorio : IAmigoRepositorio
    {
        private static List<Amigo> amigoLista = new List<Amigo>();
        private const string Arquivo = @"C:\Users\PICHAU\Desktop\FAculdade\amigos.txt";

        public AmigoListRepositorio()
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

                amigoLista.Add(amigo);
            }
        }

        public List<Amigo> Pesquisar(string termoDePesquisa)
        {
            return amigoLista.Where(x => x.Nome.ToUpper().Contains(termoDePesquisa.ToUpper())).ToList();
        }
        public void Adicionar(Amigo amigo)
        {
            amigoLista.Add(amigo);
            File.WriteAllLines(Arquivo, amigoLista.Select(carro => carro.ToString()));
        }

        public void Delete(Amigo amigo)
        {
            amigoLista.Remove(amigo);
            File.WriteAllLines(Arquivo, amigoLista.Select(amigo => amigo.ToString()));
        }

        public void EditNome(Amigo amigo, string novoNome)
        {
            var infoAmigo = amigo;
            amigo.Nome = novoNome;
            File.WriteAllLines(Arquivo, amigoLista.Select(amigo => amigo.ToString()));
        }
        public void EditSobrenome(Amigo amigo, string novoSobrenome)
        {
            var infoAmigo = amigo;
            amigo.SobreNome = novoSobrenome;
            File.WriteAllLines(Arquivo, amigoLista.Select(amigo => amigo.ToString()));
        }
        public void EditDataNascimento(Amigo amigo, string novaData)
        {
            var infoAmigo = amigo;
            var novaDataDateTime = Convert.ToDateTime(novaData);
            amigo.DataNascimento = novaDataDateTime;
            File.WriteAllLines(Arquivo, amigoLista.Select(amigo => amigo.ToString()));
        }

        public void NiverDoDia(DateTime hoje)
        {
            foreach(var amigo in amigoLista)
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


