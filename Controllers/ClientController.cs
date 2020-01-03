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
    public class ClientController : ControllerBase
    {
        public ClientController(ProductContext ProductContext)
        {
            Context = ProductContext;
        }
        private ProductContext Context;


        // GET api/product
        [HttpGet]
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return Context.Clientes.ToList();
        }

        // GET api/product/5
        [HttpGet("{username}")]
        public ActionResult<Cliente> Get(string username)
        {
            var Username = Context.Clientes.FirstOrDefault(b => b.Username == username);
            if (Username != null)
            {
                return Username;
            } 
            else
            {
                return NotFound();
            }
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody] Cliente value)
        {
            Context.Clientes.Add(value);
            Context.SaveChanges();
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Cliente value)
        {
            var Cliente = Context.Clientes.Find(id);
            if(Cliente != null)
            {
                Cliente.Nombre = value.Nombre;
                Cliente.Apellido = value.Apellido;
                Cliente.Email = value.Email;
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
            var Cliente = Context.Clientes.Find(id);
            if (Cliente != null)
            {
                Context.Remove(Cliente);
                Context.SaveChanges();
                return Ok();
            }else
            {
                return NotFound();
            }
        }
    }
}
