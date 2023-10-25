using _420BytesProyectAssembly.PWA.Client.Helpers.Interfaces;
using _420BytesProyectAssembly.PWA.Client.Model.Interfaces;
using _420BytesProyectAssembly.PWA.Client.Model.Usuarios.Interfaz;
using _420BytesWebAssembly.DT.Usuario;
using System.Reflection;
using System.Runtime;

namespace _420BytesProyectAssembly.PWA.Client.Model.Usuarios
{
    public class GestionUsuarios_Model : IGestionUsuarios_Model
    {
        private readonly IConexionRest ConexionRest;
        private readonly ISettings ISettings;
        private readonly ILogger<IGestionUsuarios_Model> logger;
        public GestionUsuarios_Model(IConexionRest conexionRest, ILogger<IGestionUsuarios_Model> logger, ISettings ISettings)
        {
            this.ConexionRest = conexionRest;
            this.logger = logger;
            this.ISettings = ISettings;
        }
        public async Task<bool> ActualizarUsuario(Usuario Usuario)
        {
            try
            {
                var ApiUrl = ISettings.GetApiUrl();
                var httpResponse = await ConexionRest.Put<Usuario, bool>($"{ApiUrl}/Usuarios/ActualizarUsuario", Usuario);
                if (httpResponse.Error)
                {
                    logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
            }
            return false;
        }

        public async Task<bool> BorrarUsuario(int Cedula)
        {
            try
            {
                var ApiUrl = ISettings.GetApiUrl();
                var httpResponse = await ConexionRest.Delete($"{ApiUrl}/Usuarios/BorrarUsuario/{Cedula}");
                if (httpResponse.Error)
                {
                    logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return false;

        }

        public async Task<Usuario> ConsultarUsuarioPorCedula(int Cedula)
        {
            try
            {
                var ApiUrl = ISettings.GetApiUrl();
                var HttpReponse = await ConexionRest.Get<Usuario>($"{ApiUrl}/Usuarios/ConsultarUsuarioPorCedula?Cedula={Cedula}");
                if (HttpReponse.Error)
                {
                    logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}");
                }
                else
                {
                    return HttpReponse.Response;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
            }
            return null;
        }

        public async Task<List<Usuario>> ConsultarUsuarios()
        {
            try
            {
                var ApiUrl = ISettings.GetApiUrl();
                var httpResponse = await ConexionRest.Get<List<Usuario>>($"{ApiUrl}/Usuarios/ConsultaUsuarios");
                if (httpResponse.Error)
                {
                    logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}");
                }
                else
                {
                    return httpResponse.Response.ToList();
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
            }
            return new List<Usuario>();
        }

        public async Task<bool> RegistrarUsuario(Usuario Usuario)
        {
            try
            {
                var ApiUrl = ISettings.GetApiUrl();
                var httpResponse = await ConexionRest.Post<Usuario, bool>($"{ApiUrl}/Usuarios/RegistrarUsuario", Usuario);
                if (httpResponse.Error)
                {
                    logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}");
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Clase: {GetType().Name}, Metodo: {MethodBase.GetCurrentMethod().DeclaringType.Name}, Tipo: {ex.GetType()}, Error: {ex.Message}");
            }
            return false;
        }
    }
}
