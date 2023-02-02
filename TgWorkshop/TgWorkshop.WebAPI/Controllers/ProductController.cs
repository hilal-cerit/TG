using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using NuGet.Protocol;
using System.Transactions;
using TgWorkshop.WebAPI.Models;
using TgWorkshop.WebAPI.Repository;
using Newtonsoft.Json;
using TgWorkshop.WebAPI.DBContexts;

namespace TgWorkshop.WebAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductContext _dbContext;

        public ProductController(IProductRepository productRepository, ProductContext dbContext)
        { _dbContext= dbContext; 
            _productRepository = productRepository;
        }
        //[HttpPost]
        //public JsonResult GetProduct(decimal price)
        //{

        //    List<Product> products = _dbContext.Set<Product>().ToList();
        //    Product product = products.FirstOrDefault(o => o.Price == price);
        //    return Json(product, System.Web.Mvc.JsonRequestBehavior.AllowGet);

        //}


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            try
            {
               
                return Ok( await _productRepository.Add(product));
            }
            catch (Exception exc)
            {

                return BadRequest(exc.Message);
            }
                 
         
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromBody] int id)
        {
            try
            {
                if (_productRepository.Get(p => p.Id == id) == null)
                {
                    await _productRepository.Delete(await _productRepository.Get(p => p.Id == id));
                    return Ok();
                }
                else
                {
                    return BadRequest("There isn't data with this id");    
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from database");
            }
          
          
        }


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await _productRepository.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");

            }

        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {//JSON.Parse()
                return Ok(_productRepository.Get(p => p.Id == id));
            }
            catch (Exception ex)
            {
                return BadRequest("There isn't any product with this id"); ;

            }
        }


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            try
            {
                return Ok(await _productRepository.Update(product));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
