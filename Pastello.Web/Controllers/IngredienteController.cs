using Microsoft.AspNetCore.Mvc;
using Pastello.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pastello.Web.Controllers
{
    [Route("[controller]")]

    public class IngredienteController : Controller
    {
        private readonly IRepositorio<Ingrediente> _repositorioIngrediente;

        public IngredienteController(IRepositorio<Ingrediente> repositorioIngrediente)
        {
            _repositorioIngrediente = repositorioIngrediente;
        }

        [HttpGet("")]
        public IActionResult Lista()
        {
            return Ok(_repositorioIngrediente.Lista().Select(s => new IngredienteModel(s)));
        }

        [HttpPut("{id}")]
        public IActionResult Atualiza(int id, [FromBody] IngredienteModel model)
        {
            _repositorioIngrediente.Atualiza(id, model.ToIngrediente());
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            _repositorioIngrediente.Exclui(id);
            return NoContent();

        }

        [HttpPost("")]
        public IActionResult Insere([FromBody] IngredienteModel model)
        {
            Ingrediente ingrediente = model.ToIngrediente();

            model.Id = _repositorioIngrediente.ProximoId();
            
            _repositorioIngrediente.Insere(ingrediente);
            return Created("", ingrediente);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            return Ok(new IngredienteModel(_repositorioIngrediente.Lista().FirstOrDefault(s => s.Id == id)));
        }
    }
}

