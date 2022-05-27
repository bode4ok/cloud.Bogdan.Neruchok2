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
    public class MusicrecordsController : ControllerBase
    {
        private readonly IMusicrecordServices _musicrecordServices;

        public MusicrecordsController(IMusicrecordServices musicrecordServices)
        {
            _musicrecordServices = musicrecordServices;
        }

        [HttpGet]
        public IActionResult GetMusicrecords()
        {
            return Ok(_musicrecordServices.GetMusicrecords());
        }

        [HttpGet("{id}", Name = "GetMusicrecord")]
        public IActionResult GetMusicrecord(string id)
        {
            return Ok(_musicrecordServices.GetMusicrecord(id));
        }

        [HttpPost]
        public IActionResult AddMusicrecord(Musicrecord musicrecord)
        {
            _musicrecordServices.AddMusicrecord(musicrecord);
            return CreatedAtRoute("GetMusicrecord", new { id = musicrecord.Id}, musicrecord);
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteMusicrecord(string id)
        {
            _musicrecordServices.DeleteMusicrecord(id); 
            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateMusicrecord(Musicrecord musicrecord)
        {
            return Ok(_musicrecordServices.UpdateMusicrecord(musicrecord));
        }
    }
}
