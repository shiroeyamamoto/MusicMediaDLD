using DAL_MusicMedia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_MusicMedia;

namespace BUS_MusicMedia
{
    public class BUS_ListQueue
    {
        public static void addListQueue(FlowLayoutPanel floatLayout)
        {
            DAL_ListQueue.addListItem(floatLayout);
        }
    }
}
