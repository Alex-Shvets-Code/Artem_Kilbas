using System;

namespace Practic
{
    public class Product
    {
        public int ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Code { get; set; }
        public int Product_Count { get; set; }
        public double Price { get; set; }
        public int Supplier_ID { get; set; }
        public string Certificate { get; set; }
    }

    public class Warehouse
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int Product_Count { get; set; }
        public string Product_Code { get; set; }
    }

    public class Buyer
    {
        public int ID { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }

    public class Warehouse_History
    {
        public int ID { get; set; }
        public string Product_Code { get; set; }
        public DateTime Date { get; set; }
        public int Product_Count { get; set; }
        public int Buyer_ID { get; set; }
    }

    public class Supplier
    {
        public int ID { get; set; }
        public string Supplier_Name { get; set; }

        public string Supplier_Surname { get; set; }
        public string Supplier_Address { get; set; }
        public string Supplier_Phone { get; set; }
    }
}
