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
    public class ArticulosController : Controller
    {
        // GET: Productos
        private ApplicationDbContext _contex;
        public ArticulosController()
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
            var imagenArticulo = _contex.articulos.Where(p => p.Id == id).FirstOrDefault();
            return File(imagenArticulo.Imagen, "image/jpeg");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Descripcion,stock,CategoriaId")] Articulos articulos,HttpPostedFileBase ImagenArticulo)
        {
            if(ImagenArticulo != null && ImagenArticulo.ContentLength>0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImagenArticulo.InputStream))
                {
                    imageData = binaryReader.ReadBytes(ImagenArticulo.ContentLength);
                }
                articulos.Imagen = imageData;
            }
            if (ModelState.IsValid)
            {
                _contex.articulos.Add(articulos);
                _contex.SaveChanges();
              return  RedirectToAction("Inicio");

            }
            return View(articulos);
        }
        public ActionResult Nuevo(Articulos articulos)
        {
            var category = _contex.categorias.ToList();
            var viewmodel = new ArtiulosModelView
            {
                Articulos = new Articulos(),
                categorias = category
            };
            return View("Nuevo", viewmodel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Nuevo([Bind(Include = "Id,Name,Descripcion,stock,CategoriaId")] Articulos articulos, HttpPostedFileBase ImagenArticulo)
        {
            if (ImagenArticulo != null && ImagenArticulo.ContentLength > 0)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(ImagenArticulo.InputStream))
                {
                    imageData = binaryReader.ReadBytes(ImagenArticulo.ContentLength);
                }
                articulos.Imagen = imageData;
            }
            if (ModelState.IsValid)
            {
                _contex.articulos.Add(articulos);
                _contex.SaveChanges();
                return RedirectToAction("Inicio");

            }
            return View(articulos);
        }

        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } Articulos articulos = _contex.articulos.Find(id);
            if(articulos==null)
            {
                return HttpNotFound();
            }

            return View(articulos);
        }



        public ActionResult Edit(int? id)
        {

            var articulos = _contex.articulos.SingleOrDefault(c => c.Id == id);
            if (articulos == null)
            {
                return HttpNotFound();
            } var viewmodel = new ArtiulosModelView
            {
                Articulos = articulos,
                categorias = _contex.categorias.ToList()

                };
            return View(viewmodel);

        }

        

        [HttpPost]
         [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Descripcion,Stock,CategoriaId")] Articulos articulo, HttpPostedFile imagenArticulo)

        {
            if (imagenArticulo != null && imagenArticulo.ContentLength > 0)
            {
                byte[] imagedata = null;
                using (var binaryReader = new BinaryReader(imagenArticulo.InputStream))
                {
                    imagedata = binaryReader.ReadBytes(imagenArticulo.ContentLength);
                }
                articulo.Imagen = imagedata;
            }
            if (ModelState.IsValid)
            {
                _contex.Entry(articulo).State = System.Data.Entity.EntityState.Modified;
                _contex.SaveChanges();


                //var articulodb = _contex.articulos.Single(c => c.Id == articulo.Id);
                //articulodb.Name = articulo.Name;
                //articulodb.Descripcion = articulo.Descripcion;

                //articulodb.stock = articulo.stock;
                //articulodb.CategoriaId = articulo.CategoriaId;
                //articulodb.Imagen = articulo.Imagen;

                //_contex.SaveChanges();
                //return RedirectToAction("Inicio");


            }
            return View();

        }











    }
}