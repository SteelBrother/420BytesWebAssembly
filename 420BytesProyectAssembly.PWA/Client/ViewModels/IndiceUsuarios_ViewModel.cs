using _420BytesProyectAssembly.PWA.Client.Model.Usuarios.Interfaz;
using _420BytesProyectAssembly.PWA.Client.ViewModels.Interfaces;
using _420BytesWebAssembly.DT.Usuario;

namespace _420BytesProyectAssembly.PWA.Client.ViewModels
{
    public class IndiceUsuarios_ViewModel : IIndiceUsuarios_ViewModel
    {
        private readonly IGestionUsuarios_Model IGestionUsuariosModel;
        //private readonly IMostrarMensajes MostrarMensajes;
        public IndiceUsuarios_ViewModel(IGestionUsuarios_Model IGestionUsuariosModel)
        {
            this.IGestionUsuariosModel = IGestionUsuariosModel;
            //this.MostrarMensajes = MostrarMensajes;
        }

        public List<Usuario> Usuarios { get; set; } = new();
        public Usuario Usuario { get; set; }
        public bool Respuesta { get; set; } = false;

        public async Task ActualizarUsuario(Usuario usuario)
        {
            Respuesta = await IGestionUsuariosModel.ActualizarUsuario(usuario);
            //if (Respuesta)
            //{
            //    await MostrarMensajes.MostrarMensajeExitoso("Usuario actualizado con exito");
            //}
            //else
            //{
            //    await MostrarMensajes.MostrarMensajeExitoso("Error actualizando el usuario");
            //}
        }

        public async Task BorrarUsuario(int Cedula)
        {
            try
            {
                Respuesta = await IGestionUsuariosModel.BorrarUsuario(Cedula);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Se ha producido una excepción: " + ex.Message);
            }

        }

        public async Task ConsultarUsuarioPorCedulaAsync(int Cedula)
        {
            Usuario = await IGestionUsuariosModel.ConsultarUsuarioPorCedula(Cedula);
            //if (Usuario == null)
            //{
            //    await MostrarMensajes.MostrarMensajeExitoso("Error consultando el usuario");
            //}        
        }

        public async Task ObtenerListaUsuariosAsync()
        {
            Usuarios = await IGestionUsuariosModel.ConsultarUsuarios();
            //if (!Respuesta)
            //{
            //    await MostrarMensajes.MostrarMensajeExitoso("Error consultando los usuarios");
            //}
        }

        public async Task RegitrarUsuario(Usuario Usuario)
        {
            Respuesta = await IGestionUsuariosModel.RegistrarUsuario(Usuario);
            //if (Respuesta)
            //{
            //    await MostrarMensajes.MostrarMensajeExitoso("Usuario registrado con exito");
            //}
            //else
            //{
            //    await MostrarMensajes.MostrarMensajeExitoso("Error registrando el usuario");
            //}
        }
    }
}
