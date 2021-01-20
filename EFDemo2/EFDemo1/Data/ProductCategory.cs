using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo1.Data
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("ProductCategory")]
        public ICollection<Product> Products { get; set; }
    }
}
