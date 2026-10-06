using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services
{
    
    public class AutenticacaoService : Services, IAutenticacaoService
    {
        private readonly HttpClient _httpcliente;

        public AutenticacaoService(HttpClient httpcliente)
        {
            _httpcliente = httpcliente;
        }
        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpcliente.PostAsync("https://localhost:5002/api/identidade/autenticar", loginContent);
            
            if (!TratarErrorsResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }
            
            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);
            var response = await _httpcliente.PostAsync("https://localhost:5002/api/identidade/nova-conta", registroContent);
            
            if (!TratarErrorsResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response); 
        }
    }
}