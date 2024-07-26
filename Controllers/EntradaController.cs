using Blogs.Dto;
using Blogs.Enum;
using Blogs.Helper;
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
        [Route("CrearEntrada")]
        public void SaveEntradaNueva(string textoNuevaEntrada, string nombreUsuarioLogeo)
        {
            Usuario usuario = _usuarioRepository.GetUsuarioByName(nombreUsuarioLogeo);

            _entradaRepository.SaveEntrada(new Entrada()
            {
                estado = EstadoEntradaEnum.Pendiente.ToString(),
                texto = textoNuevaEntrada,
                id_Usuario = usuario.id,
                fechaIngreso = DateTime.Now
            });
        }

        //[HttpGet]
        //[Route("GetListasSegunEstado")]
        //public List<Entrada> GetListaEntradasSegunEstado(string estado)
        //{   //se me ocurrio que en vez de traer solo las pendientes traigan segun el input
        //    return _entradaRepository.GetEntradasByEstado(estado);
        //}

        [HttpGet]
        [Route("GetListaEntradasPendientes")]
        public List<EntradasPendientesDto> GetEntradasPendientes()
        {
            return ToolKit.GetEntradaDto(_entradaRepository, _usuarioRepository);
        }

        [HttpPut]
        [Route("CambiarEstado")]
        public void PutCambioEstado(string estadoNuevo, int idEntrada)
        {
            Entrada entrada = _entradaRepository.GetEntradaById(idEntrada);

            entrada.estado = estadoNuevo;

            _entradaRepository.UpdateEntrada();
        }
    } 
}
