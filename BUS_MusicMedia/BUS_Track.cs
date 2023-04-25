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
        public static void addTrack(string path, DataGridView dataview)
        {
            DAL_MusicMedia.DAL_Track.ThemTrack(path, dataview);
        }
    }
}
