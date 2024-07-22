using Blogs.Enum;
using Blogs.Models;
using Blogs.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntradaController : Controller
    {
        private readonly EntradaRepository _entradaRepository;
        private readonly UsuarioRepository _usuarioRepository;
        //private readonly Context _context;
        public EntradaController(EntradaRepository entradaRepository, UsuarioRepository usuarioRepository/*, Context context*/)
        {
            _entradaRepository = entradaRepository;
            _usuarioRepository = usuarioRepository;
            //_context = context;
        }

        [HttpPost]
        public void SaveEntradaNueva(string textoNuevaEntrada, string nombreUsuarioLogeo)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioByName(nombreUsuarioLogeo);

            _entradaRepository.SaveEntrada(new Entrada()
            {
                estado = EstadoEntradaEnum.Pendiente.ToString(),
                texto = textoNuevaEntrada,
                id_Usuario = usuario.id
            });
        }
    }
}
