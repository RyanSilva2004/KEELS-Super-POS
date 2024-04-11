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


namespace KEELS_Super_POS.Forms
{
    public partial class EditProductCategory : Form
    {
        public EditProductCategory()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        private void Refresh()
        {
            this.category_TblTableAdapter.Fill(this.keels_SuperMarket_DatabaseDataSet.Category_Tbl);
            
            txt_cname.Clear();
            txt_cdes.Clear();
            txt_cname.Enabled = false;
            txt_cdes.Enabled = false;
            btn_edit.Enabled = false;
        }
        private void EditProductCategory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'keels_SuperMarket_DatabaseDataSet.Category_Tbl' table. You can move, or remove it, as needed.
            Refresh();
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            
            dataGridView2.DefaultCellStyle.Font = new Font("Consolas", 7,FontStyle.Bold);
            

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_cname.Text.Length == 0)
                {
                    MessageBox.Show("Category Name Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (txt_cdes.Text.Length == 0)
                {
                    MessageBox.Show("Category Description Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("Update Category_Tbl set Category_Name ='" + txt_cname.Text + "',Category_Description = '" + txt_cdes.Text + "' where Category_ID = '" + txt_cid.Text + "'", con);
                    int x = cmd.ExecuteNonQuery();
                    if (x == 1)
                    {
                        MessageBox.Show("Category Updated Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Category Cannot Be Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    Refresh();
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_cid.Clear();
            txt_cname.Clear();
            txt_cdes.Clear();
            txt_cname.Enabled = false;
            txt_cdes.Enabled = false;
            btn_edit.Enabled = false;
        }

        private void txt_cid_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select Category_ID,Category_Name,Category_Description from Category_Tbl where Category_ID = @cid", con);
            cmd.Parameters.AddWithValue("cid", txt_cid.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt_cname.Text = reader["Category_Name"].ToString();
                txt_cdes.Text = reader["Category_Description"].ToString();
                txt_cname.Enabled = true;
                txt_cdes.Enabled = true;
                btn_edit.Enabled = true;

            }
            else
            {
                MessageBox.Show("Category Data Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txt_cid.Text.Length == 0)
            {
                MessageBox.Show("Category ID Cannot Be Blanck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else { 
                con.Open();
                cmd = new SqlCommand("Select Category_ID,Category_Name,Category_Description from Category_Tbl where Category_ID = @cid", con);
                cmd.Parameters.AddWithValue("cid", txt_cid.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txt_cname.Text = reader["Category_Name"].ToString();
                    txt_cdes.Text = reader["Category_Description"].ToString();
                    txt_cname.Enabled = true;
                    txt_cdes.Enabled = true;
                    btn_edit.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Category Data Not Found or Category ID Is Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
           
        }
    }
}
