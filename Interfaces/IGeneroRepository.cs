using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{
    /// <summary>
    /// Interface para Genero: Contrato
    /// toda classe que herder (Implementar) essa interface,deverá 
    /// implemenmtar todo os Métodos definidos aqui dentro 
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUND : Metodos 
        //C: Create : Cadastrar um novo Objeto 
        //R: Read : Listar todos os objetos 
        //U: Update : Alterar um objeto
        //D: Delete : Deleto ou Excluo um Objeto 

        //Método = tipoDeReetorno NomeDeMetodo(Argumnetos)

        void Cadastrar(Genero novoGenero);

        List<Genero> Listar();

        void Atualizar(Guid id, Genero genero);

        void Deletar (Guid id);

        Genero BuscarPorId(Guid id);
    }
}
