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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Form activeform = null;
        private void openchildform(Form childform)
        {
            if (activeform != null)
                activeform.Close();
            activeform = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            Formpanel.Controls.Add(childform);
            Formpanel.Tag = childform;
            childform.BringToFront();
            childform.Show();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= 50)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                }
            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 159)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                openchildform(new product());
            }catch(Exception ex) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            openchildform(new customers());
            }
            catch (Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
            openchildform(new order());
            }
            catch (Exception ex) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try { 
            openchildform(new inventory());
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
            openchildform(new print());
            }
            catch (Exception ex) { }
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openchildform(new user());
            }
            catch (Exception ex) { }
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                openchildform(new inventory());

            
               }catch(Exception ex) { }
}

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
