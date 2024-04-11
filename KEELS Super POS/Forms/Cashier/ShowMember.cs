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
using KEELS_Super_POS.Forms.Cashier;

namespace KEELS_Super_POS
{
    public partial class ShowMember : Form
    {
        public ShowMember()
        {
            InitializeComponent();
            id.Text = Cashier.mem_id_pass;
            id.Visible = false;
        }
        SqlConnection con;
        SqlCommand cmd;

        private void ShowMember_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("Select Member_Name,TPO,Member_Points from Member_Tbl where Member_ID='" + id.Text + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["Member_Name"].ToString();
                textBox3.Text = reader["TPO"].ToString();
                textBox2.Text = reader["Member_Points"].ToString();
            }
            con.Close();
        }
    }
}
