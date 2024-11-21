using Biblioteca.Dominio.Interfaces;
using Biblioteca.Dominio.Modelos;

namespace Biblioteca.Servicos
{
    public class ServicoLeitor
    {
        private readonly ILeitorRepositorio _leitorRepositorio;
        public ServicoLeitor(ILeitorRepositorio leitorRepositorio)
        {
            _leitorRepositorio = leitorRepositorio;
        }

        public void Criar(Leitor leitor)
        {
            _leitorRepositorio.Criar(leitor);
        }

        public void Editar(string id, Leitor leitor)
        {
            _leitorRepositorio.Editar(id, leitor);
        }

        public void Deletar(string id)
        {
            _leitorRepositorio.Deletar(id);
        }

        public Leitor ObterPorId(string id)
        {
            return _leitorRepositorio.ObterPorId(id);
        }

        public List<Leitor> ObterTodos()
        {
            return _leitorRepositorio.ObterTodos();
        }
    }
}
