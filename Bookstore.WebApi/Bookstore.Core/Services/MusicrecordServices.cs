using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Bookstore.Core
{
    public class MusicrecordServices : IMusicrecordServices
    {
        private readonly IMongoCollection<Musicrecord> _musicrecords;

        public MusicrecordServices(IDbClient dbClient)
        {
            _musicrecords = dbClient.GetMusicrecordsCollection();
        }

        public Musicrecord AddMusicrecord(Musicrecord musicrecord)
        {
            _musicrecords.InsertOne(musicrecord);
            return musicrecord;
        }

        public void DeleteMusicrecord(string id)
        {
            _musicrecords.DeleteOne(musicrecord => musicrecord.Id == id);
        }

        public Musicrecord GetMusicrecord(string id) => _musicrecords.Find(musicrecord => musicrecord.Id == id).First();

        public List<Musicrecord> GetMusicrecords() => _musicrecords.Find(musicrecord => true).ToList();

        public Musicrecord UpdateMusicrecord(Musicrecord musicrecord)
        {
            GetMusicrecord(musicrecord.Id);
            _musicrecords.ReplaceOne(b => b.Id == musicrecord.Id, musicrecord);
            return musicrecord;
        }
    }
}
