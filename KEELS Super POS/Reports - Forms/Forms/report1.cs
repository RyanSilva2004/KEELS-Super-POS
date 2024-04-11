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
using Microsoft.Reporting.WinForms;
using KEELS_Super_POS.Forms.Cashier;

namespace KEELS_Super_POS
{
    public partial class report1 : Form
    {
        public report1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void report1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.Bill_Table' table. You can move, or remove it, as needed.
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            cmd = new SqlCommand("Select * From Bill_Table", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rs = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.RefreshReport();
            txt_bid.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox1.Enabled = false;
            txt_bamount1.Enabled = false;
            txt_bamount2.Enabled = false;
            loadCashierNames();

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_bid.Clear();
            txt_bamount1.Clear();
            txt_bamount2.Clear();
            comboBox1.SelectedIndex = -1;

            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            cmd = new SqlCommand("Select * From Bill_Table", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rs = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.RefreshReport();

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT Bill_ID, Bill_Date, Seller_Name, Customer_Type, Member_ID, Bill_Total FROM dbo.Bill_Table\r\n Where Bill_ID = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_bid.Text);
                //cmd.Parameters.AddWithValue("b", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("c", comboBox1.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton2.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT Bill_ID, Bill_Date, Seller_Name, Customer_Type, Member_ID, Bill_Total FROM dbo.Bill_Table\r\n Where Bill_Date Between @a and @b", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("a", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("b", dateTimePicker2.Value);

                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton3.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT Bill_ID, Bill_Date, Seller_Name, Customer_Type, Member_ID, Bill_Total FROM dbo.Bill_Table\r\n Where Seller_Name = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("a", comboBox1.SelectedItem.ToString());
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if(radioButton4.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT Bill_ID, Bill_Date, Seller_Name, Customer_Type, Member_ID, Bill_Total FROM dbo.Bill_Table\r\n Where Bill_Total >= @a and Bill_Total <= @b", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("a", txt_bamount1.Text);
                cmd.Parameters.AddWithValue("b", txt_bamount2.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }   

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txt_bid.Enabled = true;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox1.Enabled = false;
            txt_bamount1.Enabled = false;
            txt_bamount2.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txt_bid.Enabled = false;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            comboBox1.Enabled = false;
            txt_bamount1.Enabled = false;
            txt_bamount2.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txt_bid.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox1.Enabled = true;
            txt_bamount1.Enabled = false;
            txt_bamount2.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txt_bid.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            comboBox1.Enabled = false;
            txt_bamount1.Enabled = true;
            txt_bamount2.Enabled = true;
        }

        private void loadCashierNames()
        {
            comboBox1.Items.Clear();
            con.Open();
            cmd = new SqlCommand("Select Full_Name from Employee_Table where Role ='Cashier'", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["Full_Name"].ToString());
            }
            con.Close();
        }
    }
}
