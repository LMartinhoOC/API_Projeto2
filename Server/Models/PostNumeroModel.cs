using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class PostNumeroModel
    {
        [Required(ErrorMessage = "O número é obrigatório")]
        public int Numero { get; set; }
    }
}