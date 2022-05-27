using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Bookstore.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<Book> _books;
        private readonly IMongoCollection<Notebook> _notebooks;
        private readonly IMongoCollection<Musicrecord> _musicrecords;

        public DbClient(IOptions<BookstoreDbConfig> bookstoreDbConfig)
        {
            var client = new MongoClient(bookstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(bookstoreDbConfig.Value.Database_Name);
            _books = database.GetCollection<Book>(bookstoreDbConfig.Value.Books_Collection_Name);
            _notebooks = database.GetCollection<Notebook>(bookstoreDbConfig.Value.Notebooks_Collection_Name);
            _musicrecords = database.GetCollection<Musicrecord>(bookstoreDbConfig.Value.Musicrecords_Collection_Name);
        }

        public IMongoCollection<Book> GetBooksCollection() => _books;
        public IMongoCollection<Notebook> GetNotebooksCollection() => _notebooks;
        public IMongoCollection<Musicrecord> GetMusicrecordsCollection() => _musicrecords;
    }
}
