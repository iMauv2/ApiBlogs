using Blogs.Data;
using Blogs.Enum;
using Blogs.Models;
using Microsoft.AspNetCore.Mvc;

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

        public void UpdateEntrada()
        {
            _context.SaveChanges();
        }

        [HttpGet]
        public List<Entrada> GetEntradasByEstado(string estadoEntrada)
        {
            return _context.Entrada.Where(p => p.estado == estadoEntrada).ToList();
        }

        [HttpGet]
        public Entrada GetEntradaById(int id)
        {
            return _context.Entrada.First(p => p.id == id);
        }

        //public bool EntradaExiste(string entrada)
        //{
        //    return _context.Entradas.Any(p => p. == entrada);
        //}
    }
}
