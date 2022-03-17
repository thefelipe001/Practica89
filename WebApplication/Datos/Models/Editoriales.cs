using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Datos.Models
{
    public class Editoriales
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
