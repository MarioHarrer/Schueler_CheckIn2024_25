using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Schueler_CheckIn2024_25.Data;
using Schueler_CheckIn2024_25.SchuelerDB;

namespace Schueler_CheckIn2024_25.Pages.SchuelerP
{
    public class IndexModel : PageModel
    {
        private readonly Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context _context;

        public IndexModel(Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context context)
        {
            _context = context;
        }

        public IList<Schueler> Schueler { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Schueler = await _context.Schueler.ToListAsync();
        }
    }
}
