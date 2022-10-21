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
namespace Bankamatik_Simülasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-48MHJFV;Initial Catalog=Banka Simulation;Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Select * From Account where Account_Number=@p1 and Password=@p2", connection);
                command.Parameters.AddWithValue("@p1", txtaccount.Text);
                command.Parameters.AddWithValue("@p2", txtpassword.Text);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    Form3 frm3 = new Form3();
                    frm3.account_number = txtaccount.Text;
                    frm3.Show();
                }
                else
                {
                  MessageBox.Show("Invalid Login", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception e1)
            {
                  MessageBox.Show("Invalid Login", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Opacity = 0;
            this.ShowInTaskbar = false;
            //this.SetVisibleCore(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
