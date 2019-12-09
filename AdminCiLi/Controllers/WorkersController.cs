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

                if (DatosUsuarioList.Tipo == "colaborador" || DatosUsuarioList.Tipo == "Colaborador")
                {
                    MatrizUsuariosList.Add(DatosUsuarioList);
                }                
            }

            //Pass data to the view
            ViewBag.InfoUsuarios = MatrizUsuariosList;
            return View();
        }

        public async Task<ActionResult> Perfil(String id_usuario)
        {
            //Save non identifying data to Firebase
            var firebaseClient = new FirebaseClient("https://rotcleanlast.firebaseio.com/");

            var dbUsuarios = await firebaseClient.Child("Usuarios").Child("2gFSHTMzJ4T6olEsUP2HpGoXq3t1").OnceSingleAsync<Usuarios>();

            var usuario = new Usuarios();

            //Convert JSON data to original datatype

            usuario.Apellidos = dbUsuarios.Apellidos;
            usuario.Nombre = dbUsuarios.Nombre;
            usuario.Email = dbUsuarios.Email;
            usuario.Direccion = dbUsuarios.Direccion;
            usuario.Telefono = dbUsuarios.Telefono;
            usuario.Tipo = dbUsuarios.Tipo;
            
            //Pass data to the view
            ViewBag.InfoUsuario = usuario;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Nuevo(String Apellidos, String Nombre, String Email, String Direccion, String Telefono)
        {            
            Usuarios user = new Usuarios();

            user.Apellidos = Apellidos;
            user.Nombre = Nombre;
            user.Email = Email;
            user.Direccion = Direccion;
            user.Telefono = Telefono;
            user.Tipo = "Colaborador";

            //Save non identifying data to Firebase
            var firebase = new FirebaseClient("https://rotcleanlast.firebaseio.com/");

            await firebase
            .Child("Usuarios")
            .PostAsync(user);

            return RedirectToAction("Trabajadores");
        }
    }
}