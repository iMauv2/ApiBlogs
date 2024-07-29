using System.ComponentModel.DataAnnotations;

namespace Blogs.Models
{
    public class Entrada
    {
        [Key]
        public int id { get; set; }

        public int id_Usuario { get; set; }

        public string estado {  get; set; }

        public string texto { get; set; }

        public DateTime fechaIngreso { get; set; }
    }
}

