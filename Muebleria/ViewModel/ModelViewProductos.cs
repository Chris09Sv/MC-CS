using Muebleria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Muebleria.ViewModel
{
    public class ModelViewProductos
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Descripcion { get; set; }
        //public IEnumerable<Categoria> Categoria { get; set; }
        public byte? CatgID { get; set; }
        public int stock { get; set; }
        [Display(Name = "Imagen"), DataType(DataType.Upload)]
        public byte[] Imagen { get; set; }
        public string Titulo { get; set; }



        public string Title
        {

            get
            {
                //if (Id != null && Id.Id != 0)
                //    return "Edit Product";
                return Id != 0 ? "Editar Producto" : "Nuevo Producto";

                //return "New Product";
            }
        }

        public ModelViewProductos()
        {

        }

        public ModelViewProductos( Productos p)
        {
            Id =p.Id;
            Name = p.Name;
            Descripcion = p.Descripcion;
            //CatgID = p.CategoriaID;

        }
    }
}