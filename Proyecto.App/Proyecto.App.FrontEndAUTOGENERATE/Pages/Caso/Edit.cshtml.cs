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

namespace Proyecto.App.FrontEndAUTOGENERATE.Pages_Caso
{
    public class EditModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public EditModel(Proyecto.App.Persistencia.ApplicationContext context)
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
           ViewData["abogadoId"] = new SelectList(_context.Abogados, "abogadoId", "abogadoId");
           ViewData["clienteId"] = new SelectList(_context.Clientes, "clienteId", "clienteId");
           ViewData["faseCasoId"] = new SelectList(_context.FaseCasos, "faseCasoId", "faseCasoId");
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

            _context.Attach(Caso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CasoExists(Caso.casoId))
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

        private bool CasoExists(int id)
        {
            return _context.Casos.Any(e => e.casoId == id);
        }
    }
}
