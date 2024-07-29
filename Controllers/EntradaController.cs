using Blogs.Dto;
using Blogs.Enum;
using Blogs.Helper;
using Blogs.Models;
using Blogs.Repository;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntradaController : Controller
    {
        private readonly EntradaRepository _entradaRepository;
        private readonly UsuarioRepository _usuarioRepository;

        public EntradaController(EntradaRepository entradaRepository, UsuarioRepository usuarioRepository)
        {
            _entradaRepository = entradaRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("CrearEntrada")]
        public IActionResult SaveEntradaNueva(string textoNuevaEntrada)
        {
            try
            {
                if (Login.GetInstance != null)
                {
                    _entradaRepository.SaveEntrada(new Entrada()
                    {
                        estado = EstadoEntradaEnum.Pendiente.ToString(),
                        texto = textoNuevaEntrada,
                        id_Usuario = 1, // lo correcto seria poder acceder al usuario ingresado
                        fechaIngreso = DateTime.Now
                    });
                }

                return Ok("Entrada creada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetListaEntradasPendientes")]
        public IActionResult GetEntradasPendientes()
        {
            try
            {
                var entradasPendientes = ToolKit.GetEntradaDto(_entradaRepository, _usuarioRepository);

                return Ok(entradasPendientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("CambiarEstado")]
        public IActionResult PutCambioEstado(string estadoNuevo, int idEntrada)
        {
            try
            {
                _entradaRepository.GetEntradaById(idEntrada).estado = estadoNuevo;

                _entradaRepository.UpdateEntrada();

                return Ok("Entrada Actualizada.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
