using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace connectDB
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Products", connection);
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);

                dgv1.DataSource = dataTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Products (ProductID, ProductPrice, Quantity, ProductName) VALUES (@ProductID, @ProductPrice, @Quantity, @ProductName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                        command.Parameters.AddWithValue("@ProductPrice", txtProductPrice.Text);
                        command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                        command.Parameters.AddWithValue("@ProductName", txtProductName.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Product created successfully!");
                        RefreshDataGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Products SET ProductPrice = @ProductPrice, Quantity = @Quantity, ProductName = @ProductName WHERE ProductID = @ProductID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                        command.Parameters.AddWithValue("@ProductPrice", txtProductPrice.Text);
                        command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                        command.Parameters.AddWithValue("@ProductName", txtProductName.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Product updated successfully!");
                        RefreshDataGrid();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Products WHERE ProductID = @ProductID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", txtProductID.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Product deleted successfully!");
                        RefreshDataGrid(); // Refresh DataGridView
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {

        }
        private void RefreshDataGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Products", connection);
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);

                dgv1.DataSource = dataTable;
            }
        }
    }   
}
