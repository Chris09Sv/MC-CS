using Muebleria.Models;
using Muebleria.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Muebleria.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        private ApplicationDbContext _contex;
        public ProductosController()
        {
            _contex = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }


        public ActionResult Inicio()
        {
            return View(_contex.articulos.ToList());

        }
        public ActionResult convertirImagen(int id)
        {
            var ImagenProducto = _contex.productos.Where(p => p.Id == id).FirstOrDefault();
            return File(ImagenProducto.Imagen, "image/jpeg");
        }
       public ActionResult Nuevo()
        {
            ////var category = _contex.Categorias.ToList();
            //var viewmodel = new ModelViewProductos
            //{
            //    Categoria = category
            //};
            //return View("Nuevo", viewmodel);
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo([Bind (Include ="Id,Name,Descripcion,Categoria,stock")]Productos productos , HttpPostedFileBase imagenArticulo)
        {

            if(imagenArticulo != null && imagenArticulo.ContentLength > 0)
            {
                byte[] imagedata = null;
                using(var binaryReader = new BinaryReader(imagenArticulo.InputStream))
                {
                    imagedata = binaryReader.ReadBytes(imagenArticulo.ContentLength);
                }
                productos.Imagen = imagedata;
            }
            if (ModelState.IsValid && productos.Id==0)
            {
                //productos.Titulo = "Nuevo";
                _contex.productos.Add(productos);
                _contex.SaveChanges();
                return RedirectToAction("Inicio");

            }
            
            return View(productos);
        }


        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = _contex.productos.Find(id);
            if (productos == null)
            {
               return HttpNotFound();
            }
            return View(productos);
        }

          public ActionResult Editar(int id)
        {
           
            var productos = _contex.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar([Bind(Include = "Id,Name,Descripcion,Categoria,stock")]Productos productos, HttpPostedFileBase imagenProducto)
        {

            if (imagenProducto != null && imagenProducto.ContentLength > 0)
            {
                byte[] imagedata = null;
                using (var binaryReader = new BinaryReader(imagenProducto.InputStream))
                {
                    imagedata = binaryReader.ReadBytes(imagenProducto.ContentLength);
                }
                productos.Imagen = imagedata;
            }



            if (ModelState.IsValid)
            {
                _contex.Entry(productos).State=System.Data.Entity.EntityState.Modified;
                _contex.SaveChanges();
                return RedirectToAction("Inicio");

            }
            return View(productos);
        }
        public ActionResult Catalogo(Productos cLientes)
        {
            return View(_contex.productos.ToList());
        }
    }
}