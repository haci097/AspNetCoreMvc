using System.Globalization;

namespace AspNetCoreMvc.Models
{
    public class ProductDetailDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
