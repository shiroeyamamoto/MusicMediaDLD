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
using BUS_MusicMedia;
using TagLib;
using NAudio.Wave.SampleProviders;
using DevExpress.Office.Import.OpenXml;
using System.Data.SqlClient;
using System.Threading;
using NAudio.MediaFoundation;
//using Music_media.khoabeoenti;

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
            listTabPages.Add(tabLogin);
            listTabPages.Add(tabReg);

            listTabPages.Add(noneTab);
            menuControl.SelectedTabPage = noneTab;

            //BUS_Track.addTrack(@"C:\Users\ACER\Music\Girls Like You - Maroon 5.m4a", dataGridView1);
            

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
        //Form move
        Point mouseLocation;
        private void FormMoveMove(object sender, MouseEventArgs e)
        {
            Control ctr = (Control)sender;
            if (e.Button == MouseButtons.Left)
            {
                ctr.Left = e.X + ctr.Left - mouseLocation.X;
                ctr.Top = e.Y + ctr.Top - mouseLocation.Y;
                this.Left += ctr.Left;
                this.Top += ctr.Top;
            }
        }
        private void FormMoveDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseLocation = e.Location;
            }
        }
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
        private void FormMMove(object sender, MouseEventArgs e)
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
        private void FormMDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        //test Naudio with mp3
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
                        audioFile = new AudioFileReader(@"C:\Users\ACER\Music\Girls Like You - Maroon 5.m4a");
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
                Mp3FileReader a = new Mp3FileReader(@"C:\Users\ACER\Music\G.E.M. - 來自天堂的魔鬼.mp3");
                test();
            
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }
        //Test audio with url

        private void buttonPlayUrl(object sender, EventArgs args)
        {

        }
        //Test database save file mp3
        private void test()
        {
            TagLib.File tagFile = TagLib.File.Create(@"C:\Users\ACER\Music\Girls Like You - Maroon 5.m4a");
            AudioFileReader reader = new AudioFileReader(@"C:\Users\ACER\Music\Girls Like You - Maroon 5.m4a");
            TimeSpan duration = reader.TotalTime;
            string artist = tagFile.Tag.Artists[0];
            string album = tagFile.Tag.Album;
            string title = tagFile.Tag.Title;
            string genre = tagFile.Tag.FirstGenre;
            string lyrics = tagFile.Tag.Lyrics;
            uint year = tagFile.Tag.Year;
            MessageBox.Show(title + ",\n " + artist + ",\n " + album + ",\n " + genre + ",\n " + duration + ",\n " + lyrics + ",\n " + year);
        }
        //HomeControl
        private void Home_Load(object sender, EventArgs e)
        {
            this.txtUserName.Text = "conduongmau";
            this.txtUserPass.Text = "test";
            this.txtHo.Text = "le";
            this.txtTen.Text = "le";
            this.txtUsernameReg.Text = "conduongmau";
            this.txtPasswordReg.Text = "test";
            this.txtsdtReg.Text = "0839996965";
            this.cbType.SelectedIndex = 0;
            this.dateNgaySinh.Value = new DateTime(2002, 09, 18);
        }
        //MusicControl
        private void hoverItem(object sender, EventArgs args)
        {
            Control control = (Control)sender;
            control.BackColor = Color.FromArgb(240, 240, 240);
        }
        private void hoverLeaveItem(object sender, EventArgs args)
        {
            Control control = (Control)sender;
            control.BackColor = Color.FromArgb(249, 249, 249);
        }

        private void childItem_MouseHover(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = Color.FromArgb(232, 232, 232);
            control.Parent.BackColor = Color.FromArgb(240, 240, 240);
            foreach (Control chirl in control.Controls)
            {
                chirl.ForeColor = Color.FromArgb(212, 81, 34);
            }
        }
        private void childItem_MouseLeave(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            control.BackColor = Color.Transparent;
            control.Parent.BackColor = Color.Transparent;
            foreach (Control chirl in control.Controls)
            {
                chirl.ForeColor = Color.FromArgb(25, 25, 25);
            }
        }

        private void panelAccount_Click(object sender, EventArgs e)
        {
            // Chuyển đổi sang trang tài khoản (tabAccount)
            menuControl.SelectedTabPage = tabLogin;
        }

        /*private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var context = new MusicMediaDLDEntities())
            {
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtUserPass.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }

                bool checkUsername = context.Users.Any(u => u.UserName.Equals(txtUserName.Text));
                bool checkPass = context.Users.Any(u => u.Userpassword.Equals(txtUserPass.Text));
                if (checkUsername && checkPass)
                {
                    MessageBox.Show("Login success");
                    menuControl.SelectedTabPage = playlistsTab;
                }
                else
                {
                    MessageBox.Show("Login Fail");
                    return;
                }
            }
        }*/
        /*private void btnRegSucces_Click(object sender, EventArgs e)

        {
            using (var _db = new khoabeoenti.MusicMediaDLDEntities())
            {
                String chuoiKhongHopLe = "!,@,#,$,%,^,&,*,(,),>,<,?,INSERT,UPDATE,DELETE,SELECT";
                bool ktSdt = sodienthoaihople(this.txtPasswordReg.Text);
                bool checkUsername = _db.Users.Any(u => u.UserName.Equals(txtUsernameReg.Text));
                DateTime now = DateTime.Today;
                int age = now.Year - dateNgaySinh.Value.Year;
                List<string> danhSachPhanTu = chuoiKhongHopLe.Split(',').ToList();

                if (danhSachPhanTu.Any(p => txtHo.Text.Contains(p) || txtTen.Text.Contains(p) || txtUsernameReg.Text.Contains(p)))
                {
                    MessageBox.Show("Thông tin không hợp lệ, vui lòng không nhập các ký tự đặc biệt hoặc từ khóa trong danh sách!");
                    return;
                }
                if (string.IsNullOrEmpty(txtHo.Text) || string.IsNullOrEmpty(txtTen.Text) || dateNgaySinh.Value == null || string.IsNullOrEmpty(txtUsernameReg.Text) || string.IsNullOrEmpty(txtPasswordReg.Text) || string.IsNullOrEmpty(txtsdtReg.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return;
                }
                if (txtHo.Text.Contains(chuoiKhongHopLe))
                {
                    MessageBox.Show("Thông tin khong hợp lệ.");
                    return;
                };

                if (!sodienthoaihople(txtsdtReg.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ.");
                    return;
                }


                if (checkUsername)
                {
                    MessageBox.Show("Username đã tồn tại.");
                    return;
                }

                if (age < 12)
                {
                    MessageBox.Show("Bạn phải đủ 12 tuổi để đăng ký.");
                    return;
                }
                *//*khoabeoenti.User newUser = new khoabeoenti.User()
                {
                    ho = txtHo.Text,
                    Ten = txtTen.Text,
                    ngaySinh = dateNgaySinh.Value,
                    UserName = txtUsernameReg.Text,
                    Userpassword = txtPasswordReg.Text,
                    Sdt = txtsdtReg.Text,
                    Admin = cbType.Text == "Admin" ? true : false,
                    Coin = 0
                };*/
/*
                _db.Users.Add(newUser);
                _db.SaveChanges();
                menuControl.SelectedTabPage = tabLogin;
                MessageBox.Show("Đăng ký thành công!");*//*
            }


        }*/
        public bool sodienthoaihople(string sdt)
        {

            if (sdt.Length != 10)
            {
                return false;
            }
            foreach (char c in sdt)
            {
                if (!Char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
        private void panelAccount_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnSignup_Click(object sender, EventArgs e)
        {
            menuControl.SelectedTabPage = tabReg;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            menuControl.SelectedTabPage = tabLogin;
        }

        private void btnLibOnMydestop_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Thư mục đã chọn
                string selectedPath = dialog.SelectedPath;
            }
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            //BUS_User.select(dataGridView1, labelControl10);
        }

        private void themFile(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "All Media Files|*.mp3;*.flac;*.m4a;";
            if (file.ShowDialog() == DialogResult.OK)
            {
                BUS_Track.addTrack(@file.FileName,dataGridView1);
            }
        }
    }
}
