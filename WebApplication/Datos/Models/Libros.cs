using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class Libros
    {
        [Key]
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int CodigoEditorial { get; set; }
    }
}
