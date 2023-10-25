using Server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroController : ControllerBase
    {
        public List<int> Numeros { get; set; }

        public NumeroController()
        {
            Numeros = new List<int>()
            {
                5, 
                10, 
                20,
                40,
                80 
            };
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [Route("numero")]
        public ActionResult GetNumeros()
        {
            return Ok(Numeros);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [Route("numero")]
        public ActionResult PostNumero([FromBody] PostNumeroModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Numeros.Add(model.Numero);
                return Ok(Numeros);
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [Route("numero")]
        public ActionResult PutNumero([FromBody] PutNumeroModel model)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            else if(!Numeros.Contains(model.NumeroAtual))
            {
                return BadRequest("O número atual não existe na lista");
            }
            else
            {
                int indice = Numeros.IndexOf(model.NumeroAtual);
                Numeros.Remove(model.NumeroAtual);
                Numeros.Insert(indice, model.NumeroNovo);
                return Ok(Numeros);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("numero")]
        public ActionResult DeleteNumero([FromBody] DeleteNumeroModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if(!Numeros.Contains(model.Numero))
            {
                return BadRequest("Numero não encontrado na lista!");
            }
            else
            {
                Numeros.Remove(model.Numero);
                return Ok(Numeros);
            }
        }
    }
}
