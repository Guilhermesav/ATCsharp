using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Amigo
    {
        static void Main(string[] args)
        {

        }
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DateTime DataNascimento { get; set; }


        public Amigo(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            SobreNome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public string JaFezAniversario()
        {
            int testeAniversario = DateTime.Today.DayOfYear - DataNascimento.DayOfYear;
          
            if(testeAniversario < 0)
            {
                testeAniversario = testeAniversario * -1;
                testeAniversario.ToString();
                string preAniversario = $"Este aniversario ainda não chegou, faltam {testeAniversario} dias para esse aniversario";
                return preAniversario;
                
            }
            if (testeAniversario > 0)
            {
                string posAniversario = "Este aniversario já passou";

                return posAniversario;

            }
            if(testeAniversario == 0)
            {
                string aniversarioHoje = "Dê parabéns ao seu amigo, o aniversário dele é hoje";
                return aniversarioHoje;
            }
            return null;
        }

        public override string ToString()
        {
            return $"{Nome}|{SobreNome}|{DataNascimento}";
        }


    }
}
