using System;
using System.Windows.Forms;
using System.Drawing;
using Music_media;
using DevExpress.XtraTab;
using System.Collections.Generic;

namespace Music_media.Menu_Choice
{
    class MenuChoice
    {

        public static void backcolor(Control ctr, Color color)
        {
            ctr.BackColor = color;
        }
        public List<XtraTabPage> listPage(List<XtraTabPage> listPage)
        {
            return listPage;
        }
        public static void DrawLineRed(object sender, MouseEventArgs e)
        {
            Control pn = (Control)sender;
            Graphics grh = pn.CreateGraphics();
            Pen redPen = new Pen(Color.FromArgb(208, 63, 10), 3);
            grh.DrawLine(redPen, 4, 28, 4, 8);
        }
        public static void menu(object sender, MouseEventArgs e, ref Control choiced, Form frm, List<XtraTabPage> listPage)
        {
            Graphics grh;
            Pen greyPen = new Pen(Color.FromArgb(243, 243, 243), 3);
            Control pn = (Control)sender;
            grh = pn.CreateGraphics();
            if (pn.Name == "homeMenu" || pn.Name == "homeTxt" || pn.Name == "homeIco")
            {
                if (choiced.Name != "homeMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    backcolor(choiced, Color.FromArgb(243, 243, 243));
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                HomeMenu.homeChoice(frm, listPage, 0);
                
            }

            else if (pn.Name == "musicMenu" || pn.Name == "musicTxt" || pn.Name == "musicIco")
            {
                if (choiced.Name != "musicMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    backcolor(choiced, Color.FromArgb(243, 243, 243));
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                HomeMenu.homeChoice(frm, listPage, 1);
            }
            else if (pn.Name == "queueTxt" || pn.Name == "queueIco" || pn.Name == "queueMenu")
            {
                if (choiced.Name != "queueMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    backcolor(choiced, Color.FromArgb(243, 243, 243));
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                HomeMenu.homeChoice(frm, listPage, 2);
            }
            else if (pn.Name == "playlistsMenu" || pn.Name == "playlistsTxt" || pn.Name == "playlistIco")
            {
                if (choiced.Name != "playlistsMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    backcolor(choiced, Color.FromArgb(243, 243, 243));
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                HomeMenu.homeChoice(frm, listPage, 3);
            }
            else if (pn.Name == "settingMenu" || pn.Name == "settingTxt" || pn.Name == "settingIco")
            {
                if (choiced.Name != "settingMenu")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    backcolor(choiced, Color.FromArgb(243, 243, 243));
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                HomeMenu.homeChoice(frm, listPage, 4);
            }
            else if (pn.Name == "lbAccount" || pn.Name == "panelAccount")
            {
                if (choiced.Name != "panelAccount")
                {
                    grh.DrawLine(greyPen, 4, 28, 4, 8);
                    backcolor(choiced, Color.FromArgb(243, 243, 243));
                    pn.BackColor = Color.FromArgb(230, 230, 230);
                }
                HomeMenu.homeChoice(frm, listPage, 6);
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