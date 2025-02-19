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
using System.Data.Sql;

namespace BogsyProject
{
    public partial class Form7 : Form
    {

        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Alan Paul Muring\source\repos\BogsyProject\BogsyProject\BogsyDatabase.mdf"";Integrated Security=True");
            cn.Open();

            GetAllRentalRecord();

            // TODO: This line of code loads data into the 'modelDataSet.VideoRental' table. You can move, or remove it, as needed.


        }
        private void GetAllRentalRecord()
        {
            cmd = new SqlCommand("Select * from VideoRental", cn);

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5();

            form5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 form6 = new Form6();

            form6.ShowDialog();
        }
    }
}
