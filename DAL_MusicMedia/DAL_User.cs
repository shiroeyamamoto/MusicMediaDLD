using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_MusicMedia
{
    public class DAL_User
    {
        MusicmediaDLDEntities db;

        // phuong thuc khoi tao
        public DAL_User()
        {
            db = new MusicmediaDLDEntities();
        }

        //testing function
        public void getUserList()
        {
            var ds = db.Users.ToList();
        }
    }
}
