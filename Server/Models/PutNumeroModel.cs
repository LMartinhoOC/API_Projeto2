using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class PutNumeroModel
    {
        [Required(ErrorMessage = "O número atual é obrigatório")]
        public int NumeroAtual { get; set; }
        [Required(ErrorMessage = "O número novo é obrigatório")]
        public int NumeroNovo { get; set; }
    }
}
