using KEELS_Super_POS.Forms.Cashier;
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

namespace KEELS_Super_POS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        public static string UserName; 
       
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Cashier x = new Cashier();
            //x.Show();
            //this.Hide();
            //try
            {
                if (txt_password.Text.Length == 0 || txt_username.Text.Length == 0)
                {
                    MessageBox.Show("User Name or Password Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Please Select A Role To Login", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (comboBox1.SelectedIndex == 0) // Admin Form
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * From Employee_Table where User_Name ='" + txt_username.Text + "' and Password ='" + txt_password.Text + "' and Role='" + comboBox1.SelectedItem.ToString() + "'", con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        UserName = txt_username.Text;
                        Home x = new Home();
                        x.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("User Name , Password OR Selected Role Is Incorrect Please Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else if (comboBox1.SelectedIndex == 1) // Cashier Form
                {
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * From Employee_Table where User_Name ='" + txt_username.Text + "' and Password ='" + txt_password.Text + "' and Role='" + comboBox1.SelectedItem.ToString() + "'", con);
                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        UserName = txt_username.Text;
                        Cashier x = new Cashier();
                        x.Show();
                        this.Hide();
                        
                    }
                    else
                    {
                        MessageBox.Show("User Name , Password OR Selected Role Is Incorrect Please Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Login Error Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void Login_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
        }
    }
}
