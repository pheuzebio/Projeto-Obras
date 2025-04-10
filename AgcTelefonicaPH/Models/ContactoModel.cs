using System.ComponentModel.DataAnnotations;

namespace AgcTelefonicaPH.Models
{
    public class ContactoModel
    {
        public int id { get; set; }
        //[Required(ErrorMessage = "Insira o nome do Cliente")]
        public String Cliente { get; set; }
        [Required(ErrorMessage = "Insira o contacto do Cliente")]
        //[Phone(ErrorMessage = "O número de telemóvel não é válido!")]
        public String ContactoN { get; set; }
        //[Required(ErrorMessage = "Insira a Cidade do Cliente")]
        public String Cidade { get; set; }
  
        public byte[] Imagem { get; set; }
    }
}
