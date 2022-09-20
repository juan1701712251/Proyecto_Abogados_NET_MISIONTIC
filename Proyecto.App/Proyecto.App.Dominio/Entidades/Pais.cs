using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Proyecto.App.Dominio
{
    public class Pais
    {
        [Key]
        public int paisId { get; set; }
        [MaxLength(50)]
        public string nombrePais { get; set; }

        //Lista de Clientes
        public List<Cliente> clientes { get; set; }
    }
}