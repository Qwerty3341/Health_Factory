using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Health_Factory.DataAccess;
using Health_Factory.DTOs;
using Health_Factory.Utilidades;
using Health_Factory.Modelos;
using System.Collections.ObjectModel;
using Health_Factory.Utilidades.Enumerados;

namespace Health_Factory.ViewModels
{
    public partial class UsuarioViewModel : ObservableObject, IQueryAttributable
    {
        private readonly UsuarioDbContext _dbContext;

        [ObservableProperty]
        private UsuarioDTO usuarioDto = new UsuarioDTO();

        [ObservableProperty]
        private string tituloPagina;

        private int IdUsuario;

        [ObservableProperty]
        private bool loadingEsVisible = false;

        [ObservableProperty]
        private ObservableCollection<Sexo> sexos;

        [ObservableProperty]
        private ObservableCollection<NivelDeActividadFisica> nivelesDeActividadFisica;

        public UsuarioViewModel(UsuarioDbContext context)
        {
            _dbContext = context;
            Sexos = new ObservableCollection<Sexo> { Sexo.Masculino, Sexo.Femenino };
            NivelesDeActividadFisica = new ObservableCollection<NivelDeActividadFisica>
            {
                NivelDeActividadFisica.Bajo,
                NivelDeActividadFisica.Moderado,
                NivelDeActividadFisica.Alto
            };
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id"))
            {
                var id = int.Parse(query["id"].ToString());
                IdUsuario = id;

                if (IdUsuario == 0)
                {
                    TituloPagina = "Nuevo usuario";
                }
                else
                {
                    TituloPagina = "Editar usuario";
                    LoadingEsVisible = true;
                    await Task.Run(async () =>
                    {
                        var encontrado = await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.IdUsuario == IdUsuario);
                        UsuarioDto.IdUsuario = encontrado.IdUsuario;
                        UsuarioDto.Nombre = encontrado.Nombre;
                        UsuarioDto.Apellido = encontrado.Apellido;
                        UsuarioDto.Edad = encontrado.Edad;
                        UsuarioDto.Estatura = encontrado.Estatura;
                        UsuarioDto.Peso = encontrado.Peso;
                        UsuarioDto.NivelDeActividadFisica = encontrado.NivelDeActividadFisica;
                        UsuarioDto.Sexo = encontrado.Sexo;

                        MainThread.BeginInvokeOnMainThread(() =>
                        {
                            LoadingEsVisible = false;
                        });
                    });
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        [RelayCommand]
        private async Task Guardar()
        {
            LoadingEsVisible = true;
            UsuarioMensaje mensaje = new UsuarioMensaje();
            await Task.Run(async () =>
            {
                if (IdUsuario == 0)
                {
                    var tbUsuario = new Usuario
                    {
                        Nombre = UsuarioDto.Nombre,
                        Apellido = UsuarioDto.Apellido,
                        Edad = UsuarioDto.Edad,
                        Estatura = UsuarioDto.Estatura,
                        Peso = UsuarioDto.Peso,
                        NivelDeActividadFisica = UsuarioDto.NivelDeActividadFisica,
                        Sexo = UsuarioDto.Sexo
                    };
                    _dbContext.Usuarios.Add(tbUsuario);
                    await _dbContext.SaveChangesAsync();
                    UsuarioDto.IdUsuario = tbUsuario.IdUsuario;
                    mensaje = new UsuarioMensaje()
                    {
                        EsCrear = true,
                        UsuarioDto = UsuarioDto
                    };
                }
                else
                {
                    var encontrado = await _dbContext.Usuarios.FirstAsync(u => u.IdUsuario == IdUsuario);
                    encontrado.Nombre = UsuarioDto.Nombre;
                    encontrado.Apellido = UsuarioDto.Apellido;
                    encontrado.Edad = UsuarioDto.Edad;
                    encontrado.Estatura = UsuarioDto.Estatura;
                    encontrado.Peso = UsuarioDto.Peso;
                    encontrado.NivelDeActividadFisica = UsuarioDto.NivelDeActividadFisica;
                    encontrado.Sexo = UsuarioDto.Sexo;

                    await _dbContext.SaveChangesAsync();

                    mensaje = new UsuarioMensaje()
                    {
                        EsCrear = false,
                        UsuarioDto = UsuarioDto
                    };
                }

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    LoadingEsVisible = false;
                    WeakReferenceMessenger.Default.Send(new UsuarioMensajeria(mensaje));
                    await Shell.Current.Navigation.PopAsync();
                });
            });
        }
    }
}
