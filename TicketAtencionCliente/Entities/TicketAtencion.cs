using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketAtencionCliente.Entities
{
    public class TicketAtencion
    {
        [Key]
        public int IdTicket { get; set; }

        [Column(TypeName = "int")]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "El campo id es obligatorio")]
        public int Id { get; set; }

        [Column(TypeName = "varchar(75)")]
        [Display(Name = "Nombres")]
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string Nombres { get; set; }

        [Column(TypeName = "int")]
        [Display(Name = "ColaAsignada")] 
        //cola1 o cola 2
        public int ColaAsignada { get; set; }

        [Column(TypeName = "int")]
        [Display(Name = "Estado")]
        //estado 0 o estado 1 
        public int Estado { get; set; }

    }
}
