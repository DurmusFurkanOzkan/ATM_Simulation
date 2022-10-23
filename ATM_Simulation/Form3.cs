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
    public partial class Form3 : Form
    {
        
        public string account_number;
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-48MHJFV;Initial Catalog=Banka Simulation;Integrated Security=True");
        private void button3_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select Name+' '+Surname,ID_Number,Telephone_Number,Budget from Account where Account_Number=" + account_number, connection);
            SqlDataReader dr = command.ExecuteReader();
            while(dr.Read())
            {
                name_surname.Text = dr[0].ToString();
                ID_number.Text = dr[1].ToString();
                Telephone_number.Text = dr[2].ToString();
                budget.Text = dr[3].ToString();
            }
            account_no.Text = account_number;
            
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.account_number = account_number;
            form.Show();
        }
    }
}
