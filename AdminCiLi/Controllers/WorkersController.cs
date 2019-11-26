using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AdminCiLi.Models;
using Firebase.Database;

namespace AdminCiLi.Controllers
{
    public class WorkersController : Controller
    {
        // GET: Workers
        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Trabajadores()
        {
            //Save non identifying data to Firebase
            var firebaseClient = new FirebaseClient("https://rotcleanlast.firebaseio.com/");

            var dbUsuarios = await firebaseClient.Child("Usuarios").OnceAsync<Usuarios>();

            var MatrizUsuariosList = new List<Usuarios>();

            //Convert JSON data to original datatype

            foreach (var infoUsuario in dbUsuarios)
            {
                var DatosUsuarioList = new Usuarios();

                DatosUsuarioList.Apellidos = infoUsuario.Object.Apellidos;
                DatosUsuarioList.Nombre = infoUsuario.Object.Nombre;
                DatosUsuarioList.Email = infoUsuario.Object.Email;
                DatosUsuarioList.Tipo = infoUsuario.Object.Tipo;

                MatrizUsuariosList.Add(DatosUsuarioList);
            }

            //Pass data to the view
            ViewBag.InfoUsuarios = MatrizUsuariosList;
            return View();
        }
    }
}