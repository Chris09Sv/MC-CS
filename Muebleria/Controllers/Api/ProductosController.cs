using AutoMapper;
using Muebleria.Dto;
using Muebleria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace Muebleria.Controllers.Api
{
    public class ProductosController : ApiController
    {
        private ApplicationDbContext _context;
        public ProductosController()
        {
            _context = new ApplicationDbContext();
        }
        //public IHttpActionResult GetProductos()
        //{
        //    var productosDto = _context.productos.Include(c =>c.Categoria)
        //        .Select(Mapper.Map<Productos, ProductosDto>);
        //    return Ok(productosDto);
        //}
        public IEnumerable<Productos> GetProductos()
        {
            return _context.productos.ToList();
        }
    }
}
