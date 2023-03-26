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
namespace Music_media
{
    public partial class Home : Form
    {
        //Menu choice
        int menuCheck = 1;
        Pen redPen = new Pen(Color.FromArgb(208, 63, 10), 3);
        Pen greyPen = new Pen(Color.FromArgb(243, 243, 243), 3);
        Graphics grh;

        public Home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            grh = homeMenu.CreateGraphics();
            grh.DrawLine(redPen, 4, 28, 4, 8);

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

        
            //this.homeMenu.Click += new System.EventHandler(this.homeMenu_Click);
            //this.homeMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintLine);
        //Lựa chọn menu 
        private void homeMenu_Click(object sender, MouseEventArgs e)
        {
            PanelRounded pn = (PanelRounded)sender;

            //grh.Clear(Color.FromArgb(243, 243, 243));

            


            if (pn.Name == "homeMenu" || pn.Name == "homeTxt" || pn.Name == "homeIco")
            {

                if (menuCheck != 1)
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    menuChecked(menuCheck);
                }
                    

                menuCheck = 1;
                homeMenu.BackColor = Color.FromArgb(230, 230, 230);
                //Graphics pgGra = pn.CreateGraphics();
                //pgGra.DrawLine(redPen, 4, 28, 4, 8);
            }
                
            else if (pn.Name == "musicMenu" || pn.Name == "musicTxt" || pn.Name == "musicIco")
            {
                if (menuCheck != 2)
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    menuChecked(menuCheck);
                }
                menuCheck = 2;
                musicMenu.BackColor = Color.FromArgb(230, 230, 230);
            }
            else if (pn.Name == "queueTxt" || pn.Name == "queueIco" || pn.Name == "queueMenu")
            {
                if (menuCheck != 3)
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    menuChecked(menuCheck);
                }
                menuCheck = 3;
                queueMenu.BackColor = Color.FromArgb(230, 230, 230);
            }
            else if (pn.Name == "playlistsMenu" || pn.Name == "playlistsTxt" || pn.Name == "playlistIco")
            {
                if (menuCheck != 4)
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    menuChecked(menuCheck);
                }
                menuCheck = 4;
                playlistsMenu.BackColor = Color.FromArgb(230, 230, 230);
            }
            else if (pn.Name == "settingMenu" || pn.Name == "settingTxt" || pn.Name == "settingIco")
            {
                if (menuCheck != 5)
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    menuChecked(menuCheck);
                }
                menuCheck = 5;
                settingMenu.BackColor = Color.FromArgb(230, 230, 230);
            }
            grh = pn.CreateGraphics ();
            grh.DrawLine(redPen, 4, 28, 4, 8);
            label1.Text = menuCheck.ToString();
            
        }

        private void menuChecked(int menuCheck)
        {
            if (menuCheck == 1)
            {
                homeMenu.BackColor = Color.FromArgb(243, 243, 243);
            }
            else if (menuCheck == 2)
            {
                musicMenu.BackColor = Color.FromArgb(243, 243, 243);
            }
            else if (menuCheck == 3)
            {
                queueMenu.BackColor = Color.FromArgb(243, 243, 243);
            }
            else if (menuCheck == 4)
            {
                playlistsMenu.BackColor = Color.FromArgb(243, 243, 243);
            }
            else if (menuCheck == 5)
            {
                settingMenu.BackColor = Color.FromArgb(243, 243, 243);
            }
        }

        private void PaintLine(object sender, PaintEventArgs e)
        {
            Pen reddPen = new Pen(Color.FromArgb(208, 63, 10), 3);
            e.Graphics.DrawLine(reddPen, 4, 28, 4, 8);
            //label1.Text = label1.Text + e.ToString();
        }

        private void musicMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
