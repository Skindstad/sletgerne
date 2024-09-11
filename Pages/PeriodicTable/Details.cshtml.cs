using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor3.Data;
using Razor3.Model;

namespace Razor3.Pages.PeriodicTable
{
    public class DetailsModel : PageModel
    {
        private readonly Razor3.Data.Razor3Context _context;

        public DetailsModel(Razor3.Data.Razor3Context context)
        {
            _context = context;
        }

        public Element Element { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var element = await _context.Element.FirstOrDefaultAsync(m => m.Id == id);
            if (element == null)
            {
                return NotFound();
            }
            else
            {
                Element = element;
            }
            return Page();
        }
    }
}
