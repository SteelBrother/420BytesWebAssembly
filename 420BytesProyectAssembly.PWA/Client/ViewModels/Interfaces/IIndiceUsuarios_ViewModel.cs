using _420BytesWebAssembly.DT.Usuario;

namespace _420BytesProyectAssembly.PWA.Client.ViewModels.Interfaces
{
    public interface IIndiceUsuarios_ViewModel
    {
        Task ObtenerListaUsuariosAsync();
        Task ConsultarUsuarioPorCedulaAsync(int Cedula);
        List<Usuario> Usuarios { get; set; }
        bool Respuesta { get; set; }
        Usuario Usuario { get; set; }

        Task RegitrarUsuario(Usuario usuario);
        Task ActualizarUsuario(Usuario usuario);
        Task BorrarUsuario(int Cedula);
    }
}
