

using System.Collections;
using Controller.Models;
using Controller.Services;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private readonly ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<Pizza> GetPizza(int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza is null){
                return NotFound();
            }
            return pizza;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> GetAllPizza()
        {
            return PizzaService.GetAll();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id){
            if(PizzaService.Delete(id)){
                return Content("Pizza deleted sucessfully");
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePizza(int id, Pizza pizza){
            if(id!= pizza.Id){
                return BadRequest();
            }
            if(PizzaService.Update(pizza)){
                return Content("Pizza updates sucessfully");
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreatePizza(Pizza pizza){
            PizzaService.Create(pizza);
            return CreatedAtAction(nameof(GetPizza),new{id = pizza.Id},pizza);
        }
    }
}