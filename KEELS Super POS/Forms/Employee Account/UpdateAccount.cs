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
using System.IO;
using System.Drawing.Drawing2D;

namespace KEELS_Super_POS.Forms.Employee_Account
{
    public partial class UpdateAccount : Form
    {
        public UpdateAccount()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_fname.TextLength == 0)
                {
                    MessageBox.Show("Full Name Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (pfp_pbox.Image == null)
                {
                    MessageBox.Show("Please Upload a Profile Picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("Update Employee_Table set Full_Name ='"+txt_fname.Text+"',Password='"+txt_password.Text+ "',Role = @a,Image=@b where User_Name ='"+txt_uname.Text+"'", con);
                    cmd.Parameters.AddWithValue("a", cmd_role.SelectedItem);
                    MemoryStream memoryStream = new MemoryStream();
                    pfp_pbox.Image.Save(memoryStream, pfp_pbox.Image.RawFormat);
                    cmd.Parameters.AddWithValue("b", memoryStream.ToArray());
                    int i = cmd.ExecuteNonQuery();
                    if(i == 1)
                    {
                        MessageBox.Show("Updated Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error Occured Cannot Be Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Please select an image to upload", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Error Occured Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txt_fname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_password2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmd_role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog(); // to explore files and select
                pfp_pbox.Image = Image.FromFile(openFileDialog1.FileName);
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Please select an image file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Please select an image to upload", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void UpdateAccount_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            
            con.Open();
            cmd = new SqlCommand("Select Full_Name,Password,Role from Employee_Table  where User_Name = '" + txt_uname.Text+"'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            
            if (reader.Read())
            {
                txt_fname.Text = reader["Full_Name"].ToString();
                txt_password.Text = reader["Password"].ToString();
                cmd_role.Text = reader["Role"].ToString();
                txt_fname.Enabled = true;
                txt_password.Enabled = true;
                cmd_role.Enabled = true;
                btn_update.Enabled = true; 
                btn_upload.Enabled = true;
                
            }
            else
            {
                MessageBox.Show("Account Not Found or Username Is Incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_fname.Clear();
            txt_password.Clear();
            
            txt_uname.Clear();
            cmd_role.SelectedIndex = -1;
            pfp_pbox.Image = null;
            txt_fname.Enabled = false;
            txt_password.Enabled = false;
            cmd_role.Enabled = false;
            btn_update.Enabled = false;
            btn_upload.Enabled = false;
        }

    }
}
