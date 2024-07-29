using Blogs.Data;
using Blogs.Interfaces;
using Blogs.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Repository
{
    public class UsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public Usuario GetUsuario(string nombreUsuario)
        {
            Usuario usuario = _context.Usuario.Where(p => p.nombre == nombreUsuario).FirstOrDefault();

            return usuario;
        }

        //[HttpGet]
        public List<Usuario> GetAllUsuarios()
        {
            return _context.Usuario.ToList();
        }

        public void SaveUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public bool UsuarioExiste(string nombreUsuarioNuevo)
        {
            return _context.Usuario.Any(p => p.nombre == nombreUsuarioNuevo);
        }
    }
}
