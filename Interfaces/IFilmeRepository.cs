using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{
    public interface IFilmeRepository

    {
        void Cadastrar(Filme novoFilme);

        List<Filme> Listar();

        void Atulizar(Guid id, Filme filme);

        void Deletar (Guid id); 
        Filme BuscarPorId(Guid id);
        void Atualizar(Guid id, Genero genero);
       List<Filme> ListarPorGenero(Guid idGenero);
    }
}
