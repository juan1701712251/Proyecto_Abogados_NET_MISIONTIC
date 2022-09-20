using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.FrontEndAUTOGENERATE.Pages_Abogado
{
    public class IndexModel : PageModel
    {
        private readonly Proyecto.App.Persistencia.ApplicationContext _context;

        public IndexModel(Proyecto.App.Persistencia.ApplicationContext context)
        {
            _context = context;
        }

        public IList<Abogado> Abogado { get;set; }

        public async Task OnGetAsync()
        {
            Abogado = await _context.Abogados.ToListAsync();
        }
    }
}
