using act2_4.Data;
using act2_4.Domain;
using act2_4.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace act2_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController()
        {
            _service = new ProductoService();
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_service.GetAll());
        [HttpGet("/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var producto = _service.GetById(id);
            if (producto != null)
            {
                return Ok(_service.GetById(id));
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            _service.AddProduct(producto);
            return Ok();
        }
      
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.DeleteProduct(id);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Producto producto,int id)
        {
            var productoExists = _service.GetById(id);
            if (productoExists != null)
            {
                _service.EditProduct(producto);

                return Ok();
            }
            return BadRequest();
        }


    }
}
