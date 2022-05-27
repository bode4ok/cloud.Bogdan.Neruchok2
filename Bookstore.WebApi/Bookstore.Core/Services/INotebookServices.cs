using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Core
{
    public interface INotebookServices
    {
        List<Notebook> GetNotebooks();
        Notebook GetNotebook(string id);
        Notebook AddNotebook(Notebook notebook);

        void DeleteNotebook(string id);
        Notebook UpdateNotebook(Notebook notebook);
    }
}
