using System;
using System.Collections.Generic;

namespace DiaD.Models
{
        public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Title { get; set; }
        public IEnumerable<Producto> Productos { get; set;}
        
    }
}