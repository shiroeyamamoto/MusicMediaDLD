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
using System.Data.SqlClient;
using System.Threading;
using NAudio.MediaFoundation;

using System.Windows.Media;
using Music_media.khoabeo;
using BUS_MusicMedia;
using Label = System.Windows.Forms.Label;
using DevExpress.DocumentView.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Music_media
{
    public partial class Home : Form
    {
        //Menu choice
        Control choiced = new Control(); //Save before of choice 
        List<XtraTabPage> listTabPages = new List<XtraTabPage>();
        public static MediaPlayer mediaPlayer = new MediaPlayer();
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
            listTabPages.Add(tabCreatPlaylist);
            listTabPages.Add(tabPlaylistOfUser);
            listTabPages.Add(noneTab);
            menuControl.SelectedTabPage = homeTab;

            /*var file = TagLib.File.Create(@"C:\Users\ACER\Music\Akon - Lonely.mp3");
            TimeSpan duration = file.Properties.Duration;

            foreach (string page in file.Tag.Genres)
            {
                MessageBox.Show(page);
            }*/


            // Tạo nút


        }
        //Form function
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void exit_MouseHover(object sender, EventArgs e)
        {
            exit.BackColor = System.Drawing.Color.FromArgb(196, 43, 28);
            exit.ForeColor = System.Drawing.Color.FromArgb(248, 228, 227);
        }
        private void exit_MouseLeave(object sender, EventArgs e)
        {
            exit.BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
            exit.ForeColor = System.Drawing.Color.FromArgb(0, 0, 0);
            minimum.BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
            fullSreen.BackColor = System.Drawing.Color.FromArgb(249, 249, 249);
        }
        private void minimum_MouseHover(object sender, EventArgs e)
        {
            minimum.BackColor = System.Drawing.Color.FromArgb(233, 233, 233);
        }
        private void minimum_Click(object sender, EventArgs e)
        {
            this.MinimizeBox = true;
        }
        private void fullSreen_MouseEnter(object sender, EventArgs e)
        {
            fullSreen.BackColor = System.Drawing.Color.FromArgb(233, 233, 233);
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
            MenuChoice.menuEvent(sender, e, ref choiced, System.Drawing.Color.FromArgb(237, 237, 237));
        }
        private void menuLeave(object sender, EventArgs e)
        {
            MenuChoice.menuEvent(sender, e, ref choiced, System.Drawing.Color.FromArgb(243, 243, 243));
        }
        //setup button
        private void litteButtonHover(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            MenuChoice.backcolor(ctr, System.Drawing.Color.FromArgb(234, 234, 234));
        }
        private void litteButtonLeave(object sender, EventArgs e)
        {
            Control ctr = (Control)sender;
            MenuChoice.backcolor(ctr, System.Drawing.Color.Transparent);
        }
        private void searchText_Enter(object sender, EventArgs e)
        {
            customTextbox ctr = (customTextbox)sender;
            ctr.BorderColor = System.Drawing.Color.Red;
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
        int musicOn = 0;
        bool turn = false;
        //private void onbuttonplayclick(object sender, eventargs args)
        //{
        //    if (!turn)
        //    {
        //        if (outputdevice == null)
        //        {
        //            outputdevice = new waveout();
        //            outputdevice.playbackstopped += onplaybackstopped;
        //        }
        //        if (audiofile == null)
        //        {
        //            audiofile = new audiofilereader(@"c:\users\acer\music\girls like you - maroon 5.m4a");
        //            outputdevice.init(audiofile);
        //        }
        //        outputdevice.play();
        //        musicon = 1;
        //        turn = true;
        //    }
        //    else
        //    if (turn)
        //    {
        //        turn = false;
        //        if (audiofile == null)
        //            onbuttonplayclick(sender, args);
        //        outputdevice.pause();

        //    }
        //    mp3filereader a = new mp3filereader(@"c:\users\acer\music\g.e.m. - 來自天堂的魔鬼.mp3");
        //    test();

        //}
       
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
            txtUserName.Text = "Conduongmau";
            txtUserPass.Text = "Test";
            tabCreatPlaylist.Appearance.Header.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            tabCreatPlaylist.Appearance.Header.BackColor2 = System.Drawing.Color.FromArgb(30, 30, 30);
            tabCreatPlaylist.Appearance.Header.BorderColor = System.Drawing.Color.FromArgb(50, 50, 50);
            tabCreatPlaylist.Appearance.Header.Options.UseBackColor = true;
            tabCreatPlaylist.Appearance.Header.Options.UseBorderColor = true;

        }
        //MusicControl
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

        private void panelAccount_Click(object sender, EventArgs e)
        {
            // Chuyển đổi sang trang tài khoản (tabAccount)
            menuControl.SelectedTabPage = tabLogin;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (var context = new MusicMediaDLDEntities1())
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
                    playlistsMenu.Visible= true;
                }
                else
                {
                    MessageBox.Show("Login Fail");
                    return;
                }
            }
        }
        private void btnRegSucces_Click(object sender, EventArgs e)

        {
            using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
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
                khoabeo.User newUser = new khoabeo.User()
                {
                    ho = txtHo.Text,
                    Ten = txtTen.Text,
                    ngaySinh = dateNgaySinh.Value,
                    UserName = txtUsernameReg.Text,
                    Userpassword = txtPasswordReg.Text,
                    Sdt = txtsdtReg.Text,
                    Admin = cbType.Text == "Admin" ? true : false,
                    Coin = 0
                };

                _db.Users.Add(newUser);
                _db.SaveChanges();
                menuControl.SelectedTabPage = tabLogin;
                MessageBox.Show("Đăng ký thành công!");
            }


        }
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
     
        private void btnSignup_Click(object sender, EventArgs e)
        {
            menuControl.SelectedTabPage = tabReg;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            menuControl.SelectedTabPage = tabLogin;
        }
        private void BtnOpenFolder_Click(object sender, EventArgs e)
        {


            DeleteMusic.Visible = false;

            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //lay duong dan
                    string folderPath = dialog.SelectedPath;

                    /// tai cac thuoc tinh cua track 

                    List<Track> songs = LoadTrackFromFile(folderPath);


              
                    dtgTrack.DataSource = songs;
                }
            }
        }
        private List<Track> LoadTrackFromFile(string folderPath)
        {
            List<Track> songs = new List<Track>();



            var files = Directory.GetFiles(folderPath, "*.mp3", SearchOption.AllDirectories);
            int i = 0;
            foreach (var file in files)
            {
                try
                {

                    TagLib.File tagFile = TagLib.File.Create(file);

                    Track track = new Track
                    {
                        TrackID = ++i,
                        TrackName = tagFile.Tag.Title,

                        TrackLength = (int?)tagFile.Properties.Duration.TotalSeconds,
                        Track_path = file
                    };

                   
                    track.TrackGenre = tagFile.Tag.FirstGenre;

                    songs.Add(track);
                }
                catch (Exception ex)
                {

                }
            }

            return songs;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgTrack.Columns["DeleteMusic"].Index && e.RowIndex >= 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bài hát này không?", "Xóa bài hát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var trackPath = dtgTrack.Rows[e.RowIndex].Cells["Track_path"].Value.ToString();
                    using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
                    {
                        var trackToRemove = _db.Tracks.FirstOrDefault(x => x.Track_path == trackPath);
                        if (trackToRemove != null)
                        {
                            _db.Tracks.Remove(trackToRemove);
                            _db.SaveChanges();
                        }
                        ///KHOABEO LOAD LẠI 
                        var tracks = _db.Tracks.ToList();
                        dtgTrack.DataSource = tracks;



                    }

                }
            }
            if (dtgTrack.Columns[e.ColumnIndex].Name == "playMusicdtg")
            {
                
                string TrackPath = dtgTrack.Rows[e.RowIndex].Cells["Track_path"].Value.ToString();
                string TrackLength = dtgTrack.Rows[e.RowIndex].Cells["TrackLength"].Value.ToString();
                TimeSpan timeSpan = TimeSpan.FromSeconds(int.Parse(TrackLength));
                endTime.Text = timeSpan.ToString(@"mm\:ss");
                playBar.Maximum = Convert.ToInt32(TrackLength);

                
                DevExpress.XtraEditors.PictureEdit pictureBox = imgMP;
                DevExpress.XtraEditors.LabelControl nameLabel = nameMP;
                DevExpress.XtraEditors.LabelControl artistLabel = artistMP;

                PlayMp3(TrackPath, playBar, timer1, pictureBox, nameLabel, artistLabel);
            }

        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dtgTrack.CurrentCell = dtgTrack.Rows[e.RowIndex].Cells[e.ColumnIndex];
                ContextMenuStrip menu = new ContextMenuStrip();

                using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
                {
                    var currentUser = _db.Users.FirstOrDefault(u => u.UserName == txtUserName.Text);
        
                    var playlists = _db.Playlists.Where(p => p.UserID == currentUser.UserID).ToList();

                    foreach (var playlist in playlists)
                    {
                        var menuItem = new ToolStripMenuItem(playlist.PlaylistName);

                        menuItem.Click += (s, a) =>
                        {
                            var selectedTrack = dtgTrack.Rows[e.RowIndex].DataBoundItem as Track;

                            using (var _dbMenu = new Music_media.khoabeo.MusicMediaDLDEntities1())
                            {
                                var dbPlaylist = _dbMenu.Playlists.FirstOrDefault(p => p.PlaylistName == playlist.PlaylistName);

                                var trackPlaylist = new Track_Playlist
                                {
                                    TrackID = selectedTrack.TrackID,
                                    PlaylistID = dbPlaylist.PlaylistID
                                };
                                _dbMenu.Track_Playlist.Add(trackPlaylist);

                                _dbMenu.SaveChanges();
                            }

                            MessageBox.Show($"Bài hát '{selectedTrack.TrackName}' đã được thêm vào playlist '{playlist.PlaylistName}' thành công!");
                        };

                        menu.Items.Add(menuItem);
                    }
                }

                menu.Show(dtgTrack, e.Location);
            }
        }



        /// pHÁT NHẠC TẠI ĐÂY BÂY PHẢI CÓ ĐỦ 3 THÔNG SỐ
        public static void PlayMp3(string filePath, System.Windows.Forms.ProgressBar progressBar, System.Windows.Forms.Timer playbackTimer, DevExpress.XtraEditors.PictureEdit pictureBox, DevExpress.XtraEditors.LabelControl nameLabel, DevExpress.XtraEditors.LabelControl artistLabel)
        {
            mediaPlayer.Stop();
            mediaPlayer.Open(new Uri(filePath));
            mediaPlayer.Play();

            
            var tagFile = TagLib.File.Create(filePath);
            var picture = tagFile.Tag.Pictures.FirstOrDefault();
            if (picture != null)
            {
                using (var stream = new MemoryStream(picture.Data.Data))
                {
                    pictureBox.Image = Image.FromStream(stream);
                }
            }
            else
            {
                pictureBox.Image = null;
            }

           
            nameLabel.Text = tagFile.Tag.Title;
            artistLabel.Text = tagFile.Tag.Performers.FirstOrDefault();

            playbackTimer.Interval = 1000;
            playbackTimer.Tick += (sender, args) =>
            {
                progressBar.Value = (int)mediaPlayer.Position.TotalSeconds;
            };
            playbackTimer.Start();

            mediaPlayer.MediaEnded += (sender, args) =>
            {
                playbackTimer.Stop();
                progressBar.Value = 0;
            };
        }



        private void playBar_MouseUp(object sender, MouseEventArgs e)
        {
            int newPosition = (int)(((float)e.X / (float)playBar.Width) * playBar.Maximum);
            mediaPlayer.Position = TimeSpan.FromSeconds(newPosition);
        }
        private List<Track> selectedTracks = new List<Track>();

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
              
                if (dtgTrack.Columns[e.ColumnIndex].Name == "SelectTrack")
                {
                  
                    bool isChecked = (bool)dtgTrack.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    string trackPath = dtgTrack.Rows[e.RowIndex].Cells["Track_path"].Value.ToString();
                    String trackName = dtgTrack.Rows[e.RowIndex].Cells["TrackName"].Value.ToString();
                    int trackLength = Convert.ToInt32(dtgTrack.Rows[e.RowIndex].Cells["TrackLength"].Value.ToString());
                    String trackGenre = dtgTrack.Rows[e.RowIndex].Cells["TrackGenre"].Value.ToString();
                    khoabeo.Track trackdtg = new khoabeo.Track();

                    if (isChecked)
                    {   
                        using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
                        {
                            Boolean kiemTra = _db.Tracks.Any(x => x.Track_path == trackPath);
                            if (!kiemTra)
                            {
                                trackdtg.Track_path = trackPath;
                                trackdtg.TrackName = trackName;
                                trackdtg.TrackLength = trackLength;
                                trackdtg.TrackGenre = trackGenre;
                                _db.Tracks.Add(trackdtg);
                                _db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
                        {
                            var trackToRemove = _db.Tracks.FirstOrDefault(x => x.Track_path == trackPath);
                            if (trackToRemove != null)
                            {
                                _db.Tracks.Remove(trackToRemove);
                                _db.SaveChanges();
                            }
                        }
                    }
                }
            }


        }

        private void btnLibOndb_Click(object sender, EventArgs e)
        {
            DeleteMusic.Visible = true;
            SelectTrack.Visible = false;
            using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
            {
               var tracks = _db.Tracks.ToList();

                if (tracks != null)
                {
                    dtgTrack.DataSource = tracks;
                }

            }

        }

        private void dtgTrack_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;

        }

    

 

        private void panelRounded9_Click(object sender, EventArgs e)
        {
            menuControl.SelectedTabPage = tabCreatPlaylist;
        }

        private void btnPopCreatePlaylist_Click(object sender, EventArgs e)
        {
            using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
            {
                Boolean kiemTraPlaylist = _db.Playlists.Any(p => p.PlaylistName.Equals(this.txtCreatPlaylist.Text));
                if (this.txtCreatPlaylist.Text.Length > 5 && kiemTraPlaylist == false)
                {

                    khoabeo.User user = _db.Users.FirstOrDefault(u => u.UserName.Equals(txtUserName.Text));

                    if (user != null)
                    {

                        khoabeo.Playlist newPlaylist = new khoabeo.Playlist()
                        {
                            PlaylistName = this.txtCreatPlaylist.Text,
                            UserID = user.UserID
                        };


                        _db.Playlists.Add(newPlaylist);
                        _db.SaveChanges();
                        menuControl.SelectedTabPage = playlistsTab;
                        MessageBox.Show("Taoj Thành Công");
                    }
                }
                else
                {
                    MessageBox.Show("Faild");
                }
            }
        }

        private void btnCancelCreate_Click(object sender, EventArgs e)
        {
            menuControl.SelectedTabPage = playlistsTab;
        }

        private void playlistsMenu_Paint(object sender, PaintEventArgs e)
        {
            using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
            {
                var currentUser = _db.Users.FirstOrDefault(u => u.UserName == txtUserName.Text);
                var playlists = _db.Playlists.Where(p => p.UserID == currentUser.UserID).ToList();
                flowPlaylist.Controls.Clear();
                List<object> combinedList = new List<object>();
                foreach (var playlist in playlists)
                {
                    var panel = new Panel();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Width = 200;
                    panel.Height = 100;

                    var labelPlaylistName = new Label();
                    labelPlaylistName.Text = playlist.PlaylistName;
                    labelPlaylistName.AutoSize = true;
                    labelPlaylistName.Font = new Font("Arial", 12, FontStyle.Bold);
                    labelPlaylistName.Location = new Point(10, 10);
                    panel.Controls.Add(labelPlaylistName);

                    var pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(@"C:\Users\anhkh\Desktop\New folder\MusicMediaDLD\Music media\Resources\musicIco.png");
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox.Location = new Point(10, 50);
                    pictureBox.Width = 50;
                    pictureBox.Height = 50;
                    panel.Controls.Add(pictureBox);
                    panel.MouseClick += (s, eventArgs) =>
                    {
                        menuControl.SelectedTabPage = tabPlaylistOfUser;
                        LoadTracksForUserAndPlaylist(dtgvPlaylist, playlist.PlaylistID);
                    };

                    flowPlaylist.Controls.Add(panel);
                }
            }
        }


        private void LoadTracksForUserAndPlaylist(DataGridView dtgvTrackPlaylist, int playlistID)
        {
            using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
            {
                // Lấy danh sách các Track_Playlist có PlaylistID tương ứng
                var trackPlaylist = _db.Track_Playlist
                    .Where(tp => tp.PlaylistID == playlistID)
                    .ToList();

                // Lấy danh sách các Track thuộc Playlist có PlaylistID tương ứng
                var tracks = trackPlaylist
                    .Select(tp => tp.Track)
                    .ToList();

                // Đặt danh sách này làm nguồn dữ liệu cho DataGridView
                dtgvTrackPlaylist.DataSource = tracks;
            }
        }

        private void dtgvPlaylist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvPlaylist.Columns["DeleteOfListTrack"].Index && e.RowIndex >= 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bài hát này không?", "Xóa bài hát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var trackPath = dtgvPlaylist.Rows[e.RowIndex].Cells["Track_path"].Value.ToString();
                    using (var _db = new Music_media.khoabeo.MusicMediaDLDEntities1())
                    {
                        var trackToRemove = _db.Tracks.FirstOrDefault(x => x.Track_path == trackPath);
                        if (trackToRemove != null)
                        {
                            _db.Tracks.Remove(trackToRemove);
                            _db.SaveChanges();
                        }
                        ///KHOABEO LOAD LẠI 
                        var tracks = _db.Tracks.ToList();
                        dtgTrack.DataSource = tracks;



                    }

                }
            }
            if (dtgvPlaylist.Columns[e.ColumnIndex].Name == "playOfListTrack")
            {

                string TrackPath = dtgvPlaylist.Rows[e.RowIndex].Cells["Track_path"].Value.ToString();
                string TrackLength = dtgvPlaylist.Rows[e.RowIndex].Cells["TrackLength"].Value.ToString();
                TimeSpan timeSpan = TimeSpan.FromSeconds(int.Parse(TrackLength));
                endTime.Text = timeSpan.ToString(@"mm\:ss");
                playBar.Maximum = Convert.ToInt32(TrackLength);


                DevExpress.XtraEditors.PictureEdit pictureBox = imgMP;
                DevExpress.XtraEditors.LabelControl nameLabel = nameMP;
                DevExpress.XtraEditors.LabelControl artistLabel = artistMP;

                PlayMp3(TrackPath, playBar, timer1, pictureBox, nameLabel, artistLabel);
            }
        }









        //////TẤT CẢ ĐỀU CỦA THẰNG KHANG

        //private void themFile(object sender, EventArgs e)
        //{
        //    OpenFileDialog file = new OpenFileDialog();
        //    file.Filter = "All Media Files|*.mp3;*.flac;*.m4a;";
        //    if (file.ShowDialog() == DialogResult.OK)
        //    {
        //        BUS_Track.addTrack(@file.FileName, dataGridView1);
        //    }
        //}
    }
}










