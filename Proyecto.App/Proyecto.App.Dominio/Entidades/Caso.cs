using System;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.App.Dominio
{
    public class Caso
    {
        [Key]
        public int casoId { get; set; }


        public int? clienteId { get; set; }
        public Cliente cliente { get; set; }

        public int? abogadoId { get; set; }
        public Abogado abogado { get; set; }

        public int? faseCasoId { get; set; }
        public FaseCaso faseCaso { get; set; }


        public DateTime fechaInicioCaso { get; set; }
        [MaxLength(200)]
        public string descripcionCaso { get; set; }
        public int cantidadTestigos { get; set; }
        [MaxLength(100)]
        public string direccionJuzgadoAsignado { get; set; }
    }
}