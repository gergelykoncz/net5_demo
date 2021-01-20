﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo1.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
