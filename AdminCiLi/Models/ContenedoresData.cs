using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCiLi.Models
{
    public class ContenedoresData
    {
        String comentario = "";
        String email_user = "";
        String id_tacho = "";
        String id_user = "";
        String imagenbase64 = "";
        String latitud = "";
        String longitud = "";
        String lugarDistrito = "";
        String tipoTacho = "";

        public string Comentario { get => comentario; set => comentario = value; }

       /* public string getComentario()
        {
            return this.comentario;
        }*/

        public string Email_user { get => email_user; set => email_user = value; }
        public string Id_user { get => id_user; set => id_user = value; }
        public string Id_tacho { get => id_tacho; set => id_tacho = value; }
        public string Imagenbase64 { get => imagenbase64; set => imagenbase64 = value; }
        public string Latitud { get => latitud; set => latitud = value; }
        public string Longitud { get => longitud; set => longitud = value; }
        public string LugarDistrito { get => lugarDistrito; set => lugarDistrito = value; }
        public string TipoTacho { get => tipoTacho; set => tipoTacho = value; }
    }
}