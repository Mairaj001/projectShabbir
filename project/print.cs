using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class print : Form
    {
        public print()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtOutput.Text += "**Inventory Details**\n";
         
            txtOutput.Text += "productID:" + txtid + "\n\n";
            txtOutput.Text += "productName:" + txtName + "\n\n";
            txtOutput.Text += "customerName:" + txtcusName + "\n\n";
            txtOutput.Text += "Quentity:" + txtQuentity+ "\n\n";
            txtOutput.Text += "price:" + txtPrice + "\n\n";
            txtOutput.Text += "date:" + DateTime.Now + "\n\n";

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(txtOutput.Text, new Font("Microsoft sans serif", 18, FontStyle.Bold), Brushes.Black, new Point(10, 10));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
