using CommunityToolkit.Mvvm.ComponentModel;
using Health_Factory.Utilidades.Enumerados;

namespace Health_Factory.DTOs
{
    public partial class UsuarioDTO : ObservableObject
    {
        [ObservableProperty]
        public int idUsuario;
        [ObservableProperty]
        public string nombre;
        [ObservableProperty]
        public string apellido;
       [ObservableProperty]
        public int edad;
        [ObservableProperty]
        public decimal peso;
        [ObservableProperty]
        public decimal estatura;
        [ObservableProperty]
        public Sexo sexo;
        [ObservableProperty]
        public NivelDeActividadFisica nivelDeActividadFisica;
    }
}
