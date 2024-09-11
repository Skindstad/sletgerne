using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor3.Data;
using Razor3.Model;

namespace Razor3.Pages.PeriodicTable
{
    public class CreateModel : PageModel
    {
        private readonly Razor3.Data.Razor3Context _context;

        public CreateModel(Razor3.Data.Razor3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Element Element { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Element.Add(Element);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
