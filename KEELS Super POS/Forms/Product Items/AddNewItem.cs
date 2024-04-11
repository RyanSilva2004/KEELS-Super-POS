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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace KEELS_Super_POS.Forms.Product_Items
{
    public partial class AddNewItem : Form
    {
        public AddNewItem()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        private void AddNewItem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'keels_SuperMarket_DatabaseDataSet3.Product_Table' table. You can move, or remove it, as needed.
            this.product_TableTableAdapter.Fill(this.keels_SuperMarket_DatabaseDataSet3.Product_Table);
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.YellowGreen;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;


            dataGridView1.DefaultCellStyle.Font = new Font("Consolas", 7, FontStyle.Bold);

            AutoProductIDGen();
            LoadComboBox();
        }
        private void Refresh()
        {
            this.product_TableTableAdapter.Fill(this.keels_SuperMarket_DatabaseDataSet3.Product_Table);
            
        }
        int ax;
        private void AutoProductIDGen()
        {
            con.Open();
            cmd = new SqlCommand("Select count (Product_ID) from [Product_Table]", con);
            ax = Convert.ToInt32(((SqlCommand)cmd).ExecuteScalar());
            con.Close();
            ax++;
            txt_productid.Text = "PID-" + ax.ToString();
            FixID();
        }
        private void LoadComboBox()
        {
            cmb_productcategory.Items.Clear();
            con.Open();
            cmd = new SqlCommand("Select Category_Name from Category_Tbl", con);
            cmd.ExecuteNonQuery();
            con.Close();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmb_productcategory.Items.Add(dr["Category_Name"].ToString());
            }
            
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_productname.Text.Length == 0)
            {
                MessageBox.Show("Product Name Cannot Be Blanck", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_price.Text.Length == 0 || txt_price.Text.Any(Char.IsLetter))
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
                con.Open();
                cmd = new SqlCommand("Select Prodcut_Quantity from Product_Table where Product_Name = '" + txt_productid + "'", con);
                con.Close();
                try
                {
                    con.Open();
                    cmd = new SqlCommand("Insert Into Product_Table values('" + txt_productid.Text + "','" + txt_productname.Text + "','" + txt_price.Text + "','" + txt_productqunatity.Text + "',@a)", con);
                    cmd.Parameters.AddWithValue("@a", cmb_productcategory.SelectedItem);
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i == 1)
                    {
                        Refresh();
                        MessageBox.Show("New Product Added Succesfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New Product Cannot Be Added", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    AutoProductIDGen();

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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_productid.Clear();
            txt_productname.Clear();
            txt_productqunatity.Clear();
            txt_price.Clear();
            cmb_productcategory.SelectedIndex = -1;
            AutoProductIDGen();

        }
        private void FixID()
        {
            using (SqlCommand sqlCommand = new SqlCommand("SELECT COUNT(*) from Product_Table where Product_ID = '" + txt_productid.Text + "' ", con))
            {
                con.Open();

                int userCount = (int)sqlCommand.ExecuteScalar();
                con.Close();
                if (userCount > 0)
                {
                    ax = ax + 1;
                    txt_productid.Text = "PID-" + ax.ToString();
                }
                else
                {

                }
            }
        }
    }
}
