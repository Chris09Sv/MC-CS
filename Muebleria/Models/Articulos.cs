using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Muebleria.Models
{
    public class Articulos
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Descripcion { get; set; }
     
        public int stock { get; set; }
        [Display(Name = "Imagen"), DataType(DataType.Upload)]
        public byte[] Imagen { get; set; }
        public Categoria Categoria { get; set; }
        public byte CategoriaId { get; set; }

    }
}