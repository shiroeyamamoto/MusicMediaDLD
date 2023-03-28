using DevExpress.Utils.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection.Emit;
using Music_media.customControl;
using Music_media.Menu_Choice;
using DevExpress.XtraBars.Controls;
using DevExpress.Xpo.DB;

namespace Music_media
{
    public partial class Home : Form
    {
        //Menu choice
        Control choiced = new Control(); //Save before of choice 

        public Home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exit_MouseHover(object sender, EventArgs e)
        {
            exit.BackColor = Color.FromArgb(196, 43, 28);
            exit.ForeColor = Color.FromArgb(248, 228, 227);
        }


        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackColor = Color.FromArgb(249, 249, 249);
            exit.ForeColor = Color.FromArgb(0, 0, 0);
            minimum.BackColor = Color.FromArgb(249, 249, 249);
            fullSreen.BackColor = Color.FromArgb(249, 249, 249);
        }

        private void minimum_MouseHover(object sender, EventArgs e)
        {
            minimum.BackColor = Color.FromArgb(233, 233, 233);
        }

        private void minimum_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
        }

        private void fullSreen_MouseEnter(object sender, EventArgs e)
        {
            fullSreen.BackColor = Color.FromArgb(233, 233, 233);
        }

        //border rounded forms: https://www.dideo.ir/v/yt/LE3y5a0G4JA/windows-form-rounded-corners-in-c%23-%7C%7C-form-border
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
        
        //Lựa chọn menu 

        private void menuChoice(object sender, MouseEventArgs e)
        {
            MenuChoice.menu(sender, e, ref choiced);
        }
        private void redLine(object sender, EventArgs e)
        {
            MenuChoice.DrawLineRed(sender);
        }
        private void menuHover(object sender, EventArgs e)
        {
            MenuChoice.menuEvent(sender, e, ref choiced, Color.FromArgb(237,237,237));
        }
        private void menuLeave(object sender, EventArgs e)
        {
            MenuChoice.menuEvent(sender, e, ref choiced, Color.FromArgb(243,243,243));
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void searchText_Enter(object sender, EventArgs e)
        {
            customTextbox ctr = (customTextbox)sender;
            ctr.BorderColor = Color.Red;
            ctr.Invalidate();
            ctr.Refresh();
        }

        /*  private void PaintLine(object sender, PaintEventArgs e)
          {
              Pen reddPen = new Pen(Color.FromArgb(208, 63, 10), 3);
              e.Graphics.DrawLine(reddPen, 4, 28, 4, 8);
              //label1.Text = label1.Text + e.ToString();
          }*/

    }
}
