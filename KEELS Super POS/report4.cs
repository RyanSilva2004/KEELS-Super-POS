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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KEELS_Super_POS
{
    public partial class report4 : Form
    {
        public report4()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlCommand cmd;

        private void report4_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
            cmd = new SqlCommand("Select * From Member_Tbl", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            txt_mid.Enabled = false;
            txt_name.Enabled = false;
            txt_points1.Enabled = false;
            txt_points2.Enabled = false;
            txt_tpo.Enabled = false;
            

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rs = new ReportDataSource("DataSet4", dt);
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report4.rdlc";
            reportViewer1.LocalReport.DataSources.Add(rs);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txt_mid.Enabled = true;
            txt_name.Enabled = false;
            txt_points1.Enabled = false;
            txt_points2.Enabled = false;
            txt_tpo.Enabled = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txt_mid.Enabled = false;
            txt_name.Enabled = false;
            txt_points1.Enabled = false;
            txt_points2.Enabled = false;
            txt_tpo.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            txt_mid.Enabled = false;
            txt_name.Enabled = true;
            txt_points1.Enabled = false;
            txt_points2.Enabled = false;
            txt_tpo.Enabled = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            txt_mid.Enabled = false;
            txt_name.Enabled = false;
            txt_points1.Enabled = true;
            txt_points2.Enabled = true;
            txt_tpo.Enabled = false;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_mid.Clear();
            txt_name.Clear();
            txt_points1.Clear();
            txt_points2.Clear();
            txt_tpo.Clear();
        }

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Member_Tbl\r\n Where Member_ID = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_mid.Text);
                //cmd.Parameters.AddWithValue("b", dateTimePicker1.Value);
                //cmd.Parameters.AddWithValue("c", comboBox1.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet4", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report4.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }

            else if (radioButton2.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Member_Tbl\r\n Where TPO = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_tpo.Text);
                //cmd.Parameters.AddWithValue("b", dateTimePicker1.Value);
                //cmd.Parameters.AddWithValue("c", comboBox1.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet4", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report4.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton2.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Member_Tbl\r\n Where TPO = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_tpo.Text);
                //cmd.Parameters.AddWithValue("b", dateTimePicker1.Value);
                //cmd.Parameters.AddWithValue("c", comboBox1.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet4", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report4.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton3.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Member_Tbl\r\n Where Member_Name = @a ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_name.Text);
                //cmd.Parameters.AddWithValue("b", dateTimePicker1.Value);
                //cmd.Parameters.AddWithValue("c", comboBox1.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet4", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report4.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
            else if (radioButton4.Checked == true)
            {
                con = new SqlConnection("Data Source=DESKTOP-SMVQK5B\\SQLEXPRESS;Initial Catalog=Keels_SuperMarket_Database;Integrated Security=True");
                cmd = new SqlCommand("SELECT * FROM dbo.Member_Tbl\r\n Where Member_Points >= @a and Member_Points <= @b ", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("a", txt_points1.Text);
                cmd.Parameters.AddWithValue("b", txt_points2.Text);
                //cmd.Parameters.AddWithValue("b", dateTimePicker1.Value);
                //cmd.Parameters.AddWithValue("c", comboBox1.Text);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource rs = new ReportDataSource("DataSet4", dt);
                reportViewer1.LocalReport.ReportPath = "C:\\Users\\ryans\\Desktop\\Final Project - CSE\\KEELS Super POS\\KEELS Super POS\\Report4.rdlc";
                reportViewer1.LocalReport.DataSources.Add(rs);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
