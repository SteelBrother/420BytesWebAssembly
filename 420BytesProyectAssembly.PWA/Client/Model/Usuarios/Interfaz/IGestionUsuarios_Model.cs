using _420BytesWebAssembly.DT.Usuario;

namespace _420BytesProyectAssembly.PWA.Client.Model.Usuarios.Interfaz
{
    public interface IGestionUsuarios_Model
    {
        Task<bool> ActualizarUsuario(Usuario Usuario);
        Task<List<Usuario>> ConsultarUsuarios();
        Task<Usuario> ConsultarUsuarioPorCedula(int Cedula);
        Task<bool> RegistrarUsuario(Usuario Usuario);
        Task<bool> BorrarUsuario(int Cedula);

    }
}
