using System.ComponentModel.DataAnnotations;

namespace P2_2020VA601_2020NR601.Models
{
    public class Departamentos
    {

        [Key]
        public int id { get; set; }
        [Display(Name = "Departamento")]
        public string? nombre { get; set; }

    }
}
