using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class PostAuthLoginModel
    {
        [Required(ErrorMessage = "O login é obrigatório")]
        public string login { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string password { get; set; }
    }
}
