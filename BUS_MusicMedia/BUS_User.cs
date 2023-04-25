using DAL_MusicMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS_MusicMedia
{
    public class BUS_User
    {
        public static void testConnection()
        {
            using (var db = new MusicMediaDLDEntities())
            {
                MessageBox.Show(db.Database.Connection.ConnectionString);
            }
        }
        public static void add()
        {
            using (var db = new MusicMediaDLDEntities())
            {
                try
                {
                    DateTime dateTime = DateTime.Now;
                    var them = db.Set<Track>();
                    them.Add(new Track { TrackID = 1, TrackName = "Nếu là anh", TrackLength = 100, TrackGenre = "Pop", AlbumID = null }) ;

                    //var them = db.Set<>
                    //db.Albums.Add(them);
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công!");
                }
                catch
                {
                    MessageBox.Show("Thêm không thành công!");
                }
                MessageBox.Show(db.Database.Connection.ConnectionString);
            }
        }
        public static void select(object sender1, object sender2)
        {
            DataGridView control1 = (DataGridView)sender1;
            Control control2 = (Control)sender2;
            using (var db = new MusicMediaDLDEntities())
            {
                var query = from temp in db.Tracks select new { ID = temp.TrackID, NAME = temp.TrackName };
                control1.DataSource = query.ToList();
                control2.Text = "Duoc";
            }
        }

    }
}
