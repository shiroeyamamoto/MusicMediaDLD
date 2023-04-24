using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_MusicMedia
{
    public class DAL_Track
    {
        MusicmediaDLDEntities db;

        //ptkt
        public DAL_Track()
        {
            db = new MusicmediaDLDEntities();
        }

        public void LayDSTrack()
        {
            var ds = db.Tracks.Select(s=>new
            {
                
            });
        }
    }
}
