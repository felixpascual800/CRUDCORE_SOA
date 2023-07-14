using Microsoft.AspNetCore.Mvc;

using CRUDCORE.Datos;
using CRUDCORE.Models;
using Microsoft.AspNetCore.Authorization;

namespace CRUDCORE.Controllers
{
   
    public class MantenedorController : Controller
    {


        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login");

            var oLista = _ContactoDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login");
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        public IActionResult Editar(int IdContacto)
        {
             if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login");
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel oContacto)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ContactoDatos.Editar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int IdContacto)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ContactoDatos.Obtener(IdContacto);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel oContacto)
        {
  
            var respuesta = _ContactoDatos.Eliminar(oContacto.IdContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();


        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            // Validar las credenciales del usuario consultando la base de datos
            var usuario = _ContactoDatos.ObtenerUsuario(model.Username);

            if (usuario != null && usuario.Password == model.Password)
            {
                // Iniciar sesión exitosamente
                HttpContext.Session.SetString("Username", model.Username);
                return RedirectToAction("Listar");
            }
            else
            {
                // Credenciales inválidas, mostrar mensaje de error
                ViewBag.Error = "Credenciales inválidas.";
                return View();
            }
        }





    }
}
