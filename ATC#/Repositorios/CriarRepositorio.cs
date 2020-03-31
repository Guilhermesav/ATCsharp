using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using Repositorios.Interface;
using Repositorios.List;
using Repositorios.LinkedList;
using Repositorios.Tipos;

namespace Repositorios.CriarRepositorio
{
    public class CriarRepositorio
    {
        static void Main(string[] args)
        {

        }
        public static IAmigoRepositorio Criar()
        {
            return Criar(TipoRepositorio.List);
        }

        public static IAmigoRepositorio Criar(TipoRepositorio tipoRepositorio)
        {
            switch (tipoRepositorio)
            {
                case TipoRepositorio.List:
                    return new List.AmigoListRepositorio();
                case TipoRepositorio.LinkedList:
                    return new LinkedList.AmigoLinkedListRepositorio();
                default:
                    throw new NotImplementedException("Não existe repositório padrão!");
            }
        }
    }
}
