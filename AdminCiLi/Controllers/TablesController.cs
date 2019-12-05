using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AdminCiLi.Models;

using Firebase.Database;
using Firebase.Database.Query;

namespace AdminCiLi.Controllers
{
    public class TablesController : Controller
    {
        // GET: Tables
        public ActionResult Index()
        {
            return View();
        }

        /*public ActionResult Data()
        {
            return View();
        }*/

        public async Task<ActionResult> Data()
        {
            //Save non identifying data to Firebase
            var firebaseClient = new FirebaseClient("https://rotcleanlast.firebaseio.com/");

            var dbTachos = await firebaseClient.Child("Tachos").OnceAsync<ContenedoresData>();

            var MatrizContenedorList = new List<ContenedoresData>();

            //Convert JSON data to original datatype

            foreach (var infoTacho in dbTachos)
            {
                var DatosContenedorList = new ContenedoresData();

                DatosContenedorList.Imagenbase64 = "Imagen Contenedor";
                DatosContenedorList.TipoTacho = infoTacho.Object.TipoTacho;
                DatosContenedorList.Email_user = infoTacho.Object.Email_user;
                DatosContenedorList.Comentario = infoTacho.Object.Comentario;
                DatosContenedorList.Latitud = infoTacho.Object.Latitud;
                DatosContenedorList.Longitud = infoTacho.Object.Longitud;
                DatosContenedorList.Id_user = infoTacho.Object.Id_user;
                DatosContenedorList.Id_tacho = infoTacho.Object.Id_tacho;
                DatosContenedorList.LugarDistrito = infoTacho.Object.LugarDistrito;

                MatrizContenedorList.Add(DatosContenedorList);
            }            

            //Pass data to the view
            ViewBag.InfoContenedores = MatrizContenedorList;
            return View();

        }
        [HttpPost]
        public async Task<ActionResult> Eliminar(String btnEliminar)
        {
            var firebase = new FirebaseClient("https://rotcleanlast.firebaseio.com/");
            System.Diagnostics.Debug.WriteLine(btnEliminar);
            // delete given child node
            await firebase
              .Child("Tachos")
              .Child(btnEliminar)
              .DeleteAsync();

            return RedirectToAction("Data");
        }
    }
}