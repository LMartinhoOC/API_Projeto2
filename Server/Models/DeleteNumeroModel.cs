using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class DeleteNumeroModel
    {
        [Required(ErrorMessage = "O número é obrigatório")]
        public int Numero { get; set; }
    }
}
