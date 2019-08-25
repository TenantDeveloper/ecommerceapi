using AutoMapper;
using ecommerce_DAL;
using ecommerce_UnitOfWork;
using ecommerceServices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ecommerceServices.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private readonly UOW uow = new UOW();

        public IHttpActionResult GetAll()
        {
            try
            {
                List<Sp_GetProducts_Result> products = uow.GetProduct().ToList();
                if(products != null)
                {
                    IEnumerable<ProductDto> productDtos = Mapper.Map<IEnumerable<ProductDto>>(products);
                    return Ok(productDtos);

                }
                else
                {
                    return Ok(new {status=false , message = "not found products" });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id:int}",Name = "GetProduct")]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = uow.ProductManager.GetEntity(id);
            if (product == null) return BadRequest("not found product");
            ProductDto productDto =  Mapper.Map<Product,ProductDto> (product);
            return Ok(productDto);
        }
        [HttpGet]
        [Route("{productName}")]
        public IHttpActionResult GetProduct(string productName)
        {
            IEnumerable<Product> products =  uow.ProductManager.GetProductByName(productName);
            IEnumerable<ProductDto> productDtos = Mapper.Map<IEnumerable<Product>,IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]ProductVm model)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errors =   ModelState.Values.SelectMany(e => e.Errors).Select(e =>e.ErrorMessage);
                return BadRequest(String.Join(",",errors));
            }

            try
            {
               Product product =   Mapper.Map<ProductVm,Product>(model);
                uow.CreateProduct(product);
                return Ok(new { status = true, message = "create product successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut]
        [Route("Update/{id:int}")]
        public HttpResponseMessage PutProduct([FromUri]int id, ProductVm model)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errors = ModelState.Values.SelectMany(e => e.Errors).Select(e => e.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest,String.Join(",", errors));
            }

            Product product =  uow.ProductManager.GetEntity(id);
            if (product == null) return Request.CreateResponse(HttpStatusCode.BadRequest,"product not found");
            Product prod = Mapper.Map<ProductVm, t>(model);
            prod.Id = product.Id;
            uow.UpdateProduct(prod);
            var response =   Request.CreateResponse(HttpStatusCode.OK, new { status = true, message = "product updated successfully" });
            string uri = Url.Link("GetProduct", new { id = prod.Id});
            response.Headers.Location = new Uri(uri);
            return response;
           // return Ok(new { status = true, message = "product updated successfully" });
        }
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = uow.ProductManager.GetEntity(id);
            if (product == null) return BadRequest("product not found");

            uow.ProductManager.Delete(product);
            bool executed = await uow.SaveAsync();
            if (executed)
                return Ok(new { status = true, message = "product was deleted successfully" });
            else
                return BadRequest("Something wrong has been happened");

        }

       
    }
}
