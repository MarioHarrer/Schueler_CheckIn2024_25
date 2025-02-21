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
    public class DeleteModel : PageModel
    {
        private readonly Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context _context;

        public DeleteModel(Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var schueler = await _context.Schueler.FindAsync(id);
            if (schueler != null)
            {
                Schueler = schueler;
                _context.Schueler.Remove(Schueler);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
