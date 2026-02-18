using Dapper;
using NorthwindSurfer.Data;
using NorthwindSurfer.Models;

namespace NorthwindSurfer.Services
{
    public class ProductsServices: OrdersServices
    {
        public async Task GetAllProducts()
        {
            string sqlQuery = """ Select * From Products; """;

            List<Products> products = (await _dbContext.connection.QueryAsync<Products>(sqlQuery)).ToList();

            foreach (var item in products)
            {
                Console.WriteLine($" {item.Id}  {item.ProductName}  {item.SupplierID}  {item.CategoryID}  {item.QuantityPerUNit}  {item.UnitPrice}  {item.UnitslnStock}  {item.UnitsOnOrder}  {item.ReorderLevel}  {item.Discontinued}");
            }
        }

        public async Task GetByIdProducts()
        {
            Console.Write(" Kerkli bo'lgan Products ID sini kiriting (1 => 77): ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (id < 1 || id > 77)
                {
                    Console.WriteLine(" Noto'g'ri amal kiritdingiz !");
                }
                else
                {
                    string sqlQuery = """ Select * From Products where ProductID = @ProductID """;
                    var product = await _dbContext.connection.QueryFirstOrDefaultAsync(sqlQuery, new { ProductID = id });

                    Console.WriteLine($" {product.Id} \n {product.ProductName} \n {product.SupplierID} \n {product.CategoryID} \n {product.QuantityPerUNit} \n {product.UnitPrice} \n {product.UnitslnStock} \n {product.UnitsOnOrder} \n {product.ReorderLevel} \n {product.Discontinued}");
                }
            }
            else
            {
                Console.WriteLine(" Noto'g'ri amal kiritdingiz !");
            }
        }

        public async Task SearchByNameProducts()
        {
            string sqlQuery = """ Select * From Products Where ProductName like @cName; """;

            Console.Write(" Kerkli bo'lgan ProductName ni kiriting ( M: Filo, aan, nbr, ...) : ");
            string contactName = Console.ReadLine();

            List<Products> products = (await _dbContext.connection.QueryAsync<Products>(sqlQuery, new { cName = "%" + contactName + "%" })).ToList();

            foreach (var item in products)
            {
                Console.WriteLine();
                Console.WriteLine($" {item.Id}  {item.ProductName}  {item.SupplierID}  {item.CategoryID}  {item.QuantityPerUNit}  {item.UnitPrice}  {item.UnitslnStock}  {item.UnitsOnOrder}  {item.ReorderLevel}  {item.Discontinued}");
            }
        }
    }
}
