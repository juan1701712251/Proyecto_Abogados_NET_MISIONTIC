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
    public class EditModel : PageModel
    {
        private IRepositorioCliente _repoCliente;
        [BindProperty]
        public Cliente cliente {get;set;}

        // Hacer las referencias a los proyectos Dominio y Persistencia
        public EditModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.ApplicationContext());
        }
        
        //int id coincide con el parametro que se envia desde la vista asp-route-id
        public IActionResult OnGet(int id)
        {
            cliente = _repoCliente.ObtenerPorId(id);
            if (cliente == null)
            {
                return RedirectToPage("/Cliente/List");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repoCliente.Modificar(cliente);
                return RedirectToPage("/Cliente/List");
            }
            else
            {
                return Page();
            }
        }
    }
}
