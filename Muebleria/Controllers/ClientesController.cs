using Muebleria.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Muebleria.ViewModel;

namespace Muebleria.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes

        //db context to access the database
        private ApplicationDbContext _context;
        // inicializamos en el constructor, este es un
        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Index()
        {
            return View(_context.clientes.ToList());
        }

        public ActionResult convertirImagen(int CodigoCliente)
        {
            var imagenCliente = _context.clientes.Where(z => z.Id == CodigoCliente).FirstOrDefault();
            return File(imagenCliente.imagenCliente, "image/jpeg");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Direccion,Telefono,Pregunta")] CLientes clientes, HttpPostedFileBase ImagenCliente)

        {
            if(ImagenCliente != null && ImagenCliente.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImagenCliente.InputStream)) 
                {
                    imageData = binaryReader.ReadBytes(ImagenCliente.ContentLength);
                }
                clientes.imagenCliente = imageData;

            }
            if (ModelState.IsValid)
            {
                _context.clientes.Add(clientes);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(clientes);
        }

        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLientes cLientes = _context.clientes.Find(id);
            if (cLientes == null)
            {
                return HttpNotFound();
               
            }
            return View(cLientes);
        }
        public ActionResult Editar(int id)
        {
            var cliente = _context.clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

           
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Name,Direccion,Telefono,Pregunta")] CLientes clientes, HttpPostedFileBase ImagenCliente)
        {
            if (ImagenCliente != null && ImagenCliente.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImagenCliente.InputStream))
                {
                    imageData = binaryReader.ReadBytes(ImagenCliente.ContentLength);
                }
                clientes.imagenCliente = imageData;

            }
            if (ModelState.IsValid)
            {

                _context.Entry(clientes).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(clientes);
        }


        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLientes cLientes = _context.clientes.Find(id);
            if (cLientes == null)
            {
                return HttpNotFound();

            }
            return View(cLientes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Eliminar([Bind(Include = "Id,Name,Direccion,Telefono,Pregunta")] CLientes clientes, HttpPostedFileBase ImagenCliente)
        {
            if (ImagenCliente != null && ImagenCliente.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImagenCliente.InputStream))
                {
                    imageData = binaryReader.ReadBytes(ImagenCliente.ContentLength);
                }
                clientes.imagenCliente = imageData;

            }
            if (ModelState.IsValid)
            {

                _context.Entry(clientes).State = EntityState.Deleted;
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(clientes);
        }

        public ActionResult Catalogo(CLientes cLientes)
        {
            return View(cLientes);
        }
    }



}