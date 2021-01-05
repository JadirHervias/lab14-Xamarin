using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CrudAppLab14.Model
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Persona { get; set; }
        public string Colegio { get; set; }
        public string Product { get; set; }
        public string Cantidad { get; set; }
        public string Fecha { get; set; } 
        public string Entrega { get; set; }

    }
}
