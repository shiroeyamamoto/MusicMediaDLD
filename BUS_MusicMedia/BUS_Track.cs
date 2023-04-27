using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS_MusicMedia
{
    public class BUS_Track
    {
        public static void addTrack(List<string> path, DataGridView dataview)
        {
            DAL_MusicMedia.DAL_Track.ThemTrack(path, dataview);
        }
        public static void checkConnection()
        {
            DAL_MusicMedia.DAL_Track.checkConnection();
        }
    }
}
