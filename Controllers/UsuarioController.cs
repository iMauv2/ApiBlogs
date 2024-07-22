using Blogs.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blogs.Models;
using Blogs.Repository;

namespace Blogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly DataContext _context;
        public readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("{Usuario}")]
        public Usuario GetUsuario()
        {
            return _context.Usuario.FirstOrDefault();
        }

        [HttpPost]
        public void PostUsuario(string nombre, string tipoUsuario, bool autentificado)
        {
            //Aca validaria el tipo de usuario pero que tampoco seria necesario si usamos un Combo que me deje elegir.

            if (_usuarioRepository.UsuarioExiste(nombre))
            {
                Console.WriteLine("Usuario existente.");
            }
            else
            {
                _usuarioRepository.SaveUsuario(new Usuario()
                {
                    nombre = nombre,
                    tipoUsuario = tipoUsuario,
                    autentificado = autentificado
                });
            }
        }
    }
}
