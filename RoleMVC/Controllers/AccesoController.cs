using Microsoft.AspNetCore.Mvc;
using RoleMVC.Data;
using RoleMVC.Models;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace RoleMVC.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {
            DataLogica data = new DataLogica();
            var usuario = data.validarUsuario(_usuario.Correo, _usuario.Clave);
            if (usuario != null)
            {
                //trabajando con las cookies
                //creando cookies para las administracion de las paginas
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,usuario.Nombre),
                    new Claim("Correo", usuario.Correo)
                };
                foreach (string rol in usuario.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, rol));
                }
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View();
            }
        }
        public async Task<IActionResult> Salir()
        {
            //eliminando la cookie una vez que presiones el boton salir
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Acceso");
        }

    }
}

