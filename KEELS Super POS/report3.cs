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
using System.Data.SqlClient;

namespace KEELS_Super_POS
{
    public partial class report3 : Form
    {
        public report3()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;
        
        private void report3_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            cmd = new SqlCommand("Select * From Employee_Table", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rs = new ReportDataSource("DataSet3", dt);
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report3.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rs);
            
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            txt_name.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            comboBox1.SelectedIndex = -1;
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            cmd = new SqlCommand("Select * From Employee_Table", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rs = new ReportDataSource("DataSet3", dt);
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report3.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rs);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            txt_name.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Length == 0)
            {
                MessageBox.Show("Full Name Cannot Be Blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select A Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Employee_Table\r\n Where Full_Name = @a and Role = @b", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_name.Text);
                cmd.Parameters.AddWithValue("b", comboBox1.SelectedItem.ToString());

                DataTable dt = new DataTable();
                adapter.Fill(dt);


                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet3", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report3.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
