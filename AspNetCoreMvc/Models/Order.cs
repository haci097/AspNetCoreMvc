namespace AspNetCoreMvc.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string ShipName { get; set; }= string.Empty;
        public string ShipCity { get; set; } = string.Empty;
        public string ShipPostalCode { get; set; } = string.Empty;
        public decimal Freight { get; set; }
    }
}
