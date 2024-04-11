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
using System.Text.RegularExpressions;

namespace KEELS_Super_POS.Forms.Nexus
{
    public partial class DeleteMember : Form
    {
        public DeleteMember()
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
                    cmd = new SqlCommand("Delete from Member_Tbl where Member_ID = '" + txt_memid.Text + "'", con);
                    int x = cmd.ExecuteNonQuery();
                    con.Close();

                    if (x == 1)
                    {
                        MessageBox.Show("Member Delted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Member Cannot Be Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            label4.Text = "null";
            txt_memid.Clear();
            txt_name.Clear();
            txt_tpo.Clear();
            btn_edit.Enabled = false;

        }

        private void DeleteMember_Load(object sender, EventArgs e)
        {
            Refresh();
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
