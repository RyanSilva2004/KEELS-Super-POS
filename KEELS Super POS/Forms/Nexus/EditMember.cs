using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEELS_Super_POS.Forms.Nexus
{
    public partial class EditMember : Form
    {
        public EditMember()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            { 
            if (txt_memid.Text.Length == 0)
            {
                MessageBox.Show("Member ID Cannot Be Blanck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();
                cmd = new SqlCommand("Select Member_Name,TPO,Member_Points from Member_Tbl where Member_ID = @cid", con);
                cmd.Parameters.AddWithValue("cid", txt_memid.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txt_tpo.Text = reader["TPO"].ToString();
                    txt_name.Text = reader["Member_Name"].ToString();
                    label4.Text = reader["Member_Points"].ToString();
                    txt_tpo.Enabled = true;
                    txt_name.Enabled = true;
                    btn_edit.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Member Data Not Found or Member ID Is Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            }
            catch (FormatException)
            {

                MessageBox.Show("Please Enter A Valid ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception)

            {
                MessageBox.Show("Error Occured Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                Regex r = new Regex(@"^(?:7|0|(?:\+94))[0-9]{9,10}$");
                if (txt_name.Text.Length == 0 || txt_tpo.Text.Length == 0)
                {
                    MessageBox.Show("Details Cannot Be Blanck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_name.Text.Any(Char.IsDigit))
                {
                    MessageBox.Show("Name Cannot Be Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!r.IsMatch(txt_tpo.Text))
                {
                    MessageBox.Show("Enter An Valid Mobile Number ex- 077 xxx xxxx)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("Update Member_Tbl set Member_Name ='" + txt_name.Text + "',TPO = '" + txt_tpo.Text + "' where Member_ID = '" + txt_memid.Text + "'", con);
                    int x = cmd.ExecuteNonQuery();
                    con.Close();
                    
                    if (x == 1)
                    {
                        MessageBox.Show("Member Details Updated Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Member Details Cannot Be Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch (FormatException)
            {

                MessageBox.Show("Please Enter Numbers Only", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception)

            {
                MessageBox.Show("Error Occured Please Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void Refresh()
        {

            txt_tpo.Enabled = false;
            txt_name.Enabled = false;
            btn_edit.Enabled = false;
            label4.Text = "null";
            txt_memid.Clear();
            txt_name.Clear();
            txt_tpo.Clear();

        }

        private void EditMember_Load(object sender, EventArgs e)
        {
            Refresh();
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            txt_tpo.Clear();
        }
    }
}
