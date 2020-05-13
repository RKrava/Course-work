using System;
using System.Collections.Generic;

namespace Course_work.Models
{
    public class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Storage> storages = new List<Storage>();

        static void Main(string[] args)
        {
            Console.WriteLine("Course work var.5 Kravchenko Roman");
            
            Console.WriteLine("To start using program you need to create a customer and storage");
            
            CreateCustomer();
            CreateStorage(); 
            
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("If you want to add product write 1 ");
                Console.WriteLine("If you want to create a order write 2");
                Console.WriteLine("If you want to add new Customer write 3");
                Console.WriteLine("If you want to add new Storage write 4");
                Console.WriteLine("If you want to see all products write 5");
                Console.WriteLine("If you want to see all active orders write 6");
                Console.WriteLine("If you want to see order history write 7");
                Console.WriteLine("If you want to exit write something else");
                var str = Console.ReadLine();
                switch(str){
                    case "1":
                        {
                            try
                            {
                                Console.WriteLine("Select the storage, just write the number");
                                for(int i = 0; i < storages.Count; i++)
                                { 
                                    Console.WriteLine($"{i+1}. {storages[i].Name}");
                                }
                                int number_storage = int.Parse(Console.ReadLine());

                                Console.WriteLine("Write product title: ");
                                string title = Console.ReadLine();
                                Console.WriteLine("Write product id: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Write product quantity: ");
                                int quantity = int.Parse(Console.ReadLine());
                                storages[number_storage - 1].AddProduct(new Product(id, title), quantity);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Please write corectly!!!");
                            }
                            break;
                        }
                    case "2":
                        {
                            try
                            {
                                Console.WriteLine("Select the storage, just write the number (start with 1)");
                                for (int i = 0; i < storages.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {storages[i].Name}");
                                }
                                int number_storage = int.Parse(Console.ReadLine());
                                Console.WriteLine("Select the customer, just write the number (start with 1)");
                                for (int i = 0; i < customers.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {customers[i].Name}");
                                }
                                int number_customer = int.Parse(Console.ReadLine());

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
                                Order order = storages[number_storage - 1].MakeOrder(customers[number_customer - 1], orderproducts);
                                storages[number_storage - 1].ExecuteOrder(order);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Please write corectly!!!");
                            }
                            break;
                        }
                    case "3":
                        {
                            CreateCustomer();
                            break;
                        }
                    case "4":
                        {
                            CreateStorage();
                            break;
                        }
                    case "5":
                        {
                            try
                            {
                                Console.WriteLine("Select the storage, just write the number (start with 1)");
                                for (int i = 0; i < storages.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {storages[i].Name}");
                                }
                                int number_storage = int.Parse(Console.ReadLine());
                                if (storages[number_storage - 1].Products.Count == 0)
                                {
                                    Console.WriteLine("There is no one. :(");
                                    break;
                                }
                                foreach (var item in storages[number_storage - 1].Products)
                                {
                                    Console.WriteLine($"Title: {item.First.Title} Id: {item.First.Id} Quanity: {item.Second}");
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Please write corectly!!!");
                            }
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Select the storage, just write the number (start with 1)");
                            for (int i = 0; i < storages.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {storages[i].Name}");
                            }
                            int number_storage = int.Parse(Console.ReadLine());

                            var Orders = storages[number_storage - 1].NotCompletedOrders.Orders;
                            foreach (var item in Orders)
                            {
                                Console.WriteLine();
                                Console.WriteLine($"Order id: {item.Ordernumber}, Customer {item.Customer.Name}, Storage {item.Storage.Name}");
                                Console.WriteLine("List of Products to order:");
                                foreach(var orderproduct in item.OrderProducts)
                                {
                                    Console.WriteLine($"Product Id: {orderproduct.Product.Id} Quantity to order: {orderproduct.QuantityToOrder}");
                                }
                                Console.WriteLine();
                            }
                            break;
                        }
                    case "7":
                        {
                            Console.WriteLine("Select the storage, just write the number (start with 1)");
                            for (int i = 0; i < storages.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {storages[i].Name}");
                            }
                            int number_storage = int.Parse(Console.ReadLine());

                            var OrdersHistory = storages[number_storage - 1].HistoryOrder;
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
                            break;
                        }
                    default:
                        flag = false;
                        break;
                }
            }
        }
        static void CreateCustomer()
        {
            Console.WriteLine("To create a customer write his name: ");
            string name = Console.ReadLine();
            foreach(var item in customers)
            {
                if(item.Name == name)
                {
                    Console.WriteLine($"Customer with name {name} already exists");
                    return;
                }
            }
            customers.Add(new Customer(name));
        }
        static void CreateStorage()
        {
            Console.WriteLine("To create a storage write his name: ");
            string name = Console.ReadLine();
            foreach (var item in storages)
            {
                if (item.Name == name)
                {
                    Console.WriteLine($"Storage with name {name} already exists");
                    return;
                }
            }
            storages.Add(new Storage(name));
        }
    }
    
}