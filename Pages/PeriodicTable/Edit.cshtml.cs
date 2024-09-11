using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor3.Data;
using Razor3.Model;

namespace Razor3.Pages.PeriodicTable
{
    public class EditModel : PageModel
    {
        private readonly Razor3.Data.Razor3Context _context;

        public EditModel(Razor3.Data.Razor3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Element Element { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var element =  await _context.Element.FirstOrDefaultAsync(m => m.Id == id);
            if (element == null)
            {
                return NotFound();
            }
            Element = element;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Element).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementExists(Element.Id))
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

        private bool ElementExists(int id)
        {
            return _context.Element.Any(e => e.Id == id);
        }
    }
}
