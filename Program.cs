using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Data.SqlClient; // Use the newer package
namespace Villasurda_FinalPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to SQL Server...");
            // --- !!! PASTE YOUR COPIED CONNECTION STRING HERE !!! ---
            // IMPORTANT: For production, use secure configuration methods, not hardcoding.

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MySampleDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            // Note: Added TrustServerCertificate=True for localdev / LocalDB simplicity.Might need Encrypt = True for production / Azure SQL.
    // Use 'using' statements for SqlConnection and SqlCommand to                    ensure proper disposal
    
                try
                {
                    using (SqlConnection connection = new
                    SqlConnection(connectionString))
                    {
                        connection.Open(); // Open the database connection
                        Console.WriteLine("Connection Successful!");
                        // 1. --- Read Data ---
                        Console.WriteLine("\n--- Reading Users ---");
                        string selectSql = "SELECT UserID, FirstName, Email FROM Users ORDER BY FirstName";
        
                                       using (SqlCommand command = new SqlCommand(selectSql,
                                               connection))
                        {
                            using (SqlDataReader reader =
                                       command.ExecuteReader()) // Use ExecuteReader for SELECT
                            {
                                // Check if any rows were returned
                                if (reader.HasRows)
                                {
                                    Console.WriteLine("ID\tFirstName\tEmail");
                                    Console.WriteLine("------------------------------------");
    // Loop through each row
                                                  while (reader.Read())
                                    {
                                        // Access columns by name or index
                                        int userId =
                                            reader.GetInt32(reader.GetOrdinal("UserID")); // Safer way to get column index
                                        

                                    string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                        string email = reader.GetString(reader.GetOrdinal("Email"));

                                        Console.WriteLine($"{userId}\t{firstName}\t\t{email}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No users found.");
                                }
                            } // SqlDataReader is automatically closed and disposed here

                    } // SqlCommand is automatically disposed here
                      // 2. --- Insert Data ---
                        Console.WriteLine("\n--- Inserting a New User ---");
                        string newFirstName = "Charlie";
                        string newEmail = "charlie@example.com";
                        // USE PARAMETERIZED QUERIES TO PREVENT SQL INJECTION!
                        string insertSql = "INSERT INTO Users (FirstName, Email) VALUES(@FirstName, @Email); SELECT SCOPE_IDENTITY(); "; 
    
                   // SCOPE_IDENTITY gets the new ID
    
                    int newUserId = 0;
            // Check if user already exists before inserting
            string checkSql = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
    
                                              int existingCount = 0;
            using (SqlCommand checkCommand = new
            SqlCommand(checkSql, connection))
            {
                checkCommand.Parameters.AddWithValue("@Email",
                                                     newEmail);
                existingCount = (int)checkCommand.ExecuteScalar();
                // ExecuteScalar is good for single values
            }
            if (existingCount == 0)
            {
                using (SqlCommand command = new
                SqlCommand(insertSql, connection))
                {
                    // Add parameters and their values
                    command.Parameters.AddWithValue("@FirstName",
                                                    newFirstName);
                    command.Parameters.AddWithValue("@Email",
                                                    newEmail);
                            // Use ExecuteScalar when you expect a single value back(like the new ID)

                            object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        newUserId = Convert.ToInt32(result);
                        Console.WriteLine($"Successfully inserted { newFirstName} with UserID: {newUserId}");

                            }
                    else
                    {
                        Console.WriteLine($"Failed to insert{ newFirstName}.");

                            }
                } // SqlCommand disposed
            }
            else
            {
                Console.WriteLine($"User with email {newEmail}already exists.Skipping insert.");

                    }
            // 3. --- Verify Insert (Read Data Again) ---
            Console.WriteLine("\n--- Reading Users After Insert -- - ");
    
                                      using (SqlCommand command = new SqlCommand(selectSql,
                                              connection)) // Re-use the selectSql query
            {
                using (SqlDataReader reader =
                           command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        Console.WriteLine("ID\tFirstName\tEmail");
                        Console.WriteLine("---------------------- -------------- - ");

                                                  while (reader.Read())
                        {

                            Console.WriteLine($"{reader["UserID"]}\t{reader["FirstName"]}\t\t{reader["Email"]}"); // Access columns by name
								}
							}
						} // Reader disposed
					} // Command disposed
                      // Add UPDATE and DELETE examples here similarly,using ExecuteNonQuery()

                    // Example: Delete Charlie
                    /*
					Console.WriteLine("\n--- Deleting Charlie ---");
					 string deleteSql = "DELETE FROM Users WHERE UserID =
					@UserID";
					 using (SqlCommand deleteCommand = new
					SqlCommand(deleteSql, connection))
					 {
					 deleteCommand.Parameters.AddWithValue("@UserID",
					newUserId); // Use the ID we got from the insert
					 int rowsAffected =
					deleteCommand.ExecuteNonQuery(); // ExecuteNonQuery for INSERT, UPDATE,
					DELETE
					 Console.WriteLine($"Deleted {rowsAffected}
					row(s).");
					 }
					*/
                } // SqlConnection is automatically closed and disposed  here, even if errors occurred

            }
		catch (SqlException ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"SQL Error: {ex.Message}");
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"General Error: {ex.Message}");
				Console.ResetColor();
			}
		Console.WriteLine("\nPress any key to exit.");

    Console.ReadKey();
                        }
                    }
                }
