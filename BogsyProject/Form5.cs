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

namespace BogsyProject
{
    public partial class Form5 : Form
    {

        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1";
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alan Paul Muring\source\repos\BogsyProject\BogsyProject\BogsyDatabase.mdf"";Integrated Security=True");
            cn.Open();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PerformSearch(string searchTerm)
        {
            // SQL query to search the data based on FirstName (adjust table and column names accordingly)
            string query = "SELECT * FROM CustomerInformation WHERE FirstName LIKE @SearchTerm";

            // Open database connection
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alan Paul Muring\source\repos\BogsyProject\BogsyProject\BogsyDatabase.mdf"";Integrated Security=True");
            cn.Open();

            // Create SQL command
            cmd = new SqlCommand(query, cn);

            // Add parameter with the search term
            cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

            // Execute the query and get the data
            dr = cmd.ExecuteReader();

            // Check if data is found
            if (dr.Read())
            {
                // Populate the TextBoxes with the data from the database
                txtFname.Text = dr["FirstName"].ToString();
                txtLname.Text = dr["LastName"].ToString();
                txtPnumber.Text = dr["PhoneNumber"].ToString();
                txtEaddress.Text = dr["EmailAddress"].ToString();
                txtHaddress.Text = dr["HomeAddress"].ToString();
            }
            else
            {
                MessageBox.Show("Name Not Found");
            }

            // Close data reader and connection
            dr.Close();
            cn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                string searchTerm = txtSearch.Text.Trim(); // Get search term from TextBox

                // Call the method to perform the search
                PerformSearch(searchTerm);
            }
            else
            {
                MessageBox.Show("Please enter a First Name to search.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                string searchTerm = textBox2.Text.Trim(); // Get search term from TextBox

                // Call the method to perform the search
                VideoSearch(searchTerm);
            }
            else
            {
                MessageBox.Show("Please enter a Video Name to search.");
            }

        }

        private void VideoSearch(string searchTerm)
        {
            // SQL query to search the data based on FirstName (adjust table and column names accordingly)
            string query = "SELECT * FROM VideoInformation WHERE Title LIKE @SearchTerm";

            // Open database connection
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alan Paul Muring\source\repos\BogsyProject\BogsyProject\BogsyDatabase.mdf"";Integrated Security=True");
            cn.Open();

            // Create SQL command
            cmd = new SqlCommand(query, cn);

            // Add parameter with the search term
            cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

            // Execute the query and get the data
            dr = cmd.ExecuteReader();

            // Check if data is found
            if (dr.Read())
            {
                // Populate the TextBoxes with the data from the database
                txtTitle.Text = dr["Title"].ToString();
                txtCat.Text = dr["Category"].ToString();
                txtPrice.Text = dr["Price"].ToString();
                txtQuan.Text = dr["StockQuantity"].ToString();
                txtMax.Text = dr["DaysMax"].ToString();
            }
            else
            {
                MessageBox.Show("Video Not Found");
            }

            // Close data reader and connection
            dr.Close();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RentInfo();

            this.Hide();
            Form7 form7 = new Form7();

            form7.ShowDialog();


        }

        protected void RentInfo()
        {
            string QUERY = "INSERT INTO VideoRental" +
                "" + "(FirstName, LastName, PhoneNumber, Title, Category, Price, Quantity) " +
                "VALUES ( @FirstName, @LastName, @PhoneNumber, @Title, @Category, @Price , @Quantity )";

            SqlCommand CMD = new SqlCommand(QUERY, cn);
            CMD.Parameters.AddWithValue("@FirstName", txtFname.Text);
            CMD.Parameters.AddWithValue("@LastName", txtLname.Text);
            CMD.Parameters.AddWithValue("@PhoneNumber", txtPnumber.Text);
            CMD.Parameters.AddWithValue("@Title", txtTitle.Text);
            CMD.Parameters.AddWithValue("@Category", txtCat.Text);
            CMD.Parameters.AddWithValue("@Price", txtPrice.Text);
            CMD.Parameters.AddWithValue("@Quantity", textBox1.Text);
            CMD.ExecuteNonQuery();
        }
    }
}
