﻿using System;

namespace Registro_de_Usuario.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public String Nombre { get; set; }
        public String Clave { get; set; }

        /*[ForeignKey(UsuaioId)]
        public virtual Usuarios Usuarios { get; set; }*/
    }
}
