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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace KEELS_Super_POS.Forms.Nexus
{
    public partial class AddNewMember : Form
    {
        public AddNewMember()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        int check = 0;

        private void AddNewMember_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            Refresh_Nexus_Table();
            AutoNexusMemberID();
        }
        private void CheckTPO()
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Member_Tbl where TPO ='" + txt_tpo.Text + "'", con))
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

        private void Refresh_Nexus_Table()
        {
            
        }
        int ax;
        private void AutoNexusMemberID()
        {
            con.Open();
            cmd = new SqlCommand("Select count (Member_ID) from [Member_Tbl]", con);
            ax = Convert.ToInt32(((SqlCommand)cmd).ExecuteScalar());
            con.Close();
            ax++;
            txt_memid.Text = "NMEM" + ax.ToString();
        }
        private void FixID()
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Member_Tbl where TPO = '" + txt_memid.Text + "' ", con))
            {
                con.Open();

                int userCount = (int)sqlCommand.ExecuteScalar();
                con.Close();
                if (userCount > 0)
                {
                    ax = ax + 1;
                    txt_memid.Text = "NMEM" + ax.ToString();
                }
                else
                {

                }
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_memid.Clear();
            txt_name.Clear();
            txt_tpo.Clear();
        }
        
        private void btn_add_Click(object sender, EventArgs e)
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
                else if(check == 1)
                {
                    MessageBox.Show("An Account Is Allready Registerd Under This Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int xyz = 0;
                    con.Open();
                    cmd = new SqlCommand("Insert Into Member_Tbl values('" + txt_memid.Text + "','" + txt_name.Text + "','" + txt_tpo.Text + "','" + label4.Text + "')", con);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if(i == 1)
                    {
                        MessageBox.Show("New Member Registerd Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New Member Cannot Be Registerd", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txt_tpo_TextChanged(object sender, EventArgs e)
        {
            CheckTPO();
        }
    }
}
