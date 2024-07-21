using Blogs.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blogs.Models;

namespace Blogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string GetNombre()
        {
            return "mauro";
        }

        [HttpGet("{Usuario}")]
        //public IActionResult GetUsuario(string usuarioNombre)
        public Usuario GetUsuario()
        {
            return _context.Usuario.FirstOrDefault();
        }

        [HttpPost]
        public void PostUsuario(string nombre, string tipoUsuario, bool autentificado = false) 
        {
            _context.Usuario.Add(new Usuario() {nombre = nombre, tipoUsuario = tipoUsuario, autentificado = autentificado});

            _context.SaveChanges();
        }
    }
}
