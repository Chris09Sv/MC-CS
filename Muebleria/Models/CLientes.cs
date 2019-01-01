using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muebleria.Models
{
    public class CLientes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Direccion { get; set; }
        public int Telefono { get; set; }

        [StringLength(255)]
        public string Pregunta { get; set; }

        [Display(Name = "Imagen"), DataType(DataType.Upload)]
        public byte[] imagenCliente { get; set; }
        public TipoDeUsuario tipoDeUsuarios { get; set; }

        //public string Title => Id == 0 || Id==null? "Editar cliente" : "Nuevo cliente";
   }
}