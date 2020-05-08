using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks.Dataflow;

namespace Course_work.Models
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Course work var.5 Kravchenko Roman");

            //TODO: Можно добавить какой-то шаблон, заготовленные данные, которые ты сразу считываешь с файла
            //TODO: чтобы не вводить каждый раз
            List<Customer> customers = new List<Customer>();
            List <Storage> storages = new List<Storage>();

            Console.WriteLine("To start using program you need to create a customer and storage");

            Console.WriteLine("To create a customer write his name: ");
            customers.Add(new Customer(Console.ReadLine()));
            Console.WriteLine("To create a storage write his name: ");
            storages.Add(new Storage(Console.ReadLine()));

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("If you want to add product write 1 ");
                Console.WriteLine("If you want to create a order write 2");
                Console.WriteLine("If you want to add new Customer write 3");
                Console.WriteLine("If you want to add new Storage write 4");
                Console.WriteLine("If you want to see all products write 5");
                var str = Console.ReadLine();
                //TODO: выноси кейсы в методы, очень трудно читать
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
                                //TODO: нейминг
                                int number_storage = int.Parse(Console.ReadLine());

                                Console.WriteLine("Write product title: ");
                                string title = Console.ReadLine();
                                Console.WriteLine("Write product id: ");
                                int id = int.Parse(Console.ReadLine());
                                Console.WriteLine("Write product quantity: ");
                                int quantity = int.Parse(Console.ReadLine());
                                storages[number_storage - 1].AddProduct(new Product(id, quantity, title));
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
                                //TODO: можно вынести в метод ShowStorages или StoragesSelect
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
                            Console.WriteLine("To create a customer write his name: ");
                            customers.Add(new Customer(Console.ReadLine()));
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("To create a storage write his name: ");
                            storages.Add(new Storage(Console.ReadLine()));
                            break;
                        }
                    case "5":
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
                            foreach(var item in storages[number_storage - 1].Products)
                            {
                                Console.WriteLine($"Title: {item.Title} Id: {item.Id} Quanity: {item.Quantity}");
                            }
                            break;
                        }
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
    
}