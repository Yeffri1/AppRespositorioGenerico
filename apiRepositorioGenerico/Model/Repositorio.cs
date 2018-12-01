using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apiRepositorioGenerico.Model
{
    [Table("Repositorio")]
    [ModelMetadataType(typeof(RepositorioMetaData))]
    public class Repositorio
    {
        public int id { get; set; }
        public DateTime fechaIng { get; set; }
        public int usuario { get; set; }
        public int tipoID { get; set; }
        public string descripcion { get; set; }
    }
    public class RepositorioMetaData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso no puede ser null")]
        public DateTime fechaIng { get; set; }

        [MaxLength(50, ErrorMessage = " usuario no puede tener mas de 50 caracteres")]
        [Required(ErrorMessage = " usuario no puede ser null")]
        public int usuario { get; set; }

        [Required(ErrorMessage = " tipoID no puede ser null ")]
        public int tipoID { get; set; }

        [Required(ErrorMessage = "La descripcion no puede ser null ")]
        public string descripcion { get; set; }
    }
}
