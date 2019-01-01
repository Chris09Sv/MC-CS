using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muebleria.Models
{
    public class Categoria
    {
        public byte Id { get; set; } 

        public string Descripcion { get; set; }
        
    }
}