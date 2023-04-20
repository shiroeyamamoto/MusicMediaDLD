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
using DevExpress.XtraTab;
using NAudio.Wave;
using TagLib;
using NAudio.Wave.SampleProviders;
using DevExpress.Office.Import.OpenXml;

namespace Music_media
{
    public partial class Home : Form
    {
        //Menu choice
        Control choiced = new Control(); //Save before of choice 
        List<XtraTabPage> listTabPages = new List<XtraTabPage>();
        
        public Home()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));


            //Get TabPage of menuControl
            
            listTabPages.Add(homeTab);
            listTabPages.Add(musicTab);
            listTabPages.Add(queueTab);
            listTabPages.Add(playlistsTab);
            listTabPages.Add(settingTab);
            listTabPages.Add(noneTab);
            menuControl.SelectedTabPage = noneTab;


            /*var file = TagLib.File.Create(@"C:\Users\ACER\Music\Akon - Lonely.mp3");
            TimeSpan duration = file.Properties.Duration;

            foreach (string page in file.Tag.Genres)
            {
                MessageBox.Show(page);
            }*/
            

        }
        //Form function
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
        //Menu function 
        private void menuChoice(object sender, MouseEventArgs e)
        {
            MenuChoice.menu(sender, e, ref choiced, this, listTabPages);
        }
        private void hightlightRed(object sender, MouseEventArgs e)
        {
            MenuChoice.DrawLineRed(sender, e);
        }
        private void menuHover(object sender, EventArgs e)
        {
            MenuChoice.menuEvent(sender, e, ref choiced, Color.FromArgb(237, 237, 237));
        }
        private void menuLeave(object sender, EventArgs e)
        {
            MenuChoice.menuEvent(sender, e, ref choiced, Color.FromArgb(243, 243, 243));
        }
        //setup button
        private void litteButtonHover(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            MenuChoice.backcolor(ctr, Color.FromArgb(234, 234, 234));
        }
        private void litteButtonLeave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
                MenuChoice.backcolor(ctr, Color.Transparent);
        }
        private void searchText_Enter(object sender, EventArgs e)
        {
            customTextbox ctr = (customTextbox)sender;
            ctr.BorderColor = Color.Red;
            ctr.Invalidate();
            ctr.Refresh();
        }

        //From move
        Point MouseDownLocation;
        private void FormMoveMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                ctr.Left = e.X + ctr.Left - MouseDownLocation.X;
                ctr.Top = e.Y + ctr.Top - MouseDownLocation.Y;
                this.Left += ctr.Left;
                this.Top += ctr.Top;
            }
        }
        private void FormMoveDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        //test Naudio
        private WaveOut outputDevice;
        private AudioFileReader audioFile;
        int musicOn= 0;
        bool turn = false;
        private void OnButtonPlayClick(object sender, EventArgs args)
        {
                if (!turn)
                {
                    if (outputDevice == null)
                    {
                        outputDevice = new WaveOut();
                        outputDevice.PlaybackStopped += OnPlaybackStopped;
                    }
                    if (audioFile == null)
                    {
                        audioFile = new AudioFileReader(@"C:\Users\ACER\Downloads\NeuLaAnh-TheMen-2729808.mp3");
                    outputDevice.Init(audioFile);
                    }
                    outputDevice.Play();
                    musicOn = 1;
                    turn = true;
                }else
                if (turn)
                {
                    turn = false;
                    if (audioFile == null)
                        OnButtonPlayClick(sender, args);
                    outputDevice.Pause();
                    
                }
                Mp3FileReader a = new Mp3FileReader(@"C:\Users\ACER\Downloads\NeuLaAnh-TheMen-2729808.mp3");
            
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }
        private void test(object sender, EventArgs args)
        {
            
        }
    }
}
