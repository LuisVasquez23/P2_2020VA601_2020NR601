using Microsoft.EntityFrameworkCore;
using P2_2020VA601_2020NR601.Models;

namespace P2_2020VA601_2020NR601.Data
{
    public class CovidDBContext : DbContext
    {

        public CovidDBContext(DbContextOptions<CovidDBContext> options) : base(options) 
        {

        }

        public DbSet<Departamentos> departamentos { get; set; }    
        public DbSet<Generos> generos { get; set; }    
        public DbSet<CasosReportados> casosReportados { get;set; }

    }
}
