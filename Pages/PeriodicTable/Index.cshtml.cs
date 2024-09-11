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
    public class IndexModel : PageModel
    {
        private readonly Razor3.Data.Razor3Context _context;

        public IndexModel(Razor3.Data.Razor3Context context)
        {
            _context = context;
        }

        public IList<Element> Element { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Element = await _context.Element.ToListAsync();
        }
    }
}
