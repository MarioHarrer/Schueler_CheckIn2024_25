using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schueler_CheckIn2024_25.Data;
using Schueler_CheckIn2024_25.SchuelerDB;

namespace Schueler_CheckIn2024_25.Pages.SchuelerP
{
    public class EditModel : PageModel
    {
        private readonly Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context _context;

        public EditModel(Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context context)
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

            var schueler =  await _context.Schueler.FirstOrDefaultAsync(m => m.id == id);
            if (schueler == null)
            {
                return NotFound();
            }
            Schueler = schueler;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Schueler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchuelerExists(Schueler.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SchuelerExists(int id)
        {
            return _context.Schueler.Any(e => e.id == id);
        }
    }
}
