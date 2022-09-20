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

namespace Proyecto.App.FrontEndAUTOGENERATE.Pages_Abogado
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public EditModel(Proyecto.App.Persistencia.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Abogado Abogado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Abogado = await _context.Abogados.FirstOrDefaultAsync(m => m.abogadoId == id);

            if (Abogado == null)
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

            _context.Attach(Abogado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbogadoExists(Abogado.abogadoId))
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

        private bool AbogadoExists(int id)
        {
            return _context.Abogados.Any(e => e.abogadoId == id);
        }
    }
}
