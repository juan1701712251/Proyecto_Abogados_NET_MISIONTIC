using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.FrontEndAUTOGENERATE.Pages_Caso
{
    public class DeleteModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public DeleteModel(Proyecto.App.Persistencia.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Caso Caso { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Caso = await _context.Casos
                .Include(c => c.abogado)
                .Include(c => c.cliente)
                .Include(c => c.faseCaso).FirstOrDefaultAsync(m => m.casoId == id);

            if (Caso == null)
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

            Caso = await _context.Casos.FindAsync(id);

            if (Caso != null)
            {
                _context.Casos.Remove(Caso);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
