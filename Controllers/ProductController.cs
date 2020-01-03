using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiaD.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(ProductContext ProductContext)
        {
            Context = ProductContext;
        }
        private ProductContext Context;


        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Context.Productos.Include(x => x.Categorias).ToList();
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var Producto = Context.Productos.Find(id);
            if (Producto != null)
            {
                return Producto; 
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody] Producto vale)
        {
            Context.Productos.Add(vale);
            Context.SaveChanges();
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto value)
        {
            var Producto = Context.Productos.Find(id);
            if(Producto != null)
            {
            Producto.ProductoId = value.ProductoId;
            Producto.Precio = value.Precio;
            Producto.Titulo = value.Titulo;
            Producto.Descripcion = value.Descripcion;
            Producto.CategoriaId = value.CategoriaId;
            Context.SaveChanges();
                return Ok();
            }else
            {
                return NotFound();
            }

        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var Producto = Context.Productos.Find(id);
            if (Producto != null)
            {
                Context.Remove(Producto);
                Context.SaveChanges();
                return Ok();
            }else
            {
                return NotFound();
            }
        }
    }
}
