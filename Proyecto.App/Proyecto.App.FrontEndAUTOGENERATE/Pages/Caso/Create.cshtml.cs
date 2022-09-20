using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.FrontEndAUTOGENERATE.Pages_Caso
{
    public class CreateModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public CreateModel(Proyecto.App.Persistencia.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["abogadoId"] = new SelectList(_context.Abogados, "abogadoId", "abogadoId");
        ViewData["clienteId"] = new SelectList(_context.Clientes, "clienteId", "clienteId");
        ViewData["faseCasoId"] = new SelectList(_context.FaseCasos, "faseCasoId", "faseCasoId");
            return Page();
        }

        [BindProperty]
        public Caso Caso { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Casos.Add(Caso);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
