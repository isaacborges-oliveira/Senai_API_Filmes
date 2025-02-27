using api_filmes_senai.Context;
using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api_filmes_senai.Repositories
{
    /// <summary>
    /// Classe que vai implementar a interface IGeneroRepository
    /// Ou seja vamos implementar os métodos, toda a lógica dos métodos
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        private readonly Filmes_Context _context;

        /// <summary>
        /// Contrutor do repositorio 
        /// Aqui toda vez que o contrutor for chamado ,
        /// os dados do contexto estarão disponiveis
        /// </summary>
        /// <param name="contexto"></param>
        public GeneroRepository(Filmes_Context contexto)
        {
            _context = contexto;
        }


        
        public Genero BuscarPorId(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                return generoBuscado;
            }
            catch (Exception)
            {

                throw;
            }

        }



        public void Cadastrar(Genero novoGenero)
        {
            try
            {
                _context.Genero.Add(novoGenero);

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }


        }
        public void Deletar(Guid id)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;
                if (generoBuscado != null)
                {
                    _context.Genero.Remove(generoBuscado);
                }
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Genero> Listar()
        {
            try
            {
                List<Genero> listaGenero = _context.Genero.ToList();
                return listaGenero;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Atualizar(Guid id, Genero genero)
        {
            try
            {
                Genero generoBuscado = _context.Genero.Find(id)!;

                if (generoBuscado != null)
                {
                    generoBuscado.Nome  = genero.Nome;
                   
                }

                _context.SaveChanges();
            }
            catch (Exception )
            {
                throw;
            }
        }
    }
}
