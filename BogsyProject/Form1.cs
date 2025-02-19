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
    public partial class Form1 : Form
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form3 = new Form3();

            form3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 form2 = new Form2();

            form2.ShowDialog();  

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alan Paul Muring\source\repos\BogsyProject\BogsyProject\BogsyDatabase.mdf"";Integrated Security=True");
            cn.Open();

            GetAllCustomerRecord();
        }

        private void GetAllCustomerRecord()
        {
            cmd = new SqlCommand("Select * from CustomerInformation", cn);

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();

            form6.ShowDialog();
        }
    }
}
