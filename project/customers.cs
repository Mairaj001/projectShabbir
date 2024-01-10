using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
namespace project
{
    public partial class customers : Form
    {
        Database D= new Database();
        bool IsUpdated=false;

        public customers()
        {
            InitializeComponent();
            dataGridView1.DataSource = D.SelectCustomers();
        }


        private void UpdateCustomersTable()
        {
            dataGridView1.DataSource = D.SelectCustomers();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Add Button 
            string cust_name = textBox2.Text;
            int age=Convert.ToInt32(textBox3.Text);
            string address = textBox4.Text;

            IsUpdated = D.InsertCustomer(cust_name, age, address);
            if(IsUpdated)
            {
                MessageBox.Show("Customer added sussesfully");
                UpdateCustomersTable();
            }
            else
            {
                MessageBox.Show("Error while adding the data ");
            }
        }
       
       

        private void button2_Click(object sender, EventArgs e)
        {
            //Update Button
            int cust_id = Convert.ToInt32(textBox1.Text);   
            string cust_name = textBox2.Text;
            int age = Convert.ToInt32(textBox3.Text);
            string address = textBox4.Text;

            IsUpdated = D.UpdateCustomer(cust_id, cust_name, age, address);
            if (IsUpdated)
            {
                MessageBox.Show("Customer Updated sussesfully");
                UpdateCustomersTable();
            }
            else
            {
                MessageBox.Show("Error while Updating the data ");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete 
            int cust_id = Convert.ToInt32(textBox1.Text);
            IsUpdated = D.DeleteCustomer(cust_id);
            if (IsUpdated)
            {
                MessageBox.Show("Customer Updated sussesfully");
                UpdateCustomersTable();
            }
            else
            {
                MessageBox.Show("Error while Updating the data ");
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            this.textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
