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

namespace KEELS_Super_POS.Forms.Product_Items
{
    public partial class DeleteProductItem : Form
    {
        public DeleteProductItem()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void DeleteProductItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'keels_SuperMarket_DatabaseDataSet5.Product_Table' table. You can move, or remove it, as needed.
            
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Teal;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 7, FontStyle.Bold);
            Refresh();
            LoadComboBox();
        }
        private void Refresh()
        {
            this.product_TableTableAdapter.Fill(this.keels_SuperMarket_DatabaseDataSet5.Product_Table);
        }
        private void btn_check_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select Product_ID,Product_Name,Product_Price,Prodcut_Quantity,Product_Category from Product_Table  where Product_ID = @pid", con);
            cmd.Parameters.AddWithValue("pid", txt_productid.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt_productname.Text = reader["Product_Name"].ToString();
                txt_price.Text = reader["Product_Price"].ToString();
                txt_productqunatity.Text = reader["Prodcut_Quantity"].ToString();
                btn_delete.Enabled = true;
                

            }
            else
            {
                MessageBox.Show("Product Data Not Found or Product ID Is Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void LoadComboBox()
        {
            cmb_productcategory.Items.Clear();
            con.Open();
            cmd = new SqlCommand("Select Category_Name from Category_Tbl", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmb_productcategory.Items.Add(dr["Category_Name"].ToString());
            }
            con.Close();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_productid.Clear();
            txt_productname.Clear();
            txt_productqunatity.Clear();
            txt_price.Clear();
            cmb_productcategory.Items.Clear();
            LoadComboBox();
            Refresh();
           
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Delete from Product_Table where Product_ID= '" + txt_productid.Text + "'", con);
                int x = cmd.ExecuteNonQuery();
                //cmd.Parameters.AddWithValue("cid", txt_cid.Text);
                if (x == 1)
                {
                    MessageBox.Show("Product Item Deleted Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Product Item Cannot Be Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

       
    }
}
