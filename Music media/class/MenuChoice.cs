using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Music_media.Menu_Choice
{
    class MenuChoice
    {

        private static void menuChecked(Control ctr)
        {
                ctr.BackColor = Color.FromArgb(243, 243, 243);
        }
        public static void DrawLineRed(object sender)
        {
            Control pn = (Control)sender;
            Graphics grh = pn.CreateGraphics();
            Pen redPen = new Pen(Color.FromArgb(208, 63, 10), 3);
            grh.DrawLine(redPen, 4, 28, 4, 8);
        }
        public static void menu(object sender, MouseEventArgs e, ref Control  choiced)
        {
            Graphics grh;
            Pen greyPen = new Pen(Color.FromArgb(243, 243, 243), 3);
            Control pn = (Control)sender;
            grh = pn.CreateGraphics();
            if (pn.Name == "homeMenu" || pn.Name == "homeTxt" || pn.Name == "homeIco")
            {
                if (choiced.Name!="homeMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    //menuChecked(menuCheck);
                    menuChecked(choiced);
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                //menuCheck = 1;
            }

            else if (pn.Name == "musicMenu" || pn.Name == "musicTxt" || pn.Name == "musicIco")
            {
                if (choiced.Name != "musicMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    //menuChecked(menuCheck);
                    menuChecked(choiced);
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                //menuCheck = 2;
            }
            else if (pn.Name == "queueTxt" || pn.Name == "queueIco" || pn.Name == "queueMenu")
            {
                if (choiced.Name != "queueMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    //menuChecked(menuCheck);
                    menuChecked(choiced);
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                //menuCheck = 3;
            }
            else if (pn.Name == "playlistsMenu" || pn.Name == "playlistsTxt" || pn.Name == "playlistIco")
            {
                if (choiced.Name != "playlistsMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    //menuChecked(menuCheck);
                    menuChecked(choiced);
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                //menuCheck = 4;
            }
            else if (pn.Name == "settingMenu" || pn.Name == "settingTxt" || pn.Name == "settingIco")
            {
                if (choiced.Name != "settingMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    //menuChecked(menuCheck);
                    menuChecked(choiced);
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                //menuCheck = 5;
            }
            choiced = pn;
        }
        public static void menuEvent(object sender, EventArgs e, ref Control choiced, Color color)
        {
            Control pn = (Control)sender;
            if (pn.Name == "homeMenu" || pn.Name == "homeTxt" || pn.Name == "homeIco")
            {
                if (choiced.Name != "homeMenu")
                {
                    pn.BackColor = color;
                }
            }

            else if (pn.Name == "musicMenu" || pn.Name == "musicTxt" || pn.Name == "musicIco")
            {
                if (choiced.Name != "musicMenu")
                {
                    pn.BackColor = color;
                }
            }
            else if (pn.Name == "queueTxt" || pn.Name == "queueIco" || pn.Name == "queueMenu")
            {
                if (choiced.Name != "queueMenu")
                {
                    pn.BackColor = color;
                }
            }
            else if (pn.Name == "playlistsMenu" || pn.Name == "playlistsTxt" || pn.Name == "playlistIco")
            {
                if (choiced.Name != "playlistsMenu")
                {
                    pn.BackColor = color;
                }
            }
            else if (pn.Name == "settingMenu" || pn.Name == "settingTxt" || pn.Name == "settingIco")
            {
                if (choiced.Name != "settingMenu")
                {
                    pn.BackColor = color;
                }
            }
        }
        
    }
}