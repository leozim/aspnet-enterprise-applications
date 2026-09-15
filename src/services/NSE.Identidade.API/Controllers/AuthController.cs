using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identidade.API.Extensions;
using NSE.Identidade.API.Models;

namespace NSE.Identidade.API.Controllers
{
    [Route("api/identidade")]
    public class AuthController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AuthController(SignInManager<IdentityUser> signInManager, 
                              UserManager<IdentityUser> userManager, AppSettings appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings;
        }
        
        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new IdentityUser
            {
                UserName = usuarioRegistro.Email,
                Email = usuarioRegistro.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }

            return BadRequest();
        }
        
        [HttpPost("autenticar")]
        public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, 
                usuarioLogin.Senha, 
                false, 
                true);

            if (result.Succeeded) return Ok();
            
            return BadRequest();
        }
        
        
    }
}