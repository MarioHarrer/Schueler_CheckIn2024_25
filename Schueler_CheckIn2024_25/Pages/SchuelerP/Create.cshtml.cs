using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schueler_CheckIn2024_25.Data;
using Schueler_CheckIn2024_25.SchuelerDB;

namespace Schueler_CheckIn2024_25.Pages.SchuelerP
{
    public class CreateModel : PageModel
    {
        private readonly Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context _context;

        public CreateModel(Schueler_CheckIn2024_25.Data.Schueler_CheckIn2024_25Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Schueler Schueler { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Schueler.Add(Schueler);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
