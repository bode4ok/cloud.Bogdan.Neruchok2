using Bookstore.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotebooksController : ControllerBase
    {
        private readonly INotebookServices _notebookServices;

        public NotebooksController(INotebookServices notebookServices)
        {
            _notebookServices = notebookServices;
        }

        [HttpGet]
        public IActionResult GetNotebooks()
        {
            return Ok(_notebookServices.GetNotebooks());
        }

        [HttpGet("{id}", Name = "GetNotebook")]
        public IActionResult GetNotebook(string id)
        {
            return Ok(_notebookServices.GetNotebook(id));
        }

        [HttpPost]
        public IActionResult AddBook(Notebook notebook)
        {
            _notebookServices.AddNotebook(notebook);
            return CreatedAtRoute("GetNotebook", new { id = notebook.Id}, notebook);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteNotebook(string id)
        {
            _notebookServices.DeleteNotebook(id);
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateNotebook(Notebook notebook)
        {
            return Ok(_notebookServices.UpdateNotebook(notebook));
        }
    }
}
