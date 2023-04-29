using System.ComponentModel.DataAnnotations;

namespace P2_2020VA601_2020NR601.Models
{
    public class CasosReportados
    {

        [Key]

        public int id { get; set; }

        public int? departamento_id { get; set; }

        public int? genero_id { get; set; }

        public int? confirmados { get; set; }
        public int? recuperados { get; set; }
        public int? fallecidos { get; set; }

    }
}
