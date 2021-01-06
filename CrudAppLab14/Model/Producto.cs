using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; } 
        public bool Entrega { get; set; }

    }
}
