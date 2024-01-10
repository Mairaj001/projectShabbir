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
using System.Data.SqlClient;


namespace project
{
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Data Source=DESKTOP-19JPSQU\\SQLEXPRESS01;Initial Catalog=inventorydb;Persist Security Info=True;User ID=shabbir;Password=***********;");

            con.Open();

            var sqlQuery = "";
            sqlQuery = @"INSERT INTO[inventorydb].dbo.[usertab] ([userID],[Name],[Phone],[Age],[Post])
              VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Adeed Successfully", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Showdata();
        }
        public void Showdata()
        {
            SqlConnection con = new SqlConnection(@"Data Source=Data Source=DESKTOP-19JPSQU\\SQLEXPRESS01;Initial Catalog=inventorydb;Persist Security Info=True;User ID=shabbir;Password=***********;");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT  * FROM [inventorydb].dbo.[usertab]", con);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in table.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["uid"].Value = item["userID"].ToString();
                dataGridView1.Rows[n].Cells["uname"].Value = item["Name"].ToString();
                dataGridView1.Rows[n].Cells["uphone"].Value = item["Phone"].ToString();
                dataGridView1.Rows[n].Cells["uage"].Value = item["Age"].ToString();
                dataGridView1.Rows[n].Cells["upost"].Value = item["Post"].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Data Source=DESKTOP-19JPSQU\\SQLEXPRESS01;Initial Catalog=inventorydb;Persist Security Info=True;User ID=shabbir;Password=***********;Trust Server Certificate=True");

            con.Open();

            var sqlQuery = "";
            sqlQuery = @"UPDATE [usertab] SET Name='" + textBox2.Text + "',[Phone]=  '" + textBox3.Text + "',[Age]= '" + textBox4.Text + "',[Post]= '" + textBox5.Text + "' WHERE [userID] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record UPDATED Successfully", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=Data Source=DESKTOP-19JPSQU\\SQLEXPRESS01;Initial Catalog=inventorydb;Persist Security Info=True;User ID=shabbir;Password=***********;Trust Server Certificate=True");

            con.Open();

            var sqlQuery = "";

            sqlQuery = @"DELETE FROM [usertab] WHERE [userID] = '" + textBox1.Text + "'";
            SqlCommand cnn = new SqlCommand(sqlQuery, con);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record DELETE Successfully", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Showdata();
        }

        private void user_Load(object sender, EventArgs e)
        {
            Showdata();
        }
    }
}
