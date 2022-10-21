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
    public partial class Form2 : Form
    {

        public static int i=0;
        public static int j=0;
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-48MHJFV;Initial Catalog=Banka Simulation;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {   
            Form1 form1 = new Form1();
            form1.Show();
            this.Opacity = 0;
            this.ShowInTaskbar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           connection.Open();
            SqlCommand command = new SqlCommand("insert into Account (Name,Surname,ID_Number,Telephone_Number,Account_Number,Password) values(@p1,@p2,@p3,@p4,@p5,@p6)",connection);
            command.Parameters.AddWithValue("@p1", txtname.Text);
            command.Parameters.AddWithValue("@p2", txtsurname.Text);
            command.Parameters.AddWithValue("@p3", txtidnumber.Text);
            command.Parameters.AddWithValue("@p4", txt_telephone_number.Text);
            command.Parameters.AddWithValue("@p5", txt_account_number.Text);
            command.Parameters.AddWithValue("@p6", txt_password.Text);
            if(txt_password.Text==txt_password_again.Text)
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Account added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Opacity = 0;
                this.ShowInTaskbar = false;
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Please enter the same password", "İnformation", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            connection.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {  if(i%2==0)
            txt_password.UseSystemPasswordChar = false;
           else
            txt_password.UseSystemPasswordChar = true;
            i++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (j % 2 == 0)
                txt_password_again.UseSystemPasswordChar = false;
            else
                txt_password_again.UseSystemPasswordChar = true;
            j++;
        }
    }
}
