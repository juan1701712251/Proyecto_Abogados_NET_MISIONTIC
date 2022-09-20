using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyecto.App.Dominio
{
    public class Ciudad
    {
        [Key]
        public int ciudadId { get; set; }
        [MaxLength(50)]
        public string nombreCiudad { get; set; }

        //Lista de Clientes
        public List<Cliente> clientes { get; set; }
    }
}