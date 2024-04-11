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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace KEELS_Super_POS.Forms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void LoadSales()
        {
            con.Open();
            cmd = new SqlCommand("SELECT sum (Bill_Total) FROM Bill_Table", con);
            int x = Convert.ToInt32(((SqlCommand)cmd).ExecuteScalar());
            con.Close();

            sales_lb.Text = "Rs. "+x.ToString();   
        }
        private void LoadItemsCount()
        {
            con.Open();
            cmd = new SqlCommand("Select count (Product_ID) from [Product_Table]", con);
            int x = Convert.ToInt32(((SqlCommand)cmd).ExecuteScalar());
            con.Close();
            items_lb.Text = x.ToString()+" items";
        }

        private void OutofStock()
        {
            con.Open();
            cmd = new SqlCommand("Select count (Product_ID) from [Product_Table] where Prodcut_Quantity = '0'", con);
            int x = Convert.ToInt32(((SqlCommand)cmd).ExecuteScalar());
            con.Close();
            stock_lb.Text = x.ToString() + " items";
        }
        private void Members()
        {
            con.Open();
            cmd = new SqlCommand("Select count (Member_ID) from [Member_Tbl]", con);
            int x = Convert.ToInt32(((SqlCommand)cmd).ExecuteScalar());
            con.Close();
            label6.Text = x.ToString();
        }

        private void FillChart()
        {
            con.Open();
            SqlDataAdapter adapter= new SqlDataAdapter("Select Bill_Total,Bill_Date from Bill_Table", con);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            chart1.DataSource = ds;
            chart1.Series["Sales"].XValueMember = "Bill_Date";
            chart1.Series["Sales"].YValueMembers = "Bill_Total";
            chart1.Titles.Add("Sales To Date");
            con.Close();

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            LoadSales();
            LoadItemsCount();
            OutofStock();
            FillChart();
            Members();
            panel2.Visible = false;
        }

       private void HideSubMenu()
        {
            if (panel2.Visible == true)
                panel2.Visible = false;
        }
        private void showSubMenu(Panel SubMenu)
        {
            if (SubMenu.Visible == false)
            {
                HideSubMenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

        private void btn_catogories_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            report1 x = new  report1();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            report2 x = new report2();
            x.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            report3 x = new report3();
            x.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            report4 x = new report4();
            x.Show();
        }
    }
}
