using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.FrontEndAUTOGENERATE.Pages_FaseCaso
{
    public class DeleteModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public DeleteModel(Proyecto.App.Persistencia.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FaseCaso FaseCaso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FaseCaso = await _context.FaseCasos.FirstOrDefaultAsync(m => m.faseCasoId == id);

            if (FaseCaso == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FaseCaso = await _context.FaseCasos.FindAsync(id);

            if (FaseCaso != null)
            {
                _context.FaseCasos.Remove(FaseCaso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
