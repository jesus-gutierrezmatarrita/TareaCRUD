using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TareaCRUD.Models
{
    public class Course
    {
        [Key]
        [Display(Name = "Sigla del curso")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del curso es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe al menos {2} y máximo {1} caracteres.", MinimumLength = 5)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Los créditos del curso son obligatorios anotarlos")]
        [Display(Name = "Créditos")]
        public short Credits { get; set; }

    }
}
