using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Service.Models;
using Music.Service.Repositories;

namespace Music.Service.Controllers
{
    [Produces("application/json")]
    [Route("api/Songs")]
    public class SongsController : Controller
    {
        private readonly SongRepository _repo;

        public SongsController(SongRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Songs
        [HttpGet]
        public IEnumerable<Song> GetSongs()
        {
            return _repo.GetAll();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public IActionResult GetSong([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = _repo.SearchFor(m => m.Id == id);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public IActionResult PutSong([FromRoute] long id, [FromBody] Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.Id)
            {
                return BadRequest();
            }

            try
            {
                _repo.Update(song);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        public IActionResult PostSong([FromBody] Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Insert(song);

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSong([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var song = _repo.SearchFor(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            _repo.Delete(song.First());
            

            return Ok(song);
        }

        private bool SongExists(long id)
        {
            return _repo.GetAll().Any(e => e.Id == id);
        }
    }
}