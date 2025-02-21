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
    public class DetailsModel : PageModel
    {
        private readonly Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context _context;

        public DetailsModel(Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context context)
        {
            _context = context;
        }

        public Schueler Schueler { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schueler = await _context.Schueler.FirstOrDefaultAsync(m => m.id == id);
            if (schueler == null)
            {
                return NotFound();
            }
            else
            {
                Schueler = schueler;
            }
            return Page();
        }
    }
}
