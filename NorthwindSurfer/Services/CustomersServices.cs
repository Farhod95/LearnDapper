using Dapper;
using NorthwindSurfer.Models;

namespace NorthwindSurfer.Services
{
   public class CustomersServices: OrdersServices
    {
        public async Task GetAllCustomers()
        {
            string sqlQuery = """ Select * From Customers; """;
            List<Customers> customers = (await _dbContext.connection.QueryAsync<Customers>(sqlQuery)).ToList();
            foreach (var item in customers)
            {
                Console.WriteLine($" {item.CustomerID}  {item.CompanyName}  {item.ContactName}  {item.ContactTitle}  {item.Address}  {item.City}  {item.Region}  {item.PostalCode}  {item.Country}  {item.Phone}  {item.Fax}");
            }

        }

        public async Task GetByIdCustomers()
        {
            Console.Write(" Kerkli bo'lgan Customerning ID sini kiriting (M: TRAIH, ALFKI, CACTU,... ): ");
            string id = Console.ReadLine().ToUpper();

            string sqlQuery = """ Select * From Customers  where CustomerID = @customerID """;
            var customer = await _dbContext.connection.QueryFirstOrDefaultAsync(sqlQuery, new { customerID = id });

            Console.WriteLine($" {customer.CustomerID}  {customer.CompanyName}  {customer.ContactName}  {customer.ContactTitle}  {customer.Address}  {customer.City}  {customer.Region}  {customer.PostalCode}  {customer.Country}  {customer.Phone}  {customer.Fax}");

        }

        public async Task SearchByNameCustomers()
        {
            Console.Write(" Kerkli bo'lgan ContacName ni kiriting ( M: Carine, ris, ari, ...) : ");
            string contactName = Console.ReadLine();

            string sqlQuery = """ Select * From Customers where ContactName LIKE @cName; """;

            List<Customers> customers = (await _dbContext.connection.QueryAsync<Customers>(sqlQuery, new { cName = "%" + contactName + "%" })).ToList();

            foreach (var item in customers)
            {
                Console.WriteLine($" {item.CustomerID}  {item.CompanyName}  {item.ContactName}  {item.ContactTitle}  {item.Address}  {item.City}  {item.Region}  {item.PostalCode}  {item.Country}  {item.Phone}  {item.Fax}");
            }
        }
    }
}
