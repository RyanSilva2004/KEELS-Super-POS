using KEELS_Super_POS.Forms;
using KEELS_Super_POS.Forms.Employee_Account;
using KEELS_Super_POS.Forms.Nexus;
using KEELS_Super_POS.Forms.Product_Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KEELS_Super_POS
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            customizeDesign();
        }

        private void customizeDesign()
        {
            SubPanel_Catogories.Visible     = false;
            SubPanel_Employees.Visible      = false;
            SubPanel_Products.Visible      = false;
            SubPanel_NexusMembers.Visible   = false;
        }

        private void hideSubMenu()
        {
            if (SubPanel_Catogories.Visible == true)
                SubPanel_Catogories.Visible = false;

            if (SubPanel_Employees.Visible == true)
                SubPanel_Employees.Visible = false;

            if (SubPanel_NexusMembers.Visible == true)
                SubPanel_NexusMembers.Visible = false;

            if (SubPanel_Products.Visible == true)
                SubPanel_Products.Visible = false;
        }

        private void showSubMenu(Panel SubMenu)
        {
            if(SubMenu.Visible == false)
            {
                hideSubMenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }
        }

       
        private void openChildForm(object Form)
        {
           if(this.Panel_ChildForm.Controls.Count > 0)
                this.Panel_ChildForm.Controls.RemoveAt(0);

            Form x = Form as Form;
            x.TopLevel = false;
            x.Dock = DockStyle.Fill;    
            this.Panel_ChildForm.Controls.Add(x);
            this.Panel_ChildForm.Tag = x;
            x.Show();

        }

        private void btn_products_Click(object sender, EventArgs e)
        {
            showSubMenu(SubPanel_Products);
        }

        private void btn_catogories_Click(object sender, EventArgs e)
        {
            showSubMenu(SubPanel_Catogories);
        }

        private void btn_Employees_Click(object sender, EventArgs e)
        {
            showSubMenu(SubPanel_Employees);
        }

        private void btn_nexus_Click(object sender, EventArgs e)
        {
            showSubMenu(SubPanel_NexusMembers);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new AddNewItem());
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard());
        }

        private void Home_Load(object sender, EventArgs e)
        {
            openChildForm(new Dashboard());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new EditProductItem());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChildForm(new DeleteProductItem());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            openChildForm(new AddProductCategory());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new EditProductCategory());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openChildForm(new DeleteProductCategory_cs());
        }

        private void btn_createemployee_Click(object sender, EventArgs e)
        {
            openChildForm(new CreateEmployeeAccount());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            openChildForm(new UpdateAccount());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new DeleteAccount());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            openChildForm(new AddNewMember());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            openChildForm(new DeleteMember());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new EditMember());
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Log Out", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login x = new Login();
                x.Show();
                this.Hide();
            }
        }
    }
}
