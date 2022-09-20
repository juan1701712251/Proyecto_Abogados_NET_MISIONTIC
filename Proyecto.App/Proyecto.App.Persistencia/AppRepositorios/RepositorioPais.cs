using System.Collections.Generic;
using Proyecto.App.Dominio;
using System.Linq;

namespace Proyecto.App.Persistencia
{
    public class RepositorioPais : IRepositorioPais
    {
        private readonly ApplicationContext _appContext;

        public RepositorioPais(ApplicationContext contexto)
        {
            _appContext = contexto;
        }

        
        IEnumerable<Pais> IRepositorioPais.ObtenerTodos()
        {
            return _appContext.Paises;
        }
    }
}