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
        public static void ThemTrack(string path, DataGridView dataview)
        {
            using(var db=new MusicMediaDLDEntities())
            {
                TagLib.File tagFile = TagLib.File.Create(@path);
                AudioFileReader reader = new AudioFileReader(@path);
                TimeSpan duration = reader.TotalTime;
                string artist = tagFile.Tag.Artists[0];
                string album = tagFile.Tag.Album;
                string title = tagFile.Tag.Title;
                string genre = tagFile.Tag.FirstGenre;
                string lyrics = tagFile.Tag.Lyrics;
                uint year = tagFile.Tag.Year;
                var track = db.Set<Track>();
                if (db.Tracks.Any(x => x.TrackName.Equals(title)))
                {
                    MessageBox.Show("Đã có bài hát trong danh sách");
                    return;
                }
                track.Add(new Track { TrackName = title, TrackLength = duration.Seconds, TrackGenre = genre, Track_path = path });
                db.SaveChanges();

                var haveArtist= db.Artists.Where(l => l.ArtustName==artist).Count();
                if (haveArtist>0)
                {
                    trackArtist(dataview,artist,title);
                    
                    //MessageBox.Show("Thêm thành công đã có artist!");
                }
                else
                {
                    var tartist = db.Set<Artist>();
                    tartist.Add(new Artist { ArtustName=artist });
                    db.SaveChanges();
                    trackArtist(dataview, artist, title);
                    //MessageBox.Show("Thêm thành công chưa có artist!");
                }
                MessageBox.Show("Thành công!");


            }
        }
        private static void trackArtist(DataGridView dataview, string artist, string title)
        {
            using(var db= new MusicMediaDLDEntities())
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
    }
}
