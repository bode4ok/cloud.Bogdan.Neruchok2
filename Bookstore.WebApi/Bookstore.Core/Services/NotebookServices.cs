using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Bookstore.Core
{
    public class NotebookServices : INotebookServices
    {
        private readonly IMongoCollection<Notebook> _notebooks;

        public NotebookServices(IDbClient dbClient)
        {
            _notebooks = dbClient.GetNotebooksCollection();
        }

        public Notebook AddNotebook(Notebook notebook)
        {
            _notebooks.InsertOne(notebook); 
            return notebook;
        }

        public void DeleteNotebook(string id)
        {
            _notebooks.DeleteOne(notebook => notebook.Id == id);
        }

        public Notebook GetNotebook(string id) => _notebooks.Find(notebook => notebook.Id == id).First();

        public List<Notebook> GetNotebooks() => _notebooks.Find(notebook => true).ToList();

        public Notebook UpdateNotebook(Notebook notebook)
        {
            GetNotebook(notebook.Id);
            _notebooks.ReplaceOne(b => b.Id == notebook.Id, notebook);
            return notebook;
        }
    }
}
