using System.ComponentModel.DataAnnotations;

namespace RequerimientosDto
{
    public class RequerimientoDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; }
        public TipoPrioriodad Prioridad { get; set; }
        public TipoEstado EstadoActual { get; set; }
    }
}
