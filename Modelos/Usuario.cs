using System.ComponentModel.DataAnnotations;
using Health_Factory.Utilidades.Enumerados;

namespace Health_Factory.Modelos
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Range(0, 150)]
        public int Edad { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Peso { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Estatura { get; set; }

        public Sexo Sexo { get; set; }

        [RegularExpression("Bajo|Moderado|Alto")]
        public NivelDeActividadFisica NivelDeActividadFisica { get; set; }
    }
}