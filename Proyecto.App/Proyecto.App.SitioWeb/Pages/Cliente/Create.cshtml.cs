using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.SitioWeb.Pages
{
    public class CreateModel : PageModel
    {
        private IRepositorioCliente _repoCliente;
        private IRepositorioPais _repoPais;
        [BindProperty]
        public Cliente cliente {get;set;}
        public IEnumerable<Pais> paises {get;set;}
        
        // Hacer las referencias a los proyectos Dominio y Persistencia
        public CreateModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.ApplicationContext());
            _repoPais = new RepositorioPais(new Proyecto.App.Persistencia.ApplicationContext());
        }

        public void OnGet()
        {
            paises = _repoPais.ObtenerTodos();
        }

        public IActionResult OnPost(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repoCliente.Agregar(cliente);
                return RedirectToPage("/Cliente/List");
            }
            else
            {
                return Page();
            }
        }
    }
}
