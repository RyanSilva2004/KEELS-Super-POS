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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KEELS_Super_POS.Forms
{
    public partial class DeleteProductCategory_cs : Form
    {
        public DeleteProductCategory_cs()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void DeleteProductCategory_cs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'keels_SuperMarket_DatabaseDataSet.Category_Tbl' table. You can move, or remove it, as needed.
            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.MidnightBlue;
            dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            dataGridView3.DefaultCellStyle.Font = new Font("Consolas", 7, FontStyle.Bold);
            Refresh();

            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
        }
        private void Refresh()
        {
            this.category_TblTableAdapter.Fill(this.keels_SuperMarket_DatabaseDataSet.Category_Tbl);
            
            txt_cname.Clear();
            txt_cdes.Clear();
            txt_cname.Enabled = false;
            txt_cdes.Enabled = false;
            btn_delete.Enabled = false;
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select Category_ID,Category_Name,Category_Description from Category_Tbl where Category_ID = @cid", con);
            cmd.Parameters.AddWithValue("cid", txt_cid.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt_cname.Text = reader["Category_Name"].ToString();
                txt_cdes.Text = reader["Category_Description"].ToString();
                btn_delete.Enabled = true;

            }
            else
            {
                MessageBox.Show("Category Data Not Found or Category ID Is Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                    con.Open();
                    cmd = new SqlCommand("Delete from Category_Tbl where Category_ID= '" + txt_cid.Text + "'", con);
            int x = cmd.ExecuteNonQuery();
                    //cmd.Parameters.AddWithValue("cid", txt_cid.Text);
                if (x == 1)
                    {
                        MessageBox.Show("Category Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Category Cannot Be Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    Refresh();
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
            btn_delete.Enabled = false;
        }
    }
}
