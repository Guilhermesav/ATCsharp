using System;
using System.Collections.Generic;
using Dominio;
using System.Text;
using Repositorios;

namespace Repositorios.Interface
{
    public interface IAmigoRepositorio
    {
        List<Amigo> Pesquisar(string termoDePesquisa);

        void NiverDoDia(DateTime hoje);

        void Adicionar(Amigo amigo);
        void Delete(Amigo amigo);

        void EditNome(Amigo amigo,string novoNome);

        void EditSobrenome(Amigo amigo, string novoSobrenome);

        void EditDataNascimento(Amigo amigo,string novaDataNascimento);
    }
}
