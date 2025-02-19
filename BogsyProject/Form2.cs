using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace BogsyProject
{

    public partial class Form2 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alan Paul Muring\source\repos\BogsyProject\BogsyProject\BogsyDatabase.mdf"";Integrated Security=True");
            cn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtFname.Text != "" && txtLname.Text != "" && txtEAddress.Text != "" && txtPNumber.Text != "" && txtHAddress.Text != "") 
            {
                SaveInfo();
            }
           else
            {
                MessageBox.Show("Fill out empty space");
            }
            this.Hide();
            Form1 form1 = new Form1();

            form1.ShowDialog();

        }

        protected void SaveInfo()
        {
            string QUERY = "INSERT INTO CustomerInformation" +
                "" + "(FirstName, LastName, Birthday, PhoneNumber, EmailAddress, HomeAddress) " +
                "VALUES ( @FirstName, @LastName, @Birthday, @PhoneNumber, @EmailAddress, @HomeAddress)";

            SqlCommand CMD = new SqlCommand(QUERY, cn);
            CMD.Parameters.AddWithValue("@FirstName", txtFname.Text);
            CMD.Parameters.AddWithValue("@LastName", txtLname.Text);
            CMD.Parameters.AddWithValue("@Birthday", dateTimePicker1.Value);
            CMD.Parameters.AddWithValue("@PhoneNumber", txtPNumber.Text);
            CMD.Parameters.AddWithValue("@EmailAddress", txtEAddress.Text);
            CMD.Parameters.AddWithValue("@HomeAddress", txtHAddress.Text);
            CMD.ExecuteNonQuery();
        }

        private void txtLname_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void txtFname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
