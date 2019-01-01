using AutoMapper;
using Muebleria.Models;
using System.Linq;
using System.Web.Http;
using Muebleria;
using System.Collections;
using System.Collections.Generic;

namespace Muebleria.Controllers.Api
{
    public class ClientesController : ApiController
    {
        private ApplicationDbContext _context;
        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<CLientes> GetClientes()
        {
            return _context.clientes.ToList();

        }
    }
} 
