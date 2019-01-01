using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Muebleria.Models;

namespace Muebleria.ViewModel
{
    public class ArtiulosModelView
    {
        public Articulos Articulos { get; set; }
        public IEnumerable<Categoria> categorias { get; set; }

        //public string Title
        //{
        //    if()
        //}

        //public int Id { get; set; }

        //[Required]
        //[StringLength(255)]
        //public string Name { get; set; }
        //public string Descripcion { get; set; }

        //public int stock { get; set; }
        //[Display(Name = "Imagen"), DataType(DataType.Upload)]
        //public byte[] Imagen { get; set; }
        //public byte CategoriaId { get; set; }

        //public ArtiulosModelView()
        //{

        //}
        //public ArtiulosModelView(Articulos Articulos)
        //{
        //    Id = Articulos.Id;
        //    Name = Articulos.Name;
        //        Descripcion = Articulos.Descripcion;

        //    stock = Articulos.stock;
                
        //        Imagen=Articulos.Imagen
        //        CategoriaId

        //}
    }

}