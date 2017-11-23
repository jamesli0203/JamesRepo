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
    [Route("api/Albums")]
    public class AlbumsController : Controller
    {
        private readonly AlbumRepository _repo;

        public AlbumsController(AlbumRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Albums
        [HttpGet]
        public IEnumerable<Album> GetAlbums()
        {
            return _repo.GetAll();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public IActionResult GetAlbum([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var album = _repo.SearchFor(m => m.Id == id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/Albums/5
        [HttpPut("{id}")]
        public IActionResult PutAlbum([FromRoute] long id, [FromBody] Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != album.Id)
            {
                return BadRequest();
            }

            try
            {
                _repo.Update(album); ;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlbumExists(id))
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

        // POST: api/Albums
        [HttpPost]
        public IActionResult PostAlbum([FromBody] Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Insert(album);
            return CreatedAtAction("GetAlbum", new { id = album.Id }, album);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAlbum([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var album = _repo.SearchFor(m => m.Id == id);
           
            if (album == null)
            {
                return NotFound();
            }

            _repo.Delete(album.First());
           

            return Ok(album);
        }

        private bool AlbumExists(long id)
        {
            return _repo.GetAll().Any(e => e.Id == id);
        }
    }
}