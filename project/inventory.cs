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
using System.Diagnostics;


namespace project
{
    public partial class inventory : Form
    {
        Database D= new Database();
       bool isTrue=false;
        public inventory()
        {
            InitializeComponent();
            dataGridView1.DataSource = D.SelectInventory();
        }


        private void UpdateInventoryTable()
        {
            dataGridView1.DataSource = D.SelectInventory();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Add buttton
            string ProductName = textBox2.Text;
            int cust_name=Convert.ToInt32(textBox3.Text);
            int quant=Convert.ToInt32(textBox4.Text);   
            decimal price= Convert.ToDecimal(textBox5.Text);
            DateTime date= Convert.ToDateTime(dateTimePicker1.Text);
             isTrue=D.InsertInventory(ProductName, cust_name, quant, price, date);

            if(isTrue)
            {
                MessageBox.Show("Data added susesfully");
                UpdateInventoryTable();
            }
            else
            {
                MessageBox.Show("error while adding the data");
            }


        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            //Update Button
            int productId = Convert.ToInt32(textBox1.Text);
            string ProductName = textBox2.Text;
            int cust_name = Convert.ToInt32(textBox3.Text);
            int quant = Convert.ToInt32(textBox4.Text);
            decimal price = Convert.ToDecimal(textBox5.Text);
            DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
            isTrue = D.UpdateInventory(productId, ProductName, cust_name, quant, price, date);

            if (isTrue)
            {
                MessageBox.Show("Data Updated susesfully");
                UpdateInventoryTable();
            }
            else
            {
                MessageBox.Show("error while Updating the data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // delete button
            int productId = Convert.ToInt32(textBox1.Text);
            isTrue = D.DeleteInventory(productId);

            if (isTrue)
            {
                MessageBox.Show("Data deleted susesfully");
                UpdateInventoryTable();
            }
            else
            {
                MessageBox.Show("error while deleting the data");
            }

        }
        
            
    

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex=e.RowIndex;


            this.textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            this.textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            this.textBox5.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            this.dateTimePicker1.Text= dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
        }
    }
}
