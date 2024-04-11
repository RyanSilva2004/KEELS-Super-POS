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
using System.Data.SqlClient;
using System.IO;

namespace KEELS_Super_POS.Forms.Employee_Account
{
    public partial class DeleteAccount : Form
    {
        public DeleteAccount()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void btn_check_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select Full_Name,Password,Role from Employee_Table  where User_Name = '" + txt_uname.Text + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt_fname.Text = reader["Full_Name"].ToString();
                txt_password.Text = reader["Password"].ToString();
                cmd_role.Text = reader["Role"].ToString();
                btn_delete.Enabled = true;
            }
            else
            {
                MessageBox.Show("Account Not Found or Username Is Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void DeleteAccount_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("Delete from Employee_Table where User_Name ='"+txt_uname.Text+"'", con);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                {
                    MessageBox.Show("Deleted Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Occured Cannot Be Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_fname.Clear();
            txt_password.Clear();

            txt_uname.Clear();
            cmd_role.SelectedIndex = -1;
            
        }
    }
}
