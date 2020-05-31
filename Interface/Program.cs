using System;
using System.Collections.Generic;

namespace Course_work.Models
{
    public class Program
    {
        static List<Pair<Customer,string>> customers = new List<Pair<Customer, string>>();
        static List<Pair<Storage, string>> storages = new List<Pair<Storage, string>>();

        static void Main(string[] args)
        {
            Console.WriteLine("Course work var.5 Kravchenko Roman");

            bool flag = true;
            string Adminpassword = "admin";
            Order.Notify += DisplayMessage;
            while (flag)
            {
                bool Adminflag = true;
                Console.WriteLine("To start using program you need to choose your who are you");
                Console.WriteLine("1.Program administrator");
                Console.WriteLine("2.Customer");
                Console.WriteLine("3.Storage manager");
                Console.WriteLine("To exit write something else");
                var ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter the admin password");
                            string s = Console.ReadLine();
                            if (Adminpassword == s)
                            {

                                while (Adminflag)
                                {
                                    Console.WriteLine("If you want to add new Customer write 1");
                                    Console.WriteLine("If you want to add new Storage manager write 2");
                                    Console.WriteLine("If you want to switch your role write 3");
                                    Console.WriteLine("If you want to exit write something else");
                                    var str = Console.ReadLine();
                                    try
                                    {
                                        switch (str)
                                        {
                                            case "1":
                                                {
                                                    CreateCustomer();
                                                }
                                                break;
                                            case "2":
                                                {
                                                    CreateStorage();
                                                }
                                                break;

                                            case "3":
                                                {
                                                    Adminflag = false;
                                                }
                                                break;
                                            default:
                                                Adminflag = false;
                                                flag = false;
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Please write corectly!!!");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Password");
                            }
                        }
                        break;
                    case "2":
                        {
                            if(customers.Count == 0)
                            {
                                Console.WriteLine("No Customers");
                                break;
                            }
                            Console.WriteLine("Choose your account");
                            for (int i = 0; i < customers.Count; i++)
                            {
                                Console.WriteLine($"{i+1}. {customers[i].First.Name}");
                            }
                            int number_customer = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter this customer password");
                            string s = Console.ReadLine();
                            if (customers[number_customer - 1].Second == s)
                            {
                                while (Adminflag)
                                {
                                    Console.WriteLine("If you want to create a order write 1");
                                    Console.WriteLine("If you want to see all active orders on Storages write 2");
                                    Console.WriteLine("If you want to see order history on Storages write 3");
                                    Console.WriteLine("If you want to switch your role write 4");
                                    Console.WriteLine("If you want to exit write something else");
                                    var str = Console.ReadLine();
                                    try
                                    {
                                        switch (str)
                                        {
                                            case "1":
                                                {
                                                    CreateOrder(number_customer);
                                                }
                                                break;
                                            case "2":
                                                {
                                                    SeeAllActiveOrders();
                                                }
                                                break;

                                            case "3":
                                                {
                                                    SeeOrderHistory();
                                                } break;

                                            case "4":
                                                {
                                                    Adminflag = false;
                                                }
                                                break;
                                            default:
                                                Adminflag = false;
                                                flag = false;
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Please write corectly!!!");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Password");
                            }
                        }
                        break;
                    case "3":
                        {
                            if (storages.Count == 0)
                            {
                                Console.WriteLine("No Storage managers");
                                break;
                            }
                            Console.WriteLine("Choose your account");
                            for (int i = 0; i < storages.Count; i++)
                            {
                                Console.WriteLine($"{i+1}. {storages[i].First.Name}");
                            }
                            int number_storage = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter this storage password");
                            string s = Console.ReadLine();
                            if (storages[number_storage - 1].Second == s)
                            {
                                while (Adminflag)
                                {
                                    Console.WriteLine("If you want to add product write 1 ");
                                    Console.WriteLine("If you want to switch your role write 2");
                                    Console.WriteLine("If you want to exit write something else");
                                    var str = Console.ReadLine();
                                    try
                                    {
                                        switch (str)
                                        {
                                            case "1":
                                                {
                                                    AddProduct(number_storage);
                                                }
                                                break;
                                            case "2":
                                                {
                                                    Adminflag = false;
                                                }
                                                break;
                                            default:
                                                Adminflag = false;
                                                flag = false;
                                                break;
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Please write corectly!!!");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Wrong Password");
                            }
                        }
                        break;
                    case "4":
                        {
                            flag = false;
                        }   break;
                }
            }

        }

        static void AddProduct(int number_storage) // додавання продукту
        {
            try
            {
                Console.WriteLine("Write product title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Write product id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Write product quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                storages[number_storage - 1].First.AddProduct(new Product(id, title), quantity);
            }
            catch (Exception)
            {
                Console.WriteLine("Please write corectly!!!");
            }
        }

        static void CreateOrder(int number_customer) // створення продукту
        {
            try
            {
                Console.WriteLine("Select the storage, just write the number (start with 1)");
                for (int i = 0; i < storages.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {storages[i].First.Name}");
                }
                int number_storage = int.Parse(Console.ReadLine());

                List<OrderProduct> orderproducts = new List<OrderProduct>();
                Console.WriteLine("Write how many products you want to order: ");
                int number = int.Parse(Console.ReadLine());
                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine("Write ID product which you want to order");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Write quantity to order");
                    int quantity = int.Parse(Console.ReadLine());
                    orderproducts.Add(new OrderProduct(new Product(id), quantity));
                }
                Order order = storages[number_storage - 1].First.MakeOrder(customers[number_customer - 1].First, orderproducts);
                storages[number_storage - 1].First.ExecuteOrder(order);
            }
            catch (Exception)
            {
                Console.WriteLine("Please write corectly!!!");
            }
        }

        static void SeeAllProducts() // побачити всі продукти
        {
            try
            {
                Console.WriteLine("Select the storage, just write the number (start with 1)");
                for (int i = 0; i < storages.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {storages[i].First.Name}");
                }
                int number_storage = int.Parse(Console.ReadLine());
                if (storages[number_storage - 1].First.Products.Count == 0)
                {
                    Console.WriteLine("There is no one. :(");
                    return;
                }
                foreach (var item in storages[number_storage - 1].First.Products)
                {
                    Console.WriteLine($"Title: {item.First.Title} Id: {item.First.Id} Quanity: {item.Second}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Please write corectly!!!");
            }
        }

        static void SeeAllActiveOrders() // побачити всі активні замовлення
        {
            Console.WriteLine("Select the storage, just write the number (start with 1)");
            for (int i = 0; i < storages.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {storages[i].First.Name}");
            }
            int number_storage = int.Parse(Console.ReadLine());

            var Orders = storages[number_storage - 1].First.NotCompletedOrders.Orders;
            foreach (var item in Orders)
            {
                Console.WriteLine();
                Console.WriteLine($"Order id: {item.Ordernumber}, Customer {item.Customer.Name}, Storage {item.Storage.Name}");
                Console.WriteLine("List of Products to order:");
                foreach (var orderproduct in item.OrderProducts)
                {
                    Console.WriteLine($"Product Id: {orderproduct.Product.Id} Quantity to order: {orderproduct.QuantityToOrder}");
                }
                Console.WriteLine();
            }
        }
        
        static void SeeOrderHistory() // побачити історію заволення
        {
            Console.WriteLine("Select the storage, just write the number (start with 1)");
            for (int i = 0; i < storages.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {storages[i].First.Name}");
            }
            int number_storage = int.Parse(Console.ReadLine());

            var OrdersHistory = storages[number_storage - 1].First.HistoryOrder;
            foreach (var item in OrdersHistory)
            {
                Console.WriteLine();
                Console.WriteLine($"Order id: {item.Ordernumber}, Customer {item.Customer.Name}, Storage {item.Storage.Name}");
                Console.WriteLine("List of Products in order:");
                foreach (var orderproduct in item.OrderProducts)
                {
                    Console.WriteLine($"Product Id: {orderproduct.Product.Id}  Quantity in order: {orderproduct.QuantityToOrder}");
                }
                Console.WriteLine($"Completed at {item.Leadtime}");
                Console.WriteLine();
            }
        }

        static void CreateCustomer() // створення нового замовника
        {
            Console.WriteLine("To create a customer write his name: ");
            string name = Console.ReadLine();
            Console.WriteLine("And password: ");
            string password = Console.ReadLine();
            foreach(var item in customers)
            {
                if(item.First.Name == name)
                {
                    Console.WriteLine($"Customer with name {name} already exists");
                    return;
                }
            }
            customers.Add(new Pair<Customer, string>(new Customer(name),password));
        }
        static void CreateStorage() // створення нового складу
        {
            Console.WriteLine("To create a storage manager write his name: ");
            string name = Console.ReadLine();
            Console.WriteLine("And password: ");
            string password = Console.ReadLine();
            foreach (var item in storages)
            {
                if (item.First.Name == name)
                {
                    Console.WriteLine($"Storage with name {name} already exists");
                    return;
                }
            }
            storages.Add(new Pair<Storage, string>(new Storage(name),password));
        }
        private static void DisplayMessage(string message) // метод на який ми підписуємось для обробки події
        {
            Console.WriteLine(message);
        }
    }
    
}