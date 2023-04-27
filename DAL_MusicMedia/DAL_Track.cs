using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib.Riff;
using static System.Net.Mime.MediaTypeNames;

namespace DAL_MusicMedia
{
    public class DAL_Track
    {
        public static void checkConnection()
        {
            using(var db= new KhangDuong())
            {
                MessageBox.Show(db.Database.Connection.ConnectionString);
            }
        }
        public static void ThemTrack(List<string> path, DataGridView dataview)
        {

            foreach (var item in path)
            {
                using (var db = new KhangDuong())
                {
                    TagLib.File tagFile = TagLib.File.Create(@item);
                    //AudioFileReader reader = new AudioFileReader(@item);
                    //TimeSpan duration = reader.TotalTime;
                    string artist = tagFile.Tag.Artists[0];
                    string album = tagFile.Tag.Album;
                    string title = tagFile.Tag.Title;
                    string genre= tagFile.Tag.FirstGenre;
                    string lyrics = tagFile.Tag.Lyrics;
                    uint year = tagFile.Tag.Year;
                    var track = db.Set<Track>();
                    if (db.Tracks.Any(x => x.TrackName.Equals(title)))
                    {
                        return;
                    }

                    //Tạo track
                    if (AlbumTrack(dataview, album) > 0)
                    {
                        track.Add(new Track { TrackName = title, TrackLength =(tagFile.Properties.Duration.Minutes * 60 + tagFile.Properties.Duration.Seconds), TrackGenre = genre == null ? "Unknow" : genre, AlbumID =AlbumTrack(dataview,album), Track_path = @item });
                    }
                    else
                    {
                        track.Add(new Track { TrackName = title, TrackLength = (tagFile.Properties.Duration.Minutes * 60 + tagFile.Properties.Duration.Seconds), TrackGenre = genre == null ? "Unknow" : genre, AlbumID =CreateAlbum(dataview,album,year), Track_path = @item });
                        }
                    db.SaveChanges();

                    var haveArtist = db.Artists.Where(l => l.ArtustName == artist).Count();
                    if (haveArtist > 0)
                    {
                        //Thêm track khi đã có artist
                        trackArtist(dataview, artist, title);
                    }
                    else
                    {
                        //thêm track khi chưa có artist
                        var tartist = db.Set<Artist>();
                        tartist.Add(new Artist { ArtustName = artist });
                        db.SaveChanges();
                        trackArtist(dataview, artist, title);
                    }
                }
            }
            MessageBox.Show("Thêm thành công!");
        }
        //Hàm tạo khóa ngoại
        private static void trackArtist(DataGridView dataview, string artist, string title)
        {
            using (var db = new KhangDuong())
            {
                var trackArtist = db.Set<Track_Artist>();
                //var empdata = db.Tracks.Where(x => x.TrackName==title).Select(s=>s.TrackID) ;
                var empdata = db.Artists.Where(x => x.ArtustName == artist);
                dataview.DataSource = empdata.ToList();
                dataview.SelectAll();
                DataGridViewRow row = dataview.SelectedRows[0];
                //MessageBox.Show(row.Cells[0].Value.ToString());
                var artistId = row.Cells[0].Value;

                var empdata1 = db.Tracks.Where(x => x.TrackName == title);
                dataview.DataSource = null;
                dataview.DataSource = empdata1.ToList();
                dataview.SelectAll();
                DataGridViewRow row1 = dataview.SelectedRows[0];
                var trackId = row1.Cells[0].Value;
                //MessageBox.Show(trackId.ToString());

                trackArtist.Add(new Track_Artist { TrackID = Int32.Parse(trackId.ToString()), ArtistID = Int32.Parse(artistId.ToString()) });
                db.SaveChanges();
            }
        }
        //tim album da co trong db chua
        private static int AlbumTrack(DataGridView dataview, string ablum)
        {
            using (var db = new KhangDuong())
            {
                var empdata = db.Albums.Where(x => x.AlbumName == ablum);
                if (empdata.Count() > 0)
                {
                    dataview.DataSource = empdata.ToList();
                    dataview.SelectAll();
                    DataGridViewRow row = dataview.SelectedRows[0];
                    var albumId = row.Cells[0].Value;
                    return Int32.Parse(albumId.ToString());
                }
                else return 0;
            }
        }
        private static int CreateAlbum(DataGridView dataview, string ablum,uint year)
        {
            using (var db = new KhangDuong())
            {
                var newAlbum= db.Set<Album>();
                newAlbum.Add(new Album { AlbumName= ablum,ReleaseYear= new DateTime(year)});
                db.SaveChanges();
                var empdata = db.Albums.Where(x => x.AlbumName == ablum);
                dataview.DataSource = empdata.ToList();
                dataview.SelectAll();
                DataGridViewRow row = dataview.SelectedRows[0];
                var albumId = row.Cells[0].Value;
                return Int32.Parse(albumId.ToString());
                
            }
        }
    }
}
