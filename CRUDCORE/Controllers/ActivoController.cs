using CRUDCORE.Datos;
using CRUDCORE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDCORE.Controllers
{
    [Authorize]
    public class ActivoController : Controller
    {
        ActivoDatos _ActivoDatos = new ActivoDatos();

        public IActionResult Index()

        {
            if (HttpContext.Session.GetString("Username") == null)
                return RedirectToAction("Login");

            var oLista = _ActivoDatos.Listar();

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
        public IActionResult Guardar(ActivoModel oactivo)
        {
            if (ModelState.IsValid)
          
            return View(oactivo);
            var respuesta = _ActivoDatos.Guardar(oactivo);

            if (respuesta)
                return RedirectToAction("Index");
            else
                return View();
        }

        public IActionResult Edit(int id)
        {
            // Aquí puedes obtener el activo por su ID desde la base de datos y mostrarlo en la vista de edición
            ActivoModel activo = new ActivoModel { IdActivo = id, Nombre = "Activo " + id, Descripcion = "Descripción del activo " + id, Estado = "Activo" };

            return View(activo);
        }

        [HttpPost]
        public IActionResult Edit(ActivoModel activo)
        {
            if (ModelState.IsValid)
            {
                // Aquí puedes actualizar el activo en la base de datos

                // Redireccionar a la página de lista de activos después de editar el activo
                return RedirectToAction("Index");
            }

            return View(activo);
        }

        public IActionResult Delete(int id)
        {
            // Aquí puedes obtener el activo por su ID desde la base de datos y mostrarlo en la vista de confirmación de eliminación
            ActivoModel activo = new ActivoModel { IdActivo = id, Nombre = "Activo " + id, Descripcion = "Descripción del activo " + id, Estado = "Activo" };

            return View(activo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Aquí puedes eliminar el activo de la base de datos

            // Redireccionar a la página de lista de activos después de eliminar el activo
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            // Aquí puedes obtener el activo por su ID desde la base de datos y mostrarlo en la vista de detalles
            ActivoModel activo = new ActivoModel { IdActivo = id, Nombre = "Activo " + id, Descripcion = "Descripción del activo " + id, Estado = "Activo" };

            return View(activo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
