using Blogs.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.Models
{
    public class Login : Controller
    {
        private static Usuario _instance = new Usuario();
        private static UsuarioRepository _usuarioRepository;

        private Login(UsuarioRepository usuarioRepository) 
        {
            _usuarioRepository = usuarioRepository;
        }

        public static Usuario GetInstance
        {
            get
            {
                return _instance;
            }
        }

        public static void SetInstance(Usuario usuario)
        {
            if (_instance == null && _usuarioRepository.UsuarioExiste(usuario.nombre))
            {
                _instance = usuario;
            }
        }
    }
}
