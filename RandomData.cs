using Cursova_2;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practic
{
    public class RandomData
    {

        private static Random random = new Random();
        DB db = new DB();

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private List<string> names = new List<string>()
        {
            "Olivia",
            "Emma",
            "Charlotte",
            "Amelia",
            "John",
            "William",
            "Ava",
            "Sophia",
            "Riley",
            "Donald",
            "Andrew",
            "Willow",
            "Emilia",
            "Zoe",
            "Lillian",
            "Natalie",
            "Charles",
            "Daniel",
            "Delilah",
            "Sophie",
            "Caroline",
            "Alice",
            "Piper",
            "Clara",
            "Julia",
            "James",
            "Joseph",
            "Thomas",
            "Anthony",
            "Paul"
        };


        private List<string> surname = new List<string>()
        {
            "Smith",
            "Brown",
            "Davis",
            "Lopez",
            "Lee",
            "White",
            "Allen",
            "Green",
            "Hall",
            "Gomez",
            "Parker",
            "Reyes",
            "Cook",
            "Morgan",
            "Kim",
            "Brooks",
            "Watson",
            "Wood",
            "Price",
            "Foster",
            "Castillo",
            "Alvarez",
            "Ross"
        };


        private List<string> addresses = new List<string>()
        {
            "San Francisco, Harrison Street ",
            "Sabin, Eagle Lane ",
            "Chicago, Tator Patch Road ",
            "Grand Rapids, Red Dog Road",
            "Lafayette, Rubaiyat Road ",
            "Charlotte, Sherwood Circle ",
            "Warwick, Bond Street ",
            "Los Angeles, Glendale Avenue ",
            "Cresson, Custer Street ",
            "Reading, Stone Lane ",
            "Appleton, Sycamore Lake Road ",
            "Seattle, Conifer Drive",
            "Wasserburg, Potsdamer Platz ",
            "Gutweiler, Flotowstr ",
            "Bielefeld Kirchdornberg, Spresstrasse",
            "Betheln, Rohrdamm",
            "Teresópolis, Avenida Rotariana",
            "Embu, Rua Catanduvas ",
            "Walnut Creek, Meadow Lane ",
            "Chicago, Farland Street ",
            "Worthington, Dogwood Lane ",
            "Boston, C Street ",
            "Walnut Creek, Water Street ",
            "Southaven, Rafe Lane "
        };

        public static string GenerateRandomNumber(int length)
        {
            const string chars = "1234567890";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static DateTime GenerateRandomDate(DateTime startDate, DateTime endDate)
        {
            int range = (endDate - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }

        public static List<Product> GenerateProductData(int numRecords)
        {
            var products = new List<Product>();

            for (int i = 1; i <= numRecords; i++)
            {
                var product = new Product
                {
                    ID = i,
                    Product_Name = GenerateRandomString(10),
                    Product_Code = GenerateRandomString(10),
                    Product_Count = random.Next(1, 900000),
                    Price = random.Next(1, 1000),
                    Supplier_ID = random.Next(1, 5),
                    Certificate = random.Next(2) == 0 ? "Yes" : "No"                   
                };
                products.Add(product);
            }

            return products;
        }

        public static List<Warehouse> GenerateWarehouseData(int numRecords, List<Product> products)
        {
            var warehouses = new List<Warehouse>();

            for (int i = 1; i <= numRecords; i++)
            {
                var warehouse = new Warehouse
                {
                    ID = i,
                    Date = GenerateRandomDate(DateTime.Now.AddYears(-1), DateTime.Now),
                    Product_Count = random.Next(1, 100),
                    Product_Code = products[random.Next(products.Count)].Product_Code
                };
                warehouses.Add(warehouse);
            }

            return warehouses;
        }

        public List<Buyer> GenerateBuyerData(int numRecords)
        {
            var buyers = new List<Buyer>();

            for (int i = 1; i <= numRecords; i++)
            {
                var buyer = new Buyer
                {
                    ID = i,
                    Last_Name = surname[random.Next(surname.Count)],
                    First_Name = names[random.Next(names.Count)],
                    Address = addresses[random.Next(addresses.Count)] + GenerateRandomNumber(2),
                    Phone = GenerateRandomNumber(10)
                };
                Console.WriteLine(buyer);
                buyers.Add(buyer);
            }

            return buyers;
        }

        public static List<Warehouse_History> GenerateWarehouseHistoryData(int numRecords, List<Product> products, List<Buyer> buyers)
        {
            var warehouseHistory = new List<Warehouse_History>();

            for (int i = 1; i <= numRecords; i++)
            {
                var history = new Warehouse_History
                {
                    ID = i,
                    Product_Code = products[random.Next(products.Count)].Product_Code,
                    Date = GenerateRandomDate(DateTime.Now.AddYears(-1), DateTime.Now),
                    Product_Count = random.Next(1, 100),
                    Buyer_ID = buyers[random.Next(buyers.Count)].ID
                };
                warehouseHistory.Add(history);
            }

            return warehouseHistory;
        }

        public List<Supplier> GenerateSupplierData(int numRecords)
        {
            var suppliers = new List<Supplier>();

            for (int i = 1; i <= numRecords; i++)
            {
                var supplier = new Supplier
                {
                    ID = i,
                    Supplier_Name = names[random.Next(names.Count)],
                    Supplier_Surname = surname[random.Next(surname.Count)],
                    Supplier_Address = addresses[random.Next(addresses.Count)] + GenerateRandomNumber(2),
                    Supplier_Phone = GenerateRandomNumber(10)
                };
                suppliers.Add(supplier);
            }

            return suppliers;
        }

        public void SendData()
        {

            List<Product> products = GenerateProductData(10);
            List<Warehouse> warehouses = GenerateWarehouseData(20, products);
            List<Supplier> suppliers = GenerateSupplierData(10);
            List<Buyer> buyers = GenerateBuyerData(5);
            List<Warehouse_History> warehouseHistory = GenerateWarehouseHistoryData(50, products, buyers);

            db.openConnection();

            // Отправка данных таблицы Suppliers

            try
            {
                foreach (var supplier in suppliers)
                {
                    string query = $"INSERT INTO Supplier VALUES ({supplier.ID}, '{supplier.Supplier_Surname}', '{supplier.Supplier_Name}', '{supplier.Supplier_Address}', '{supplier.Supplier_Phone}')";
                    Console.WriteLine(query);
                    Request(query);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { Console.WriteLine("#Supplier"); }

            // Отправка данных таблицы Buyer
            try
            {
                foreach (var buyer in buyers)
                {
                    string query = $"INSERT INTO Buyer VALUES ({buyer.ID}, '{buyer.Last_Name}', '{buyer.First_Name}', '{buyer.Address}', '{buyer.Phone}')";
                    Console.WriteLine(query);
                    Request(query);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { Console.WriteLine("#Buyer"); }

            // Отправка данных таблицы Product
            try
            {
                foreach (var product in products)
                {
                    string query = $"INSERT INTO Product VALUES ({product.ID}, '{product.Product_Name}', '{product.Product_Code}', {product.Product_Count}, {product.Price}, {product.Supplier_ID}, '{product.Certificate}')";
                    Console.WriteLine(query);
                    Request(query);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { Console.WriteLine("#Product"); }

            // Отправка данных таблицы Warehouse
            try
            {
                foreach (var warehouse in warehouses)
                {
                    string query = $"INSERT INTO Warehouse VALUES ({warehouse.ID}, '{warehouse.Date.ToString("yyyy-MM-dd")}', {warehouse.Product_Count}, '{warehouse.Product_Code}')";
                    Console.WriteLine(query);
                    Request(query);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { Console.WriteLine("#Warehouse"); }


            // Отправка данных таблицы Warehouse_History
            try
            {
                foreach (var history in warehouseHistory)
                {
                    string query = $"INSERT INTO Warehouse_History VALUES ({history.ID}, '{history.Product_Code}', '{history.Date.ToString("yyyy-MM-dd")}', {history.Product_Count}, {history.Buyer_ID})";
                    Console.WriteLine(query);
                    Request(query);
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { Console.WriteLine("#5"); }
            db.closeConnection();              
        }

        public void Request(string query)
        {
            using (MySqlCommand command = new MySqlCommand(query, db.getConnection()))
            {
                command.ExecuteNonQuery();
            }            
        }

    }
}
