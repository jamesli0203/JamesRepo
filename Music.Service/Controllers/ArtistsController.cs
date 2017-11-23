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
    [Route("api/Artists")]
    public class ArtistsController : Controller
    {
        private readonly ArtistRepository _repo;

        public ArtistsController(ArtistRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Artists
        [HttpGet]
        public IEnumerable<Artist> GetArtists()
        {
            return _repo.GetAll();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public IActionResult GetArtist([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artist = _repo.SearchFor(m => m.Id == id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        [HttpPut("{id}")]
        public IActionResult PutArtist([FromRoute] long id, [FromBody] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id)
            {
                return BadRequest();
            }

            try
            {
                _repo.Update(artist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(id))
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

        // POST: api/Artists
        [HttpPost]
        public IActionResult PostArtist([FromBody] Artist artist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repo.Insert(artist);
            

            return CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public IActionResult DeleteArtist([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var artist =  _repo.SearchFor(m => m.Id == id);
            if (artist == null)
            {
                return NotFound();
            }

            _repo.Delete(artist.First());
            

            return Ok(artist);
        }

        private bool ArtistExists(long id)
        {
            return _repo.GetAll().Any(e => e.Id == id);
        }
    }
}