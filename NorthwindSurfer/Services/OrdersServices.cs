using Dapper;
using NorthwindSurfer.Data;
using NorthwindSurfer.Models;

namespace NorthwindSurfer.Services
{
    public class OrdersServices
    {
        public DbContext _dbContext;
        public OrdersServices()
        {
            this._dbContext = new DbContext();
        }

        public async Task GetAllOrders()
        {
            string sqlQueryOrdersGetAll = """ Select * From Orders; """;
            List<Orders> orders = (await _dbContext.connection.QueryAsync<Orders>(sqlQueryOrdersGetAll)).ToList();
            foreach (var item in orders)
            {
                Console.WriteLine($" OrderID: {item.OrderID} CustomerID:{item.CustomerID} EmployeeID:{item.EmployeeID} OrderDate:{item.OrderDate} RequiredDate:{item.RequiredDate} ShippedDate:{item.ShippedDate} ShipVia:{item.ShipVia} Freight:{item.Freight} ShipName:{item.ShipName} ShipAddress:{item.ShipAddress} ShipCity:{item.ShipCity} ShipRegion:{item.ShipRegion} ShipPostalCode:{item.ShipPostalCode} ShipCountry:{item.ShipCountry}");
            }
        }

        public async Task GetByIdOrders()
        {
            Console.Write(" Kerkli bo'lgan orderning ID sini kiriting (10248 => 11077): ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if(id < 10248 || id > 11077)
                {
                    Console.WriteLine(" Noto'g'ri amal kiritdingiz !");
                }
                else
                {
                    string sqlQuery = """ Select * From Orders where OrderID = @orderID """;
                    var order = await _dbContext.connection.QueryFirstOrDefaultAsync(sqlQuery, new { orderID = id });

                    Console.WriteLine($"\n OrderID: {order.OrderID} \n CustomerID:{order.CustomerID} \n EmployeeID:{order.EmployeeID} \n OrderDate:{order.OrderDate} \n RequiredDate:{order.RequiredDate} \n ShippedDate:{order.ShippedDate} \n ShipVia:{order.ShipVia} \n Freight:{order.Freight} \n ShipName:{order.ShipName} \n ShipAddress:{order.ShipAddress} \n ShipCity:{order.ShipCity} \n ShipRegion:{order.ShipRegion} \n ShipPostalCode:{order.ShipPostalCode} \n ShipCountry:{order.ShipCountry}");
                }                    
            }
            else
            {
                Console.WriteLine(" Noto'g'ri amal kiritdingiz !");
            }
        }
    }
}
