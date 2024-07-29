using Blogs.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Blogs.Models;
using Blogs.Repository;
using Microsoft.AspNetCore.HttpLogging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Blogs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        public readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        [Route("GetUsuario")]
        public IActionResult GetUsuario(string nombreUsuario)
        {
            try
            {
                if (_usuarioRepository.UsuarioExiste(nombreUsuario))
                {
                    Usuario usuario = _usuarioRepository.GetUsuario(nombreUsuario);

                    return Ok(usuario);
                }
                else
                {
                    return StatusCode(422, "Usuario no encontrado.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Registrarse")]
        public IActionResult PostUsuario(string nombre, string tipoUsuario, bool autentificado, int contraseña)
        {
            try
            {
                if (_usuarioRepository.UsuarioExiste(nombre))
                {
                    return StatusCode(422, "Usuario existente");
                }
                else
                {
                    _usuarioRepository.SaveUsuario(new Usuario()
                    {
                        nombre = nombre,
                        tipoUsuario = tipoUsuario,
                        autentificado = autentificado,
                        contraseña = contraseña
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Usuario registrado");
        }

        [HttpPost]
        [Route("Logeo")]
        public IActionResult Logeo(string username, string password)
        {
            try
            {
                if (_usuarioRepository.UsuarioExiste(username))
                {
                    Login.SetInstance(_usuarioRepository.GetUsuario(username));
                    return Ok("Ingreso exitoso.");
                }
                else
                {
                    return StatusCode(422, "Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
