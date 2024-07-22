using Blogs.Data;
using Blogs.Models;

namespace Blogs.Repository
{
    public class EntradaRepository
    {
        private readonly DataContext _context;

        public EntradaRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public void SaveEntrada(Entrada entrada)
        {
            _context.Entrada.Add(entrada);
            _context.SaveChanges();
        }

        //public bool EntradaExiste(string entrada)
        //{
        //    return _context.Entradas.Any(p => p. == entrada);
        //}
    }
}
