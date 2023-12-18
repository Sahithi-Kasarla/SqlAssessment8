using System;
using System.Data;
using System.Data.SqlClient;

namespace Assignment8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conStr = "server=DESKTOP-MONMK0F;database=Assignment8;trusted_connection=true;";
            DisplayTop5Records(conStr);
            InsertRecord(conStr);
            UpdateRecord(conStr);
             DeleteRecord(conStr);
                }
        static void DisplayTop5Records(string conStr)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                string query = "SELECT TOP 5 * FROM Products ORDER BY PNAme DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("Top 5 Records:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"Pid: {reader["Pid"]}, PName: {reader["PName"]}");
                            // Display other columns as needed
                        }
                    }
                }
            }
        }
            static void InsertRecord(string conStr)
            {
                Console.WriteLine("Enter values for the new record:");

                Console.Write("Pid ");
                string newPid = Console.ReadLine();

                Console.Write("PNAme: ");
                string newPNAme = Console.ReadLine();
            Console.Write("PPrice");
            string newPPrice=Console.ReadLine();

                // You can prompt the user for other column values as needed

                // Insert the new record into the database
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    connection.Open();

                    string query = "INSERT INTO Products (Pid, PNAme,PPrice) VALUES (@Pid, @PNAme,@PPrice)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Pid", newPid);
                        command.Parameters.AddWithValue("@PNAme", newPNAme);
                    command.Parameters.AddWithValue("@PPrice", newPPrice);


                    command.ExecuteNonQuery();

                        Console.WriteLine("Record inserted successfully!");
                    }
                }
            }
        static void UpdateRecord(string conStr)
        {
            Console.WriteLine("Enter values for the record to update:");

            Console.Write("Enter Pid of the record to update: ");
            string updatePid = Console.ReadLine();

            Console.Write("New PNAme: ");
            string newPNAme = Console.ReadLine();

            Console.Write("New PPrice: ");
            string newPPrice = Console.ReadLine();

            // You can prompt the user for other column values as needed

            // Update the record in the database
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                string query = "UPDATE Products SET PNAme = @PNAme WHERE Pid = @Pid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Pid", updatePid);
                    command.Parameters.AddWithValue("@PNAme", newPNAme);
                    command.Parameters.AddWithValue("@PPrice", newPPrice);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Record not found. No update performed.");
                    }
                }
            }
        }
        static void DeleteRecord(string conStr)
        {
            Console.WriteLine("Enter Pid of the record to delete:");

            Console.Write("Pid: ");
            string deletePid = Console.ReadLine();

            // Delete the record from the database
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                string query = "DELETE FROM Products WHERE Pid = @Pid";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Pid", deletePid);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Record not found. No deletion performed.");
                    }
                }
            }
        }
    }
}
    

