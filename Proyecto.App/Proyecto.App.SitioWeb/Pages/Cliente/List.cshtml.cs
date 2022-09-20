using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

//Importante agregar la referencia a la capa de dominio y persistencia
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.SitioWeb.Pages
{
    public class ListModel : PageModel
    {
        public IEnumerable<Cliente> clientes {get;set;}
        private IRepositorioCliente _repoCliente;

        // Hacer las referencias a los proyectos Dominio y Persistencia
        public ListModel()
        {
            _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.ApplicationContext());
        }

        public void OnGet()
        {
            LlenarClientes();
        }
        private void LlenarClientes(){
            clientes = _repoCliente.ObtenerTodos();
        }
    }
}
