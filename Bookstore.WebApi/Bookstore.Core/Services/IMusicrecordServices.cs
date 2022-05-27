using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface IMusicrecordServices
    {
        List<Musicrecord> GetMusicrecords();
        Musicrecord GetMusicrecord(string id);
        Musicrecord AddMusicrecord(Musicrecord musicrecord);

        void DeleteMusicrecord(string id);
        Musicrecord UpdateMusicrecord(Musicrecord musicrecord);
    }
}
