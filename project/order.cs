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
    public partial class order : Form
    {
        Database db = new Database();
        bool IsOrders=false;    

        public order()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.SelectOrders();
        }

        private void UpdateOrderTable()
        {
            dataGridView1.DataSource = db.SelectOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Button

            int cust_id = Convert.ToInt32(textBox2.Text);
            int qunat=Convert.ToInt32(textBox3.Text); 
            decimal price= Convert.ToDecimal(textBox4.Text);

            IsOrders=db.InsertOrder(cust_id, qunat, price);

            if(IsOrders)
            {
                MessageBox.Show("Order added Sussesfully"); UpdateOrderTable();
            }
            else
            {
                MessageBox.Show("Error while adding the order");
            }

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            //Update Function
            int order_id=Convert.ToInt32(textBox1.Text);  
            int cust_id = Convert.ToInt32(textBox2.Text);
            int qunat = Convert.ToInt32(textBox3.Text);
            decimal price = Convert.ToDecimal(textBox4.Text);

            IsOrders = db.UpdateOrder(order_id, cust_id, qunat, price);

            if (IsOrders)
            {
                MessageBox.Show("Order Updated Sussesfully"); UpdateOrderTable();
            }
            else
            {
                MessageBox.Show("Error while updatin the order");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete button
            int order_id = Convert.ToInt32(textBox1.Text);
            IsOrders = db.DeleteOrder(order_id);

            if (IsOrders)
            {
                MessageBox.Show("Order DeletedSussesfully"); UpdateOrderTable();
            }
            else
            {
                MessageBox.Show("Error while Deleting the order");
            }


        }

        

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            this.textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            this.textBox4.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
        }
    }
}
