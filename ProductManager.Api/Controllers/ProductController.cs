using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.Dtos;
using Services;

namespace ProductManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productsRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productsRepository = productRepository;

        }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetListOfProducts()
        {
            var listOfProducts = _productsRepository.GetProducts();

            var productList = new List<ProductDto>();
            foreach(var product in listOfProducts)
            {
                productList.Add(new ProductDto
                {
                    Name=product.Name,
                    Price=product.Price,
                    Id=product.Id


                });
            }

            return Ok(productList);
        }

        // GET api/Product/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
        [HttpGet("{id}")]
        public IActionResult GetProductById(Guid id)
        {
            var product = _productsRepository.GetProductById(id);

            return Ok(product);
        }

        // POST api/Product
        [HttpPost]
        public IActionResult CreateProduct([FromBody]ProductDto product)
        {
            var newProduct = _productsRepository.AddProduct(product.Name, product.Price);

            if (!newProduct)
            {
                ModelState.AddModelError("", $"Something went wrond, try again");
                return StatusCode(500, ModelState);
            }

            return Ok(newProduct);
        }

        // PUT: api/Product/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, [FromBody] Product product)
        {
            var productToUpdate = _productsRepository.UpdateProduct(id, product);

            if (!productToUpdate)
            {
                ModelState.AddModelError("", $"Please check If data you entered are valid and make sure the product wasn't deleted already, product should contain: unique ID, NAME, PRICE");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        // DELETE: api/Product/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var productToDelete = _productsRepository.DeleteProduct(id);

            if (!productToDelete)
            {
                ModelState.AddModelError("", $"Sorry, the product was not deleted successfully");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

    }
}
