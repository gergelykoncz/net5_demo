using EFDemo1.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EFDemo1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return this.Ok(context.Products);
        }
    }
}
