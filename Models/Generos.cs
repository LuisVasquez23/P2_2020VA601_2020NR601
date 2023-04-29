using System.ComponentModel.DataAnnotations;

namespace P2_2020VA601_2020NR601.Models
{
    public class Generos
    {

        [Key]
        public int id { get; set; }
        [Display(Name = "Genero")]
        public string? genero { get; set; }

    }
}
