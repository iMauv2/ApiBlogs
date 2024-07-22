using Blogs.Data;
using Blogs.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Blogs.Repository
{
    public class UsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public Usuario GetUsuarioByName(string nombreUsuario)
        {
            Usuario usuario = _context.Usuario.Where(p => p.nombre == nombreUsuario).FirstOrDefault();

            return usuario;
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
