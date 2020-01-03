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
    public class CategorieController : ControllerBase
    {
        public CategorieController(ProductContext ProductContext)
        {
            Context = ProductContext;
        }
        private ProductContext Context;

        // GET api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Categoria>> Get()
        {
            return Context.Categorias.Include(x => x.Productos).ToList();
        }


        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Categoria> Get(int id)
        {
            var Categoria = Context.Categorias.Find(id);
            if (Categoria != null)
            {
                return Categoria;
            }
            else
            {
                return NotFound();
            }
        }


        // POST api/Product
        [HttpPost]
        public void Post([FromBody] Categoria value)
        {
            Context.Categorias.Add(value);
            Context.SaveChanges();
        }


        // PUT api/Product/5

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categoria value)
        {
            var Categoria = Context.Categorias.Find(id);
            if (Categoria != null)
            {
                Categoria.Title = value.Title;
                Categoria.Productos = value.Productos;
                Context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = Context.Categorias.Find(id);
            if (categoria != null)
            {
                Context.Remove(categoria);
                Context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
