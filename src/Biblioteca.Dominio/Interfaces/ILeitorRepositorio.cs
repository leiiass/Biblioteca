using Biblioteca.Dominio.Modelos;

namespace Biblioteca.Dominio.Interfaces
{
    public interface ILeitorRepositorio
    {
        void Criar(Leitor leitor);
        void Editar(string Id, Leitor leitor);
        void Deletar(string Id);
        Leitor ObterPorId(string Id);
        List<Leitor> ObterTodos();
    }
}
