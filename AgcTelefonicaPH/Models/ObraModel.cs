using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AgcTelefonicaPH.Models
{
    public class ObraModel
    {      
        public int id { get; set; }
        //[Required(ErrorMessage = "Insira o nome do Cliente")]
        public String Descricao { get; set; }
        // [Required(ErrorMessage = "Insira o contacto do Cliente")]
        //[Phone(ErrorMessage = "O número de telemóvel não é válido!")]
        [ForeignKey("Contacto")]
        public int idCliente { get; set; }    
        public String DatIni { get; set; }
        //[Required(ErrorMessage = "Insira a Cidade do Cliente")]
        public String DatFim { get; set; }
        public ContactoModel Contacto { get; set; }
    }
}
