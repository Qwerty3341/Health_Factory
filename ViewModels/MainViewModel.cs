using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Health_Factory.DataAccess;
using Health_Factory.DTOs;
using Health_Factory.Utilidades;
using Health_Factory.Modelos;
using System.Collections.ObjectModel;
using Health_Factory.Views;

namespace Health_Factory.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly UsuarioDbContext _dbContext;

        [ObservableProperty]
        private ObservableCollection<UsuarioDTO> listaUsuario = new ObservableCollection<UsuarioDTO>();

        public MainViewModel(UsuarioDbContext context)
        {
            _dbContext = context;
            MainThread.BeginInvokeOnMainThread(new Action(async () => await Obtener()));
            WeakReferenceMessenger.Default.Register<UsuarioMensajeria>(this, (r, m) =>
            {
                UsuarioMensajeRecibido(m.Value);
            });

        }

        public async Task Obtener()
        {
            var lista = await _dbContext.Usuarios.ToListAsync();
            if (lista.Any())
            {
                foreach (var item in lista)
                {
                    ListaUsuario.Add(new UsuarioDTO
                    {
                        IdUsuario = item.IdUsuario,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Edad = item.Edad,
                        Estatura = item.Estatura,
                        Peso = item.Peso,
                        NivelDeActividadFisica = item.NivelDeActividadFisica
                    });
                }
            }
        }

        private void UsuarioMensajeRecibido(UsuarioMensaje usuarioMensaje)
        {
            var usuarioDto = usuarioMensaje.UsuarioDto;

            if (usuarioMensaje.EsCrear)
            {
                ListaUsuario.Add(usuarioDto);
            }
            else
            {
                var encontrado = ListaUsuario.First(u => u.IdUsuario == usuarioDto.IdUsuario);

                encontrado.Nombre = usuarioDto.Nombre;
                encontrado.Apellido = usuarioDto.Apellido;
                encontrado.Edad = usuarioDto.Edad;
                encontrado.Estatura = usuarioDto.Estatura;
                encontrado.Peso = usuarioDto.Peso;
                encontrado.NivelDeActividadFisica = usuarioDto.NivelDeActividadFisica;
            }
        }

        [RelayCommand]
        private async Task Crear()
        {
            var uri = $"{nameof(UsuarioPage)}? id=0";
            await Shell.Current.GoToAsync(uri);
        }

        [RelayCommand]
        private async Task Editar(UsuarioDTO usuarioDto)
        {
            var uri = $"{nameof(UsuarioPage)}? id={usuarioDto.IdUsuario}";
            await Shell.Current.GoToAsync(uri);
        }

        [RelayCommand]
        private async Task Eliminar(UsuarioDTO usuarioDto)
        {
            bool answer = await Shell.Current.DisplayAlert("Mensaje", "¿Quíeres eliminar al usuario?", "Sí", "No");
            if (answer)
            {
                var encontrado = await _dbContext.Usuarios.FirstAsync(u => u.IdUsuario == usuarioDto.IdUsuario);
                _dbContext.Usuarios.Remove(encontrado);
                await _dbContext.SaveChangesAsync();
                ListaUsuario.Remove(usuarioDto);
            }
        }
    }
}
