using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemasWeb.Areas.Cursos.Models;

namespace SistemasWeb.Areas.Categorias.Models
{
    public class TCategoria
    {
        [Key]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo descripcion es obligatorio.")]
        public string Descripcion { get; set; }
        public Boolean Estado { get; set; } = true;
        public ICollection<TCursos> Cursos { get; set; }
    }
}
