using Microsoft.Reporting.WinForms;
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

namespace KEELS_Super_POS
{
    public partial class report2 : Form
    {
        public report2()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        private void report2_Load(object sender, EventArgs e)
        {
            
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            cmd = new SqlCommand("Select * From Product_Table", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rs = new ReportDataSource("DataSet2", dt);
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report2.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            comboBox1.Items.Clear();
            LoadComboBox();

            txt_pid.Enabled = false;
            txt_pname.Enabled = false;
            txt_price.Enabled = false;
            txt_qty.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txt_pid.Enabled = true;
            txt_pname.Enabled = false;
            txt_price.Enabled = false;
            txt_qty.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txt_pid.Enabled = false;
            txt_pname.Enabled = false;
            txt_price.Enabled = false;
            txt_qty.Enabled = false;
            comboBox1.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            txt_pid.Enabled = false;
            txt_pname.Enabled = false;
            txt_price.Enabled = false;
            txt_qty.Enabled = true;
            comboBox1.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txt_pid.Enabled = false;
            txt_pname.Enabled = true;
            txt_price.Enabled = false;
            txt_qty.Enabled = false;
            comboBox1.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txt_pid.Enabled = false;
            txt_pname.Enabled = false;
            txt_price.Enabled = true;
            txt_qty.Enabled = false;
            comboBox1.Enabled = false;
        }
        private void LoadComboBox()
        {

            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            cmd = new SqlCommand("Select Category_Name from Category_Tbl", con);
            
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Category_Name"].ToString());
            }
            
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Product_Table\r\n Where Product_ID = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_pid.Text);
                
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report2.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton2.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Product_Table\r\n Where Product_Name Like  '%' + @a  + '%' ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_pname.Text);

                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report2.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton3.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Product_Table\r\n Where Product_Category = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", comboBox1.SelectedItem.ToString());

                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report2.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton5.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Product_Table\r\n Where Prodcut_Quantity = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_qty.Text);

                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report2.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton4.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Product_Table\r\n Where Product_Price = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_price.Text);

                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet2", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report2.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Please Select A Field To Search");
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            cmd = new SqlCommand("Select * From Product_Table", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rs = new ReportDataSource("DataSet2", dt);
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report2.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            comboBox1.Items.Clear();
            LoadComboBox();

            txt_pid.Clear();
            txt_pname.Clear();
            txt_price.Clear();
            txt_qty.Clear();
            comboBox1.SelectedIndex = -1;
        }
    }
}
