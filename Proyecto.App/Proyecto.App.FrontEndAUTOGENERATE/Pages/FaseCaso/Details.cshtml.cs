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
    public class DetailsModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public DetailsModel(Proyecto.App.Persistencia.ApplicationContext context)
        {
            _context = context;
        }

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
    }
}
