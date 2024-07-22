using Blogs.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Models
{
    [ApiController]
    [Route("api/[controller]")]
    public class Context : Controller
    {
        protected Usuario _usuario;
        private readonly UsuarioRepository _usuarioRepository;

        protected Context(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public Usuario GetUsuarioLogeado(string nombreUsuario)
        {
            _usuario = _usuarioRepository.GetUsuarioByName(nombreUsuario);
            return _usuario;
        }
    }
}
