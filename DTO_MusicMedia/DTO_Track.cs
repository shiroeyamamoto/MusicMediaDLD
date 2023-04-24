using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_MusicMedia
{
    public class DTO_Track
    {
        private int TrackID;
        private string TrackName;
        private string TrackLegth;
        private string TrackGenre;
        private string AlbumID;

        public int TrackID1 { get => TrackID; set => TrackID = value; }
        public string TrackName1 { get => TrackName; set => TrackName = value; }
        public string TrackLegth1 { get => TrackLegth; set => TrackLegth = value; }
        public string TrackGenre1 { get => TrackGenre; set => TrackGenre = value; }
        public string AlbumID1 { get => AlbumID; set => AlbumID=value; }
    }
}
