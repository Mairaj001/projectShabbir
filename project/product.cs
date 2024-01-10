using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace project
{
    public partial class product : Form
    {
        Database D = new Database();
        bool IsPlacedData = false;
        public product()
        {
            InitializeComponent();
            dataGridView1.DataSource = D.SelectProdcuts();

        }


        private void UpdateTableContent()
        {
            dataGridView1.DataSource = D.SelectProdcuts();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // add button 
           string ProductName=textBox2.Text;
            decimal ProdcutPrice=decimal.Parse(textBox3.Text);
           

            IsPlacedData= D.InsertProduct(ProductName, ProdcutPrice);

            if(IsPlacedData)
            {
                MessageBox.Show("Data inserted");
                UpdateTableContent();
            }
            else
            {
                MessageBox.Show("Error in Database");
            }


        }
      
        

        private void button2_Click(object sender, EventArgs e)
        {
            //Update Button
            string ProductName = textBox2.Text;
            decimal ProdcutPrice = decimal.Parse(textBox3.Text);
            int ProdcutId = Convert.ToInt32(textBox1.Text);

            IsPlacedData = D.UpdateProduct(ProdcutId,ProductName, ProdcutPrice);

            if(IsPlacedData)
            {
                MessageBox.Show("Data is updated");
                UpdateTableContent();
            }
            else
            {
                MessageBox.Show("Error while updating to the database");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {

            // delete Button;
            int Product_id=Convert.ToInt32(textBox1.Text);
            IsPlacedData=D.DeleteProduct(Product_id);
            if(IsPlacedData)
            {
                MessageBox.Show("Product is deleted sussesfully");
                UpdateTableContent();
            }
            else
            {
                MessageBox.Show("Error while deleting the data");
            }
           
        }

      
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int rowIndex = e.RowIndex; int columnIndex = e.ColumnIndex;

            this.textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            this.textBox2.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            this.textBox3.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}





