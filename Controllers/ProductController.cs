using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTenda.Entity;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTenda.Controllers
{
    /*Controlador de peticiones API*/

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private static List<Product> products = new List<Product>

        {

        };

        // GET: api/Product
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(products);
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Product
        // CONTROL: ID incremental
        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product newProduct)
        {
            if (newProduct == null)
            {
                return BadRequest("El producto no puede estar vacío.");
            }

            // Generar un ID incremental para el nuevo producto
            int newProductId = products.Count > 0 ? products.Max(p => p.Id) + 1 : 1;
            newProduct.Id = newProductId;

            products.Add(newProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = newProductId }, newProduct);
        }


        // PUT: api/Product/{id}
        //CONTROL: ID no editable
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product updatedProduct)
        {
            if (updatedProduct == null)
            {
                return BadRequest("El producto está vacío.");
            }

            var product = products.FirstOrDefault(p => p.Id == updatedProduct.Id);
            if (product == null)
            {
                return NotFound();
            }

            product.Nombre = updatedProduct.Nombre;
            product.Descripcion = updatedProduct.Descripcion;

            return NoContent();
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            products.Remove(product);
            return NoContent();  // Control de nulls
        }
    }
}
