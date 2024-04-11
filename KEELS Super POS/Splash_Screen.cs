using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace KEELS_Super_POS
{
    public partial class Splash_Screen : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
      );
        public Splash_Screen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen pen = new Pen(Color.FromArgb(1, 89, 28),1);

            Rectangle area = new Rectangle(0, 0, this.Width-1,this.Height-1);
            LinearGradientBrush lgb = new LinearGradientBrush(area, Color.ForestGreen, Color.FromArgb(0, 121, 63), LinearGradientMode.Vertical);
            graphics.FillRectangle(lgb, area);
            graphics.DrawRectangle(pen, area);
        }

        private void Splash_Screen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(progressBar1.Value < 60)
            {
                progressBar1.Value += 1;
            }
            else
            {
                timer1.Stop();
                Login x = new Login();
                x.Show();
                this.Hide();
            }
        }
    }
}
