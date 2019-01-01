using Muebleria.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Muebleria.ViewModel
{
    public class ContactViewModel
    {
        public CLientes Clientes { get; set; }

        //public int Id { get; set; }

        //[Required]
        //[StringLength(255)]
        //public string Name { get; set; }

        //[StringLength(255)]
        //public string Direccion { get; set; }
        //public int Telefono { get; set; }

        //[StringLength(255)]
        //public string Pregunta { get; set; }

        //[Display(Name = "Imagen"), DataType(DataType.Upload)]
        //public byte[] imagenCliente { get; set; }



        //public string Title
        //{
        //    get
        //    {
                


        //        return Clientes.Id!=0? "Editar Cliente": "Nuevo Cliente";
        //    }
        //}


        public ContactViewModel()
        {

        }
        //public ContactViewModel(CLientes c)
        //{
        //    Id = c.Id;
        //    Name = c.Name;
        //    Telefono = c.Telefono;
        //    imagenCliente = c.imagenCliente;
        //    Pregunta = c.Pregunta;
            
        //}

    }
}