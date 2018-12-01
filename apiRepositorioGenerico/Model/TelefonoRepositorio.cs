using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiRepositorioGenerico.Model
{
    [Table("TelefonoRepositorio")]
    public class TelefonoRepositorio 
    {
        [Key]
        [Column(Order = 0)]
        public int idRepositorio { get; set; }
        [MaxLength(20, ErrorMessage = "El numero de telefono no puede pasar de 20 caracteres")]
        [MinLength(1, ErrorMessage = "El numero de telefono tiene que tener 1 caracteres")]
        public string telefono { get; set; }

        [ForeignKey("idRepositorio")]
        public virtual Repositorio Repositorio { get; set; }
    }
}
