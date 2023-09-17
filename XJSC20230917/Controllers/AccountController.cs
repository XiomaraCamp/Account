using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.AspNetCore.Authentication;

using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;


namespace XJSC20230917.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {

            if (login == "xio" && password == "12345")
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name , login),
                };



                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);



                var authProperties = new AuthenticationProperties();
                {

                };


                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), authProperties);


                return Ok("Inicio sesion correctamente.");
            }
            else
            {
                return Unauthorized("Credenciales incorrectas");
            }
        }


        [HttpPost("logout")]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);


            return Ok("Cerro sesion correctamente.");
        }
    }
}
