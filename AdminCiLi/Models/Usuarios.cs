using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminCiLi.Models
{
    public class Usuarios
    {
        String apellidos = "";
        String nombre = "";
        String email = "";
        String tipo = "";

        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Email { get => email; set => email = value; }
        public string Tipo { get => tipo; set => tipo = value; }
    }
}