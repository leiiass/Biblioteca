using Biblioteca.Dominio.Interfaces;
using Biblioteca.Dominio.Modelos;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Biblioteca.Infraestrutura.Repositorios
{
    public class LeitorRepositorio : ILeitorRepositorio
    {
        private readonly IDocumentStore _documentStore;
        public LeitorRepositorio(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }

        public void Criar(Leitor leitor)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            documentSession.Store(leitor);
            documentSession.SaveChanges();
        }

        public void Deletar(string Id)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var leitor = documentSession.Load<Leitor>(Id);
            documentSession.Delete(leitor);
        }

        public void Editar(string Id, Leitor leitor)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var leitorAhSerEditado = documentSession.Load<Leitor>(Id);
            if(leitorAhSerEditado is not null)
            {
                leitorAhSerEditado.Nome = leitor.Nome;
                leitorAhSerEditado.GenerosPreferido = leitor.GenerosPreferido;
                leitorAhSerEditado.Livros = leitor.Livros;
            }
            documentSession.SaveChanges();
        }

        public Leitor ObterPorId(string Id)
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            var leitor = documentSession.Load<Leitor>(Id);
            return leitor;
        }

        public List<Leitor> ObterTodos()
        {
            using IDocumentSession documentSession = _documentStore.OpenSession();
            return documentSession.Query<Leitor>().ToList();
        }
    }
}
