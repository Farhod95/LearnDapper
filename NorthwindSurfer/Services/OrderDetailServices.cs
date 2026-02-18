using Dapper;
using NorthwindSurfer.Models;

namespace NorthwindSurfer.Services
{
    public class OrderDetailServices: OrdersServices
    {
        public async Task CreateOrderDetail()
        {
            string sqlQuery = """
                INSERT INTO [Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount)
                VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount);
                """;
            var anonimObject = new
            {
                OrderID = 10248,
                ProductID = 1,
                UnitPrice = 14.00m,
                Quantity = 12,
                Discount = 0.15f
            };

            var rowsUpdate = await _dbContext.connection.ExecuteAsync(sqlQuery, anonimObject);

            if (rowsUpdate > 0)
            {
                Console.WriteLine($"{rowsUpdate} ta qator qo'shildi !");
            }
            else
            {
                Console.WriteLine(" Bironta ham qator qo'shilmadi !");
            }
        }

        public async Task GetAllOrderDetail()
        {
            string sqlQuery = """ Select * from [Order Details]; """;
            List<OrderDetail> orderDetails = (await _dbContext.connection.QueryAsync<OrderDetail>(sqlQuery)).ToList();
            foreach (var item in orderDetails)
            {
                Console.WriteLine($" {item.OrderID}  {item.ProductID}  {item.UnitPrice}  {item.Quantity}  {item.Discount}");
            }
        }

        public async Task GetByIdOrderDetail()
        {
            Console.Write(" Kerkli bo'lgan Customerning ID sini kiriting (10248=>11077): ");

            if(int.TryParse(Console.ReadLine(), out int id))
            {
                if(id<10248 || id > 11077)
                {
                    Console.WriteLine(" Noto'g'ri amal kiritdingiz !");
                }
                else
                {
                    string sqlQuery = """ Select * From [Order Details]  where OrderID = @orderID """;

                    var orderDetail = await _dbContext.connection.QueryFirstOrDefaultAsync(sqlQuery, new { orderID = id });

                    Console.WriteLine($" {orderDetail.OrderID}  {orderDetail.ProductID}  {orderDetail.UnitPrice}  {orderDetail.Quantity}  {orderDetail.Discount}");
                }                    
            }
            else
            {
                Console.WriteLine(" Noto'g'ri amal kiritdingiz !");
            }            
        }

        public async Task UpdateOrderDetail()
        {
            string sqlQuery = """                                
                Update [Order Details]
                set UnitPrice = 100
                where OrderID=10248 and ProductID=1;
                """;

            var rowsUpdate = await _dbContext.connection.ExecuteAsync(sqlQuery);

            if (rowsUpdate > 0)
            {
                Console.WriteLine($" {rowsUpdate} ta qator yangilandi: UnitPrice 14 dan 100 ga o'zgardi");
            }
            else
            {
                Console.WriteLine(" Qator yangilanmadi");
            }
        }

        public async Task DeleteOrderDetail()
        {
            string sqlQuery = """                                
                delete from [Order Details]
                where OrderID=10248 and ProductID=1;
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
