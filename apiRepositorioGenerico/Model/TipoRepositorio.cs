using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiRepositorioGenerico.Model
{
    [Table("TipoRepositorio")]
    public class TipoRepositorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime fechaIng { get; set; }
        public string descripcion { get; set; }
    }
}
