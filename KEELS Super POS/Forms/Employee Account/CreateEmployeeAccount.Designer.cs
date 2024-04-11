namespace KEELS_Super_POS.Forms.Employee_Account
{
    partial class CreateEmployeeAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmd_role = new System.Windows.Forms.ComboBox();
            this.txt_uname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.txt_password2 = new System.Windows.Forms.TextBox();
            this.txt_fname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_upload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pfp_pbox = new System.Windows.Forms.PictureBox();
            this.keels_SuperMarket_DatabaseDataSet6 = new KEELS_Super_POS.Keels_SuperMarket_DatabaseDataSet6();
            this.employeeTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.employee_TableTableAdapter = new KEELS_Super_POS.Keels_SuperMarket_DatabaseDataSet6TableAdapters.Employee_TableTableAdapter();
            this.btn_view = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pfp_pbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keels_SuperMarket_DatabaseDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(195)))), ((int)(((byte)(18)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(930, 35);
            this.panel1.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Pusia-Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add New Employee Account";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(250, 126);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(200, 22);
            this.txt_password.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Inter Semi Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 18);
            this.label7.TabIndex = 49;
            this.label7.Text = "Password";
            // 
            // cmd_role
            // 
            this.cmd_role.FormattingEnabled = true;
            this.cmd_role.Items.AddRange(new object[] {
            "Administrator",
            "Cashier"});
            this.cmd_role.Location = new System.Drawing.Point(250, 186);
            this.cmd_role.Name = "cmd_role";
            this.cmd_role.Size = new System.Drawing.Size(200, 24);
            this.cmd_role.TabIndex = 48;
            // 
            // txt_uname
            // 
            this.txt_uname.Location = new System.Drawing.Point(250, 96);
            this.txt_uname.Name = "txt_uname";
            this.txt_uname.Size = new System.Drawing.Size(200, 22);
            this.txt_uname.TabIndex = 47;
            this.txt_uname.TextChanged += new System.EventHandler(this.txt_uname_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Inter Semi Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 46;
            this.label5.Text = "Role";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Inter Semi Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 45;
            this.label6.Text = "User Name";
            // 
            // btn_clear
            // 
            this.btn_clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clear.Font = new System.Drawing.Font("Pusia-Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(140, 260);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(96, 37);
            this.btn_clear.TabIndex = 44;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_add
            // 
            this.btn_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Pusia-Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(40, 260);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(96, 37);
            this.btn_add.TabIndex = 43;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_password2
            // 
            this.txt_password2.Location = new System.Drawing.Point(250, 156);
            this.txt_password2.Name = "txt_password2";
            this.txt_password2.Size = new System.Drawing.Size(200, 22);
            this.txt_password2.TabIndex = 42;
            // 
            // txt_fname
            // 
            this.txt_fname.Location = new System.Drawing.Point(250, 66);
            this.txt_fname.Name = "txt_fname";
            this.txt_fname.Size = new System.Drawing.Size(282, 22);
            this.txt_fname.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter Semi Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 18);
            this.label3.TabIndex = 40;
            this.label3.Text = "Re-Type Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter Semi Bold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 39;
            this.label2.Text = "Full Name";
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(690, 270);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_upload.TabIndex = 52;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pfp_pbox
            // 
            this.pfp_pbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pfp_pbox.Location = new System.Drawing.Point(566, 66);
            this.pfp_pbox.Name = "pfp_pbox";
            this.pfp_pbox.Size = new System.Drawing.Size(200, 200);
            this.pfp_pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pfp_pbox.TabIndex = 51;
            this.pfp_pbox.TabStop = false;
            // 
            // keels_SuperMarket_DatabaseDataSet6
            // 
            this.keels_SuperMarket_DatabaseDataSet6.DataSetName = "Keels_SuperMarket_DatabaseDataSet6";
            this.keels_SuperMarket_DatabaseDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // employeeTableBindingSource
            // 
            this.employeeTableBindingSource.DataMember = "Employee_Table";
            this.employeeTableBindingSource.DataSource = this.keels_SuperMarket_DatabaseDataSet6;
            // 
            // employee_TableTableAdapter
            // 
            this.employee_TableTableAdapter.ClearBeforeFill = true;
            // 
            // btn_view
            // 
            this.btn_view.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_view.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn_view.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_view.Font = new System.Drawing.Font("Pusia-Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_view.Location = new System.Drawing.Point(240, 260);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(96, 37);
            this.btn_view.TabIndex = 53;
            this.btn_view.Text = "View DB";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Visible = false;
            // 
            // CreateEmployeeAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 600);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.pfp_pbox);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmd_role);
            this.Controls.Add(this.txt_uname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txt_password2);
            this.Controls.Add(this.txt_fname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateEmployeeAccount";
            this.Text = "CreateEmployeeAccount";
            this.Load += new System.EventHandler(this.CreateEmployeeAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pfp_pbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keels_SuperMarket_DatabaseDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeTableBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmd_role;
        private System.Windows.Forms.TextBox txt_uname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txt_password2;
        private System.Windows.Forms.TextBox txt_fname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pfp_pbox;
        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Keels_SuperMarket_DatabaseDataSet6 keels_SuperMarket_DatabaseDataSet6;
        private System.Windows.Forms.BindingSource employeeTableBindingSource;
        private Keels_SuperMarket_DatabaseDataSet6TableAdapters.Employee_TableTableAdapter employee_TableTableAdapter;
        private System.Windows.Forms.Button btn_view;
    }
}