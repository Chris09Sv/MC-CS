using AutoMapper;
using Muebleria.Dto;
using Muebleria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Muebleria.App_Start
{
    public class MappingProfile:Profile 
    {
        public MappingProfile()
        {
            CreateMap<Productos, ProductosDto>();
            CreateMap<CLientes, CLientesDto>();

        }

    }
}