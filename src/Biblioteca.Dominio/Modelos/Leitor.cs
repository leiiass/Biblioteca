namespace Biblioteca.Dominio.Modelos
{
    public class Leitor
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public List<string> GenerosPreferido { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
