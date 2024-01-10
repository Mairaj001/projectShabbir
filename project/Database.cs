using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace project
{
    internal class Database
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }   


        string connectionString= "Server=localhost;Port=5432;Database=InventoryManagement;User Id=postgres;Password=House167";


        public DataTable SelectProdcuts()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            DataTable dataTable = new DataTable();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "select *from products";
                NpgsqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {

                    dataTable.Load(reader);
                    return dataTable;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            finally
            {
                comm.Dispose();
                conn.Close();

            }
            return null;
        }

        public bool InsertProduct(string productName, decimal price)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO products (ProductName, Price) VALUES (@ProductName, @Price)";

                comm.Parameters.AddWithValue("@ProductName", productName);
                comm.Parameters.AddWithValue("@Price", price);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false; 
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }

        public bool UpdateProduct(int productId, string newProductName, decimal newPrice)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "UPDATE products SET ProductName = @NewProductName, Price = @NewPrice WHERE ProductID = @ProductID";

                comm.Parameters.AddWithValue("@NewProductName", newProductName);
                comm.Parameters.AddWithValue("@NewPrice", newPrice);
                comm.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false; 
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }


        public bool DeleteProduct(int productId)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "DELETE FROM products WHERE ProductID = @ProductID";

                comm.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false; 
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }



        // CUSTOMERS TABLE CURD OPERATIONS



        public DataTable SelectCustomers()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            DataTable dataTable = new DataTable();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * FROM customers";
                NpgsqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
            return null;
        }

        public bool InsertCustomer(string customerName, int age, string address)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO customers (CustomerName, Age, Address) VALUES (@CustomerName, @Age, @Address)";

                comm.Parameters.AddWithValue("@CustomerName", customerName);
                comm.Parameters.AddWithValue("@Age", age);
                comm.Parameters.AddWithValue("@Address", address);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; // Returns true if insertion was successful
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }

        public bool UpdateCustomer(int customerId, string newCustomerName, int newAge, string newAddress)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "UPDATE customers SET CustomerName = @NewCustomerName, Age = @NewAge, Address = @NewAddress WHERE CustomerID = @CustomerID";

                comm.Parameters.AddWithValue("@NewCustomerName", newCustomerName);
                comm.Parameters.AddWithValue("@NewAge", newAge);
                comm.Parameters.AddWithValue("@NewAddress", newAddress);
                comm.Parameters.AddWithValue("@CustomerID", customerId);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; // Returns true if update was successful
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "DELETE FROM customers WHERE CustomerID = @CustomerID";

                comm.Parameters.AddWithValue("@CustomerID", customerId);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; // Returns true if deletion was successful
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }




        //CURD OPERATIONS FOR THE ORDERS TABLE

        public DataTable SelectOrders()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            DataTable dataTable = new DataTable();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * FROM orders";
                NpgsqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
            return null;
        }

        public bool InsertOrder(int customerId, int quantity, decimal price)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO orders (CustomerID, Quantity, Price) VALUES (@CustomerID, @Quantity, @Price)";

                comm.Parameters.AddWithValue("@CustomerID", customerId);
                comm.Parameters.AddWithValue("@Quantity", quantity);
                comm.Parameters.AddWithValue("@Price", price);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }

        public bool UpdateOrder(int orderId, int customerId, int quantity, decimal price)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "UPDATE orders SET CustomerID = @CustomerID, Quantity = @Quantity, Price = @Price WHERE OrderID = @OrderID";

                comm.Parameters.AddWithValue("@CustomerID", customerId);
                comm.Parameters.AddWithValue("@Quantity", quantity);
                comm.Parameters.AddWithValue("@Price", price);
                comm.Parameters.AddWithValue("@OrderID", orderId);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }

        public bool DeleteOrder(int orderId)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "DELETE FROM orders WHERE OrderID = @OrderID";

                comm.Parameters.AddWithValue("@OrderID", orderId);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }




        //CURD OPRATIONS FOR THE INVENTORY TABLE



        public DataTable SelectInventory()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            DataTable dataTable = new DataTable();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "SELECT * FROM inventory";
                NpgsqlDataReader reader = comm.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
            return null;
        }

        public bool InsertInventory(string productName, int customerName, int quantity, decimal price, DateTime date)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "INSERT INTO inventory (ProductName, CustomerName, Quantity, Price, Date) VALUES (@ProductName, @CustomerName, @Quantity, @Price, @Date)";

                comm.Parameters.AddWithValue("@ProductName", productName);
                comm.Parameters.AddWithValue("@CustomerName", customerName);
                comm.Parameters.AddWithValue("@Quantity", quantity);
                comm.Parameters.AddWithValue("@Price", price);
                comm.Parameters.AddWithValue("@Date", date);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; // Returns true if insertion was successful
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }

        public bool UpdateInventory(int productId, string productName, int customerName, int quantity, decimal price, DateTime date)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "UPDATE inventory SET ProductName = @ProductName, CustomerName = @CustomerName, Quantity = @Quantity, Price = @Price, Date = @Date WHERE ProductID = @ProductID";

                comm.Parameters.AddWithValue("@ProductName", productName);
                comm.Parameters.AddWithValue("@CustomerName", customerName);
                comm.Parameters.AddWithValue("@Quantity", quantity);
                comm.Parameters.AddWithValue("@Price", price);
                comm.Parameters.AddWithValue("@Date", date);
                comm.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; // Returns true if update was successful
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }

        public bool DeleteInventory(int productId)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            NpgsqlCommand comm = new NpgsqlCommand();
            try
            {
                conn.Open();

                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.CommandText = "DELETE FROM inventory WHERE ProductID = @ProductID";

                comm.Parameters.AddWithValue("@ProductID", productId);

                int rowsAffected = comm.ExecuteNonQuery();

                return rowsAffected > 0; // Returns true if deletion was successful
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                comm.Dispose();
                conn.Close();
            }
        }
    }
}
