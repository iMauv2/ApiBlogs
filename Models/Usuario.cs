using System.ComponentModel.DataAnnotations;

namespace Blogs.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }

        public string nombre { get; set; }

        public string tipoUsuario { get; set; }

        public bool autentificado { get; set; }

        public int contraseña { get; set; }
    }
}
