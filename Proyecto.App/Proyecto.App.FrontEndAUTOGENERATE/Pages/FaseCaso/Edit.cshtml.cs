using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.FrontEndAUTOGENERATE.Pages_FaseCaso
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public EditModel(Proyecto.App.Persistencia.ApplicationContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FaseCaso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaseCasoExists(FaseCaso.faseCasoId))
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

        private bool FaseCasoExists(int id)
        {
            return _context.FaseCasos.Any(e => e.faseCasoId == id);
        }
    }
}
