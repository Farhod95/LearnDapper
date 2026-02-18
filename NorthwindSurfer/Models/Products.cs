namespace NorthwindSurfer.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        public string? QuantityPerUNit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? UnitslnStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public int? Discontinued { get; set; }
    }
}
