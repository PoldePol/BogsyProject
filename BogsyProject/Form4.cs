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
    public partial class Form4 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
          
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alan Paul Muring\source\repos\BogsyProject\BogsyProject\BogsyDatabase.mdf"";Integrated Security=True");
            cn.Open();
            GetAllVideoRecord();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != "" && txtCat.Text != "" && txtPrice.Text != "" && txtQuan.Text != "")
            {
                SaveVideoInfo();
            }
            else
            {
                MessageBox.Show("Fill out empty space");
            }
            GetAllVideoRecord();
        }

        protected void SaveVideoInfo()
        {
            string QUERY = "INSERT INTO VideoInformation" +
                "" + "(Title, Category, Price, StockQuantity, DaysMax) " +
                "VALUES ( @Title, @Category, @Price, @StockQuantity, @DaysMax)";

            SqlCommand CMD = new SqlCommand(QUERY, cn);
            CMD.Parameters.AddWithValue("@Title", txtTitle.Text);
            CMD.Parameters.AddWithValue("@Category", txtCat.Text);
            CMD.Parameters.AddWithValue("@Price", txtPrice.Text);
            CMD.Parameters.AddWithValue("@StockQuantity", txtQuan.Text);
            CMD.Parameters.AddWithValue("@DaysMax", txtMax.Text);
            CMD.ExecuteNonQuery();
        }

        private void GetAllVideoRecord()
        {
            cmd = new SqlCommand("Select * from VideoInformation", cn);

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();

            form6.ShowDialog();
        }
    }
}
