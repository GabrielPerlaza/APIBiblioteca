﻿using System.ComponentModel.DataAnnotations;

namespace APIBiblioteca.Model
{
    public class MenuRol
    {
        [Key]
        public int IdMenuRol { get; set; }

        public int? IdMenu { get; set; }

        public int? IdRol { get; set; }

        public virtual Menu? IdMenuNavigation { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
    }
}
