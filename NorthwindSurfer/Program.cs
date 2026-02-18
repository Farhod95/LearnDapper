using NorthwindSurfer.Services;

namespace NorthwindSurfer
{
    internal class Program
    {
        public CustomersServices customers;
        public OrderDetailServices orderDetail;
        public OrdersServices orders;
        public ProductsServices products;

        public Program()
        {
            this.customers = new CustomersServices();
            this.orderDetail = new OrderDetailServices();
            this.orders = new OrdersServices();
            this.products = new ProductsServices();
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine(" Northwind bazasiga tegishli Customers, Order Details, Orders, Products jadvallari ustida CRUD amallar ");
            var program = new Program();
            await program.Run();
        }
        public async Task Run()
        {
            bool sorov = false;
            while (!sorov)
            {
                sorov = false;
                Console.WriteLine("\n **** Crud - CREATE ****\n");
                Console.WriteLine(" 1. Customers jadvaliga yangi qator qo'shish");
                Console.WriteLine(" 2. Order Details jadvaliga yangi qator qo'shish");
                Console.WriteLine(" 3. Orders jadvaliga yangi qator qo'shish");
                Console.WriteLine(" 4. Products jadvaliga yangi qator qo'shish");


                Console.WriteLine("\n **** cRud - READ ****\n");

                Console.WriteLine(" Jadvallarni to'liq ko'rish");
                Console.WriteLine(" 5. Customers jadvalini to'liq ko'rish ");
                Console.WriteLine(" 6. Order Details jadvaliga to'liq ko'rish");
                Console.WriteLine(" 7. Orders jadvalini to'liq ko'rish ");
                Console.WriteLine(" 8. Products jadvalini to'liq ko'rish ");

                Console.WriteLine("\n ID bo'yicha qidirish");
                Console.WriteLine(" 9. Customers jadvalini ID boyicha qidirish ");
                Console.WriteLine(" 10. Order Details jadvalini ID boyicha qidirish");
                Console.WriteLine(" 11. Orders jadvalini ID boyicha qidirish ");
                Console.WriteLine(" 12. Products jadvalini ID boyicha qidirish ");

                Console.WriteLine("\n Name boyicha qidirsh");
                Console.WriteLine(" 13. Customers jadvalini Name boyicha qidirish ");
                Console.WriteLine(" 14. Products jadvalini Name boyicha qidirish ");

                Console.WriteLine("\n **** crUd - UPDATE ****\n");
                Console.WriteLine(" 15. Customers jadvalidagi yangi qo'shilgan qatorni yangilash");
                Console.WriteLine(" 16. Order Details jadvalidagi yangi qo'shilgan qatorni yangilash");
                Console.WriteLine(" 17. Orders jadvalidagi yangi qo'shilgan qatorni yangilash");
                Console.WriteLine(" 18. Products jadvalidagi yangi qo'shilgan qatorni yangilash");

                Console.WriteLine("\n **** cruD - DELETE ****\n");
                Console.WriteLine(" 19. Customers jadvalidagi yangi qo'shilgan qatorni o'chirish");
                Console.WriteLine(" 20. Order Details jadvalidagi yangi qo'shilgan qatorni o'chirish");
                Console.WriteLine(" 21. Orders jadvalidagi yangi qo'shilgan qatorni o'chirish");
                Console.WriteLine(" 22. Products jadvalidagi yangi qo'shilgan qatorni o'chirish");

                Console.WriteLine();
                Console.Write(" Kerakli bo'limni klaviaturdan kiriting: ");

                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    switch (result)
                    {
                        case 1:
                            {
                                Console.WriteLine();
                                await customers.CreateCustomers();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine();
                                await orderDetail.CreateOrderDetail();
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine();
                                await orders.CreateOrder();
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine();
                                await products.CreateProducts();
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine();
                                await customers.GetAllCustomers();
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine();
                                await orderDetail.GetAllOrderDetail();
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine();
                                await orders.GetAllOrders();
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine();
                                await products.GetAllProducts();
                                break;
                            }
                        case 9:
                            {
                                Console.WriteLine();
                                await customers.GetByIdCustomers();
                                break;
                            }
                        case 10:
                            {
                                Console.WriteLine();
                                await orderDetail.GetByIdOrderDetail();
                                break;
                            }
                        case 11:
                            {
                                Console.WriteLine();
                                await orders.GetByIdOrders();
                                break;
                            }
                        case 12:
                            {
                                Console.WriteLine();
                                await products.GetByIdProducts();
                                break;
                            }
                        case 13:
                            {
                                Console.WriteLine();
                                await customers.SearchByNameCustomers();
                                break;
                            }
                        case 14:
                            {
                                Console.WriteLine();
                                await products.SearchByNameProducts();
                                break;
                            }
                        case 15:
                            {
                                Console.WriteLine();
                                await customers.UpdateCustomers();
                                break;
                            }
                        case 16:
                            {
                                Console.WriteLine();
                                await orderDetail.UpdateOrderDetail();
                                break;
                            }
                        case 17:
                            {
                                Console.WriteLine();
                                await orders.UpdateOrder();
                                break;
                            }
                        case 18:
                            {
                                Console.WriteLine();
                                await products.UpdateProduct();
                                break;
                            }
                        case 19:
                            {
                                Console.WriteLine();
                                await customers.DeleteCustomers();
                                break;
                            }
                        case 20:
                            {
                                Console.WriteLine();
                                await orderDetail.DeleteOrderDetail();
                                break;
                            }
                        case 21:
                            {
                                Console.WriteLine();
                                await orders.DeleteOrder();
                                break;
                            }
                        case 22:
                            {
                                Console.WriteLine();
                                await products.DeleteProduct();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine(" Noto'g'ri amal kiritdingiz !");
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine(" Noto'g'ri amal kiritdingiz !");
                }
            }
        }
    }
}