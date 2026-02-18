using NorthwindSurfer.Services;

namespace NorthwindSurfer
{
    internal class Program
    {
        public OrdersServices orders;
        public ProductsServices products;
        public CustomersServices customers;
        public Program()
        {
            this.orders = new OrdersServices();
            this.products = new ProductsServices();
            this.customers = new CustomersServices();
        }
        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.Run();
        }
        public async Task Run()
        {
            Console.WriteLine(" Quyidagi menyudan birini tanlang ");
            Console.WriteLine("\n **** Jadvallarni to'liq ko'rish ****\n");
            Console.WriteLine(" 1. Products jadvalini to'liq ko'rish ");
            Console.WriteLine(" 2. Orders jadvalini to'liq ko'rish ");
            Console.WriteLine(" 3. Customers jadvalini to'liq ko'rish ");
            Console.WriteLine("\n **** ID boyicha qidirsh ****\n");
            Console.WriteLine(" 4. Products jadvalini ID boyicha qidirish ");
            Console.WriteLine(" 5. Orders jadvalini ID boyicha qidirish ");
            Console.WriteLine(" 6. Customers jadvalini ID boyicha qidirish ");
            Console.WriteLine("\n **** Name boyicha qidirsh ****\n");
            Console.WriteLine(" 7. Products jadvalini Name boyicha qidirish ");
            Console.WriteLine(" 8. Customers jadvalini Name boyicha qidirish ");
            Console.WriteLine();
            Console.Write(" Kerakli bo'limni klaviaturdan kiriting: ");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        {
                            Console.WriteLine();
                            await products.GetAllProducts();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine();
                            await orders.GetAllOrders();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine();
                            await customers.GetAllCustomers();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine();
                            await products.GetByIdProducts();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine();
                            await orders.GetByIdOrders();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine();
                            await customers.GetByIdCustomers();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine();
                            await products.SearchByNameProducts();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine();
                            await customers.SearchByNameCustomers();
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