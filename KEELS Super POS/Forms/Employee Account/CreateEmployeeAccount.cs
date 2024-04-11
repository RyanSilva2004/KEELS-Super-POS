using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KEELS_Super_POS.Forms.Employee_Account
{
    public partial class CreateEmployeeAccount : Form
    {
        public CreateEmployeeAccount()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        int check = 0;

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

        private void CreateEmployeeAccount_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'keels_SuperMarket_DatabaseDataSet6.Employee_Table' table. You can move, or remove it, as needed.
            this.employee_TableTableAdapter.Fill(this.keels_SuperMarket_DatabaseDataSet6.Employee_Table);
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_fname.TextLength == 0)
                {
                    MessageBox.Show("Full Name Cannot Be Blank","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(txt_uname.Text.Length == 0)
                {
                    MessageBox.Show("User Name Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(check == 1)
                {
                    MessageBox.Show("User Name Allready Taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_password.Text.Trim() != txt_password2.Text.Trim())
                {
                    MessageBox.Show("Enterd Passwords Doesnt Match Please Check Again","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (pfp_pbox.Image == null)
                {
                    MessageBox.Show("Please Upload a Profile Picture", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("Insert into Employee_Table values('"+txt_fname.Text+"','"+txt_uname.Text+"','"+txt_password2.Text+"',@a,@b)",con); 
                    cmd.Parameters.AddWithValue("a", cmd_role.SelectedItem);
                    MemoryStream memoryStream = new MemoryStream();
                    pfp_pbox.Image.Save(memoryStream, pfp_pbox.Image.RawFormat);
                    cmd.Parameters.AddWithValue("b", memoryStream.ToArray());
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i == 1)
                    {
                        MessageBox.Show("New Employee Account Created Succesfully","Info",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error Occured Employee Account Cannot Be Created", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_fname.Clear();
            txt_password.Clear();
            txt_password2.Clear();
            txt_uname.Clear();
            cmd_role.SelectedIndex = -1;
            pfp_pbox.Image = null;
        }

        private void CheckUserName()
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Employee_Table where User_Name ='" + txt_uname.Text+"'", con))
            {
                con.Open();
                int userCount = (int)sqlCommand.ExecuteScalar();
                con.Close();
                if (userCount > 0) 
                {
                    check = 1;
                }
                else
                {
                    check = 0;
                }
            }
        }

        private void txt_uname_TextChanged(object sender, EventArgs e)
        {
            CheckUserName();
        }
    }
}
