using System.ComponentModel.DataAnnotations;

namespace Blogs.Dto
{
    public class EntradasPendientesDto
    {
        [Key]
        public int id_Entrada {  get; set; }

        public string nombreUsuario {  get; set; }

        public string texto { get; set; }

        public DateTime fechaIngreso { get; set; }
    }
}
