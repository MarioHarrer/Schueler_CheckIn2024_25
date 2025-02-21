using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schueler_CheckIn2024_25.SchuelerDB;

namespace Schueler_CheckIn2024_25.Data
{
    public class Schueler_CheckIn2024_25Context : DbContext
    {
        public Schueler_CheckIn2024_25Context (DbContextOptions<Schueler_CheckIn2024_25Context> options)
            : base(options)
        {
        }

        public DbSet<Schueler_CheckIn2024_25.SchuelerDB.Schueler> Schueler { get; set; } = default!;
    }
}
