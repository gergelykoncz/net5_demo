﻿using EFDemo1.Data;
using EFDemo1.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EFDemo1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var products = this.productService.GetProducts();
            return this.Ok(products);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Product>> Post(Product product)
        {
            var products = this.productService.UpsertProduct(product);
            return this.Ok(products);
        }
    }
}
