using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto_udemy.Models
{
    public class usuario //creamos ala base de datos, tabla desde aqui, con clases
    {
        [Key] //llave primaria

        public int id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")] //el campo tiene que ser requerido

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El telefono es obigatorio ")]
        [Display( Name ="Teléfono")]//puedo colocar acentos etc, dysplay para telefono

        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Celular es obligatorio")] //el campo tiene que ser requerido

        public string Celular { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio")] //el campo tiene que ser requerido

        public string Email { get; set; }
    }
}
