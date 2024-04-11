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

namespace KEELS_Super_POS.Forms
{
    public partial class AddProductCategory : Form
    {
        public AddProductCategory()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void Refresh()
        {
            this.category_TblTableAdapter.Fill(this.keels_SuperMarket_DatabaseDataSet.Category_Tbl);

        }
        private void AddProductCategory_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'keels_SuperMarket_DatabaseDataSet.Category_Tbl' table. You can move, or remove it, as needed.
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            AutoCatIDGen();
            Refresh();
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 7, FontStyle.Bold);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
           
            txt_cname.Clear();
            txt_cdes.Clear();
            
        }
        int ax;
        private void AutoCatIDGen()
        {
            con.Open();
            cmd = new SqlCommand("Select count (Category_ID) from [Category_Tbl]",con);
             ax =Convert.ToInt32(((SqlCommand)cmd).ExecuteScalar());
            con.Close();
            ax++;
            txt_cid.Text = "CAT-" + ax.ToString();
            FixID();


        }
        private void FixID()
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Category_Tbl where Category_ID = '" + txt_cid.Text + "' ", con))
            {
                con.Open();

                int userCount = (int)sqlCommand.ExecuteScalar();
                con.Close();
                if (userCount > 0)
                {
                    ax = ax + 1;
                    txt_cid.Text = "CAT-" + ax.ToString();
                }
                else
                {

                }
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
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
                    cmd = new SqlCommand("Insert Into Category_Tbl values ('" + txt_cid.Text + "','" + txt_cname.Text + "','" + txt_cdes.Text + "')", con);
                    int x = cmd.ExecuteNonQuery();
                    if (x == 1)
                    {
                        MessageBox.Show("New Category Added Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New Category Cannot Be Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
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


            Refresh();
            AutoCatIDGen();

        }
    }
}
