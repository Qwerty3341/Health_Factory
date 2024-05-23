using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Health_Factory.Utilidades
{
    public class UsuarioMensajeria : ValueChangedMessage<UsuarioMensaje>
    {
        public UsuarioMensajeria(UsuarioMensaje value) : base(value)
        {

        }
    }
}
