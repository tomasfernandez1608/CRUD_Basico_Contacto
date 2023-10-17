using System.ComponentModel.DataAnnotations;

namespace Contactos_CRUDCORE.Models
{
    public class ContactoModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Complete el campo Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Complete el campo Telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Complete el campo Correo")]
        public string Correo { get; set; }

    }
}
