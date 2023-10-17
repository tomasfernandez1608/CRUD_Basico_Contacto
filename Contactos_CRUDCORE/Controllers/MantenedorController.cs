using Microsoft.AspNetCore.Mvc;
using Contactos_CRUDCORE.Datos;
using Contactos_CRUDCORE.Models;

namespace Contactos_CRUDCORE.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos _ContactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            // La vista mostrara una lista de contactos
            var oLista = _ContactoDatos.Listar();
            return View(oLista);
        }
        public IActionResult Guardar()
        {
            //Metodo que solo devuelve la vista de nuestro formulario html 
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel oContacto)
        {
            //Metodo que recibe un objeto para guardarlo en la Base Datos 

            if (!ModelState.IsValid) { return View(); } 


            var respuesta = _ContactoDatos.Guardar(oContacto);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Editar(int ID)
        {
            var oContacto = _ContactoDatos.ObtenerByID(ID);

            return View(oContacto);
        }

        [HttpPost]

        public IActionResult Editar(ContactoModel oContacto)
        {

            if (!ModelState.IsValid) { return View(); }

            var Respuesta = _ContactoDatos.Editar(oContacto);
            if(Respuesta)
            {
                return RedirectToAction("Listar");
            }
            return View();
        }

        public IActionResult Eliminar(int ID)
        {
            var oContacto = _ContactoDatos.ObtenerByID(ID);

            return View(oContacto);
        }

        [HttpPost]

        public IActionResult Eliminar(ContactoModel oContacto)
        {
            var resultado = _ContactoDatos.Eliminar(oContacto.ID);

            if(resultado)
                return RedirectToAction("Listar");
            else
                return RedirectToAction("ErrorEliminar");

        }

        public IActionResult ErrorEliminar()
        {
            return View();
        }
    }
}
