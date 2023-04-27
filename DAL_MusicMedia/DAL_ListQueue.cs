using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace DAL_MusicMedia
{
    public class DAL_ListQueue
    {
        private static string checkSecond(int x)
        {
            if (x < 10 && x >= 0)
                return "0";
            return "";
        }
        public static void addListItem(FlowLayoutPanel floatLayout)
        {
            ///////////////
            using(var db= new KhangDuong())
            {
                var listTrack = db.Tracks.Where(x => x.TrackID > 1).ToList();
                List<Track> track = new List<Track>();
                track = listTrack;
                int temp = 0;
                foreach (var item in track)
                {

                    string path = item.Track_path;
                    TagLib.File tagFile = TagLib.File.Create(path);
                    string artist = tagFile.Tag.Artists[0];
                    string album = tagFile.Tag.Album;
                    DAL_ListQueue create = new DAL_ListQueue();
                    string secend = "";
                    secend=checkSecond(tagFile.Properties.Duration.Seconds);
                    create.createItem(floatLayout, item.TrackName, artist, album, "0"+tagFile.Properties.Duration.Minutes + ":"+secend + tagFile.Properties.Duration.Seconds);
                }
            }
            
        }

        private void createItem(FlowLayoutPanel floatLayout, string trackName, string artistName, string albumName, string timeTrack)// Hàm tạo các item cho queue
        {
            Panel newTrack = new Panel();
            floatLayout.Controls.Add(newTrack);
            newTrack.Location = new System.Drawing.Point(7, 7);
            newTrack.Margin = new System.Windows.Forms.Padding(7, 7, 0, 0);
            newTrack.Padding = new System.Windows.Forms.Padding(5);
            newTrack.Size = new System.Drawing.Size(678, 48);
            newTrack.TabIndex = 17;
            newTrack.MouseEnter += new System.EventHandler(hoverItem);
            newTrack.MouseLeave += new System.EventHandler(hoverLeaveItem);
            newTrack.MouseHover += new System.EventHandler(hoverItem);



            LabelControl lenght = new LabelControl();
            lenght.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            lenght.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            lenght.Appearance.Options.UseFont = true;
            lenght.Appearance.Options.UseForeColor = true;
            lenght.Enabled = false;
            lenght.Location = new System.Drawing.Point(632, 19);
            lenght.Margin = new System.Windows.Forms.Padding(0);
            lenght.Size = new System.Drawing.Size(32, 13);
            lenght.TabIndex = 18;
            lenght.Text = timeTrack;

            LabelControl album = new LabelControl();
            album.Appearance.BackColor = System.Drawing.Color.Transparent;
            album.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            album.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            album.Appearance.Options.UseBackColor = true;
            album.Appearance.Options.UseFont = true;
            album.Appearance.Options.UseForeColor = true;
            album.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            album.Enabled = false;
            album.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            album.Location = new System.Drawing.Point(0, 0);
            album.Margin = new System.Windows.Forms.Padding(3);
            album.Padding = new Padding(4);
            album.TabIndex = 15;
            album.Text = albumName;
            Panel Panel1 = new Panel();
            Panel1.AutoSize = true;
            Panel1.Controls.Add(album);
            Panel1.Location = new System.Drawing.Point(467, 10);
            Panel1.Margin = new System.Windows.Forms.Padding(3);
            Panel1.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            Panel1.Size = new System.Drawing.Size(48, 29);
            Panel1.TabIndex = 18;
            Panel1.Size = new System.Drawing.Size(0, 13);
            Panel1.MaximumSize = new System.Drawing.Size(153, 29);
            Panel1.MouseEnter += new System.EventHandler(childItem_MouseHover);
            Panel1.MouseLeave += new System.EventHandler(childItem_MouseLeave);
            Panel1.MouseHover += new System.EventHandler(childItem_MouseHover);

            LabelControl name = new LabelControl();
            name.Appearance.BackColor = System.Drawing.Color.Transparent;
            name.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            name.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            name.Appearance.Options.UseBackColor = true;
            name.Appearance.Options.UseFont = true;
            name.Appearance.Options.UseForeColor = true;
            name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            name.Enabled = false;
            name.MaximumSize = new Size(227, 13);
            name.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            name.Location = new System.Drawing.Point(70, 19);
            name.Margin = new System.Windows.Forms.Padding(3);
            name.Size = new System.Drawing.Size(24, 13);
            name.TabIndex = 14;
            name.Text = trackName;
            name.AutoSize = true;

            LabelControl artist = new LabelControl();
            artist.Appearance.BackColor = System.Drawing.Color.Transparent;
            artist.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            artist.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            artist.Appearance.Options.UseBackColor = true;
            artist.Appearance.Options.UseFont = true;
            artist.Appearance.Options.UseForeColor = true;
            artist.Enabled = false;
            artist.Location = new System.Drawing.Point(0, 0);
            artist.Margin = new System.Windows.Forms.Padding(3);
            artist.Padding= new Padding(4);
            artist.Size = new System.Drawing.Size(55, 13);
            artist.TabIndex = 15;
            artist.Text = artistName;
            artist.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal; 
            Panel panel2 = new Panel();
            panel2.AutoSize = true;
            panel2.Controls.Add(artist);
            panel2.Location = new System.Drawing.Point(301, 10);
            panel2.Margin = new System.Windows.Forms.Padding(3);
            panel2.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            panel2.Size = new System.Drawing.Size(0, 32);
            panel2.TabIndex = 17;
            panel2.MaximumSize = new Size(157, 32);
            panel2.MouseEnter += new System.EventHandler(childItem_MouseHover);
            panel2.MouseLeave += new System.EventHandler(childItem_MouseLeave);
            panel2.MouseHover += new System.EventHandler(childItem_MouseHover);

            CheckEdit check = new CheckEdit();
            check.Location = new System.Drawing.Point(20, 16);
            check.Size = new System.Drawing.Size(16, 20);
            check.TabIndex = 21;
            panel2.MouseEnter += new System.EventHandler(childItem_MouseHover);
            panel2.MouseLeave += new System.EventHandler(childItem_MouseLeave);
            panel2.MouseHover += new System.EventHandler(childItem_MouseHover);


            newTrack.Controls.Add(lenght);
            newTrack.Controls.Add(Panel1);
            newTrack.Controls.Add(name);
            newTrack.Controls.Add(panel2);
            newTrack.Controls.Add(check);

            
        }
        private void hoverItem(object sender, EventArgs args)
        {
            Control control = (Control)sender;
            control.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }
        private void hoverLeaveItem(object sender, EventArgs args)
        {
            Control control = (Control)sender;
            control.BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
        }

        private void childItem_MouseHover(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = System.Drawing.Color.FromArgb(232, 232, 232);
            control.Parent.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            foreach (Control chirl in control.Controls)
            {
                chirl.ForeColor = System.Drawing.Color.FromArgb(212, 81, 34);
            }
        }
        private void childItem_MouseLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = System.Drawing.Color.Transparent;
            control.Parent.BackColor = System.Drawing.Color.Transparent;
            foreach (Control chirl in control.Controls)
            {
                chirl.ForeColor = System.Drawing.Color.FromArgb(25, 25, 25);
            }
        }
    }
}
