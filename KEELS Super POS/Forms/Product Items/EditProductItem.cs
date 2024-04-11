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
    public partial class EditProductItem : Form
    {
        public EditProductItem()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void btn_check_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select Product_ID,Product_Name,Product_Price,Prodcut_Quantity,Product_Category from Product_Table  where Product_ID = @pid", con);
            cmd.Parameters.AddWithValue("pid",txt_productid.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txt_productname.Text = reader["Product_Name"].ToString();
               txt_price.Text = reader["Product_Price"].ToString();
                txt_productqunatity.Text = reader["Prodcut_Quantity"].ToString() ; 
               txt_productname.Enabled = true;
                txt_price.Enabled = true;
                txt_productqunatity.Enabled = true;
                cmb_productcategory.Enabled = true;
                btn_add.Enabled =true;

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
        private void EditProductItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'keels_SuperMarket_DatabaseDataSet4.Product_Table' table. You can move, or remove it, as needed.
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.ForestGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 7, FontStyle.Bold);
            Refresh();
            LoadComboBox();
        }

        private void Refresh()
        {
            this.product_TableTableAdapter.Fill(this.keels_SuperMarket_DatabaseDataSet4.Product_Table);
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_productid.Clear();
            txt_productname.Clear();
            txt_productqunatity.Clear();
            txt_price.Clear();
            cmb_productcategory.SelectedIndex = -1;
            LoadComboBox();
            Refresh();
            txt_productname.Enabled = false;
            txt_price.Enabled = false;
            txt_productqunatity.Enabled = false;
            cmb_productcategory.Enabled = false;
            btn_add.Enabled = false;

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_price.Text.Length == 0 || txt_price.Text.Any(Char.IsLetter))
            {
                MessageBox.Show("Product Price Cannot Be Blanck Or Cannot Contain Letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_productqunatity.Text.Length == 0 || txt_productqunatity.Text.Any(Char.IsLetter))
            {
                MessageBox.Show("Product Quantity Cannot Be Blanck Or Cannot Contain Letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmb_productcategory.Text.Length == 0)
            {
                MessageBox.Show("Please Select An Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    con.Open();
                    cmd = new SqlCommand("Update Product_Table set Product_Name='"+txt_productname.Text+ "',Product_Price ='"+txt_price.Text+ "',Prodcut_Quantity ='"+txt_productqunatity.Text+ "',Product_Category =@a where Product_ID ='"+txt_productid.Text+"'", con);
                    cmd.Parameters.AddWithValue("a", cmb_productcategory.SelectedItem);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i == 1)
                    {
                        MessageBox.Show("Product Update Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Product Cannot Be Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
}
