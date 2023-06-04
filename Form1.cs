using Cursova_2;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Practic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string query = "";
        public int count = 0;
        DB db = new DB();
        List<string[]> data = new List<string[]>();


        public void Visibles()
        {
            checkBox5.Visible = true;
            checkBox6.Visible = false;
            checkBox7.Visible = false;
        }//+
        public string Query(int key)
        {
            string TableName = "";
            string coll = query;
            query = "SELECT ";
            switch(key)
            {
                case 0:
                    TableName = "Buyer";
                    break;
                case 1:
                    TableName = "Product";
                    break;
                case 2:
                    TableName = "Supplier";
                    break;
                case 3:
                    TableName = "Warehouse";
                    break;
                case 4:
                    TableName = "Warehouse_History";
                    break;
            }

            query += coll + " FROM " + TableName;
            
            return query;
        }//+
        private void ColunmNames()
        {
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Product Code";
            dataGridView1.Columns[3].HeaderText = "Product Count";
            dataGridView1.Columns[4].HeaderText = "Price";
            dataGridView1.Columns[5].HeaderText = "Supplier ID";
            dataGridView1.Columns[6].HeaderText = "Certificate";
        }//+

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            BtnGenerate.Enabled = false;
            RandomData randomData = new RandomData();
            randomData.SendData();
        }//+

        private void BtnShowTables_Click(object sender, EventArgs e)
        {
            data.Clear();
            dataGridView1.Rows.Clear();
            query = "SHOW TABLES";
            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            db.openConnection();
            MySqlDataReader reader = command.ExecuteReader();

            try
            {
                dataGridView1.ColumnCount = 1;
                dataGridView1.Columns[0].HeaderText = "Tables Name";
                while (reader.Read())
                {
                    data.Add(new string[dataGridView1.ColumnCount]);

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                        data[data.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
            }
            finally { db.closeConnection(); }

            foreach (string[] rows in data)
            {
                dataGridView1.Rows.Add(rows);
            }

        }//+

        private void BtnShowReq2_Click(object sender, EventArgs e)
        {
            gBoxReq2.Visible = true;
            data.Clear();
        }//+

        private void BtnShowReq3_Click(object sender, EventArgs e)
        {
            data.Clear();
            gBoxReq3.Visible = true;
            query = "SELECT Product_Name FROM Product";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            try
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                        cBoxSearch.Items.Add(reader[i].ToString());
                    }
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { db.closeConnection(); }

        }//+

        private void BtnShowReq4_Click(object sender, EventArgs e)
        {
            gBoxReq4.Visible = true;
            data.Clear();
        }//+

        private void BtnShowReq5_Click(object sender, EventArgs e)
        {
            data.Clear();
            gBoxReq5.Visible = true;
            cBoxBuyer.Items.Clear();
            query = "SELECT Last_Name FROM Supplier";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            try
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                        cBoxBuyer.Items.Add(reader[i].ToString());
                    }
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { db.closeConnection(); }
        }//+

        private void BtnShowReq6_Click(object sender, EventArgs e)
        {
            gBoxReq6.Visible = true;
            data.Clear();
            query = "SELECT ID FROM buyer";

            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            try
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                        cBoxBuyerSearch.Items.Add(reader[i].ToString());
                    }
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { db.closeConnection(); }
        }//+
        private void BtnShowReq8_Click(object sender, EventArgs e)
        {
            gBoxReq8.Visible = true;
            data.Clear();
        }//+

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Visibles();
                    checkBox2.Text = "Last_Name";
                    checkBox3.Text = "First_Name";
                    checkBox4.Text = "Address";
                    checkBox5.Text = "Phone";
                    break;
                case 1:
                    checkBox6.Visible = true;
                    checkBox7.Visible = true;
                    checkBox2.Text = "Product_Name";
                    checkBox3.Text = "Product_Code";
                    checkBox4.Text = "Product_Count";
                    checkBox5.Text = "Price";
                    checkBox6.Text = "Supplier_ID";
                    checkBox7.Text = "Certificate";
                    break;
                case 2:
                    Visibles();
                    checkBox2.Text = "Last_Name";
                    checkBox3.Text = "First_Name";
                    checkBox4.Text = "Address";
                    checkBox5.Text = "Phone";
                    break;
                case 3:
                    Visibles();
                    checkBox5.Visible = false;
                    checkBox2.Text = "Date";
                    checkBox3.Text = "Product_Count";
                    checkBox4.Text = "Product_Code";
                    break;
                case 4:
                    Visibles();
                    checkBox2.Text = "Product_Code";
                    checkBox3.Text = "Date";
                    checkBox4.Text = "Product_Count";
                    checkBox5.Text = "Buyer_ID";
                    break;
                default:                   
                    break;
            }
        }//+

        private void BtnRequest_Click(object sender, EventArgs e)
        {
            data.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            gBoxReq2.Visible = false;
            query = "";

            DB db = new DB();
            count = 0;
            if (checkBox1.Checked) { query += checkBox1.Text + ','; count++; dataGridView1.Columns.Add(" ", checkBox1.Text); }
            if (checkBox2.Checked) { query += checkBox2.Text + ','; count++; dataGridView1.Columns.Add(" ", checkBox2.Text); }
            if (checkBox3.Checked) { query += checkBox3.Text + ','; count++; dataGridView1.Columns.Add(" ", checkBox3.Text); }
            if (checkBox4.Checked) { query += checkBox4.Text + ','; count++; dataGridView1.Columns.Add(" ", checkBox4.Text); }
            if (checkBox5.Checked) { query += checkBox5.Text + ','; count++; dataGridView1.Columns.Add(" ", checkBox5.Text); }
            if (checkBox6.Checked) { query += checkBox6.Text + ','; count++; dataGridView1.Columns.Add(" ", checkBox6.Text); }
            if (checkBox7.Checked) { query += checkBox7.Text + ','; count++; dataGridView1.Columns.Add(" ", checkBox7.Text); }

            if (query.EndsWith(",")) query = query.Substring(0, query.Length - 1);

            query = Query(comboBox1.SelectedIndex);
            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            try
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                dataGridView1.ColumnCount = count;
                while (reader.Read())
                {
                    data.Add(new string[dataGridView1.ColumnCount]);

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                        data[data.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex); }
            finally { db.closeConnection(); }

            foreach (string[] rows in data)
            {
                dataGridView1.Rows.Add(rows);
            }
        }//2

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            data.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            string Product = cBoxSearch.Text;

            query = "SELECT * FROM Product WHERE Product_Name = '" + Product + "'";
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            ColunmNames();

            try
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    data.Add(new string[dataGridView1.ColumnCount]);

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                        data[data.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { db.closeConnection(); }

            foreach (string[] rows in data)
            {
                dataGridView1.Rows.Add(rows);
            }

            gBoxReq3.Visible = false;
        }//3

        private void btnPriceReq_Click(object sender, EventArgs e)
        {
            data.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            gBoxReq4.Visible = false;

            int number = Int32.Parse(maskedTextBox1.Text);
            query = "SELECT * FROM Product WHERE Price ";

            query += (rButtonHight.Checked) ? "> " + number : "< " + number;
            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            ColunmNames();

            try
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new string[dataGridView1.ColumnCount]);

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                        data[data.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { db.closeConnection(); }

            foreach (string[] rows in data)
            {
                dataGridView1.Rows.Add(rows);
            }

            gBoxReq4.Visible = false;
        }//4

        private void BtnBuyer_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Btn 6");
            data.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            string Surname = cBoxBuyer.Text;

            query = "SELECT p.Product_Name, p.Price, p.Product_Count " +
                    "FROM Product p JOIN Supplier s ON p.Supplier_ID = s.ID" +
                    " WHERE s.Last_Name = '" + Surname + "'";

            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Price";
            dataGridView1.Columns[2].HeaderText = "Product Count";

            try
            {
                db.openConnection();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new string[dataGridView1.ColumnCount]);

                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        Console.WriteLine(reader[i].ToString());
                        data[data.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { db.closeConnection(); }

            foreach (string[] rows in data)
            {
                dataGridView1.Rows.Add(rows);
            }

            gBoxReq5.Visible = false;
        }//5

        private void BtnBuyerSearch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Btn 6");
            data.Clear();
            cBoxBuyerSearch.Items.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            string ID = cBoxBuyerSearch.Text;
            Console.WriteLine(ID);

            query = "SELECT  p.Product_Name, p.Price, w.Product_Count " +
                    "FROM product p " +
                    "JOIN warehouse_history w ON p.Product_Code = w.Product_Code " +
                    "JOIN buyer b ON w.Buyer_ID = b.ID " +
                    "WHERE b.ID = " + ID;

            Console.WriteLine(query);
            MySqlCommand command = new MySqlCommand(query, db.getConnection());

            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].HeaderText = "Product Name";
            dataGridView1.Columns[1].HeaderText = "Price";
            dataGridView1.Columns[2].HeaderText = "Product Count";

            try
{
    db.openConnection();
    MySqlDataReader reader = command.ExecuteReader();

    if (reader.HasRows) // Проверка наличия данных
    {
        while (reader.Read())
        {
            data.Add(new string[dataGridView1.ColumnCount]);

            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                Console.WriteLine(reader[i].ToString());
                data[data.Count - 1][i] = reader[i].ToString();
            }
           
            dataGridView1.Rows.Add(data[data.Count - 1]);
        }
    }

    reader.Close();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
finally
{
    db.closeConnection();
}


            gBoxReq6.Visible = false;
        }//6
        private void btnCertificateTest_Click(object sender, EventArgs e)
        {
            gBoxReq8.Visible = false;

            string productName = tBoxNameProduct.Text;

            string query = $"SELECT Certificate FROM Product WHERE Product_Name = '{productName}'";

            string certificate = "";

            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderText = "Certificate";

            db.openConnection();

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, db.getConnection()))
                {
                    var result = command.ExecuteScalar();
                    certificate = result != null ? result.ToString() : "None";

                    dataGridView1.Rows.Add(productName, certificate);
                }
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }
            finally { db.closeConnection(); }

            Console.WriteLine(certificate);
        }//7

        private void BtnClear_Click(object sender, EventArgs e)
        {
            gBoxReq2.Visible = false;
            gBoxReq3.Visible = false;
            gBoxReq4.Visible = false;
            gBoxReq5.Visible = false;
            gBoxReq6.Visible = false;
            gBoxReq8.Visible = false;

            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }

       
    }
}
