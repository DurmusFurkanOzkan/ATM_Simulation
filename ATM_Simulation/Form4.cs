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
    public partial class Form4 : Form
    {
        public string account_number;

        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-48MHJFV;Initial Catalog=Banka Simulation;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update Account set bakiye=bakiye-@p1 where Account_Number=" + account_number, connection);
            command.Parameters.AddWithValue("@p1", money.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Money is sended", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            SqlCommand command1 = new SqlCommand("Update Account set bakiye=bakiye+@p1 where Account_Number=" + receiver_account_number.Text, connection);
            command1.Parameters.AddWithValue("@p1", money.Text);
            command1.ExecuteNonQuery();
            connection.Close();
        }
    }
}
