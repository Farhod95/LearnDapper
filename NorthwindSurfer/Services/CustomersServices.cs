using Dapper;
using NorthwindSurfer.Models;

namespace NorthwindSurfer.Services
{
   public class CustomersServices: OrdersServices
    {
        public async Task CreateCustomers()
        {
            string sqlQuery = """                   
                INSERT INTO Customers (CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax) 
                VALUES (@CustomerID, @CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax);
                """;

            var anonimObject = new
            {
                CustomerID = "UZBEK",
                CompanyName = "Najot Ta'lim",
                ContactName = "Alisher Navoiy",
                ContactTitle = "Owner",
                Address = "Chorsu 12",
                City = "Toshkent",
                Region = "Toshkent",
                PostalCode = "100000",
                Country = "Uzbekistan",
                Phone = "+998 90 123 45 67",
                Fax = (string)null
            };

            var rowsUpdate = await _dbContext.connection.ExecuteAsync(sqlQuery, anonimObject);
            if (rowsUpdate > 0)
            {
                Console.WriteLine($" {rowsUpdate} ta qatoor qo'shildi");
            }
            else
            {
                Console.WriteLine(" Yangi qator qo'shilmadi");
            }
        }
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

        public async Task UpdateCustomers()
        {
            string sqlQuery = """                                
                update Customers
                set City='Tashkent'
                where CustomerID='UZBEK';
                """;

            var rowsUpdate = await _dbContext.connection.ExecuteAsync(sqlQuery);

            if (rowsUpdate > 0)
            {
                Console.WriteLine($" {rowsUpdate} ta qator yangilandi: City Toshkentdan Tashkentga o'zgardi");
            }
            else
            {
                Console.WriteLine(" Qator yangilanmadi");
            }
        }

        public async Task DeleteCustomers()
        {
            string sqlQuery = """                                
                Delete from Customers
                where CustomerID='UZBEK';;
                """;

            var rowsUpdate = await _dbContext.connection.ExecuteAsync(sqlQuery);

            if (rowsUpdate > 0)
            {
                Console.WriteLine($" {rowsUpdate} ta qator yangilandi: yangi qo'shilgan qator o'chirildi ");
            }
            else
            {
                Console.WriteLine(" Qator yangilanmadi");
            }
        }
    }
}
