using System;
namespace DiaD.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public int Precio { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categorias { get; set; }
    }
}