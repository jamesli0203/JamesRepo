using Microsoft.EntityFrameworkCore;
using Music.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Service.Data
{
    public class MusicDataSeed
    {
        private MusicContext _context;

        public MusicDataSeed(MusicContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (!_context.Artists.Any())
            {
                
                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.AddRange(_artists);
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Artist ON;");
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Artist OFF");
                    transaction.Commit();
                }
               // _context.SaveChanges();
            }
           
            if (!_context.Albums.Any())
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.AddRange(_album);
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Album ON;");
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Album OFF");
                    transaction.Commit();
                }
            }

            if (!_context.Songs.Any())
            {

                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.AddRange(_song);
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Song ON;");
                    _context.SaveChanges();
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Song OFF");
                    transaction.Commit();
                }
            }
        }

        List<Artist> _artists = new List<Artist>
        {
            new Artist()
            {
                Id  =1,
               Created = DateTime.Today,
               LastModified = DateTime.Today,
                Name ="Muse"
            },
            new Artist()
            {
                Id  =2,
               Created = DateTime.Today,
               LastModified = DateTime.Today,
                Name ="AC-DC"
            },
            new Artist()
            {
                Id  =3,
               Created = DateTime.Today,
               LastModified = DateTime.Today,
                Name ="Def Leppard"
            },
            new Artist()
            {
                Id  =4,
               Created = DateTime.Today,
               LastModified = DateTime.Today,
                Name ="Van Halen"
            },
            new Artist()
            {
                Id  =5,
               Created = DateTime.Today,
               LastModified = DateTime.Today,
                Name ="Duran Duran"
            }
        };

        List<Album> _album = new List<Album>
        {
            new Album()
            {
                Id =1,
                Created = DateTime.Today,
                LastModified = DateTime.Today,
                YearReleases = 2015,
                Name ="Drones",
                ArtistId =1
            },
             new Album()
            {
                Id =2,
                Created = DateTime.Today,
                LastModified = DateTime.Today,
                YearReleases = 2001,
                Name ="Origin of Symmetry",
                ArtistId =1
            }
        };

        List<Song> _song = new List<Song>
        {
            new Song()
            {
                Id =1,
                Created =DateTime.Today,
                LastModified =DateTime.Today,
                Track =1,
                Name ="Dead Inside",
                AlbumId =1
            },
            new Song()
            {
                Id =2,
                Created =DateTime.Today,
                LastModified =DateTime.Today,
                Track =2,
                Name ="Drill Sargeant",
                AlbumId =1
            },
            new Song()
            {
                Id =3,
                Created =DateTime.Today,
                LastModified =DateTime.Today,
                Track =3,
                Name ="Psycho",
                AlbumId =1
            },
            new Song()
            {
                Id =4,
                Created =DateTime.Today,
                LastModified =DateTime.Today,
                Track =4,
                Name ="Reapers",
                AlbumId =1
            },
            new Song()
            {
                Id =5,
                Created =DateTime.Today,
                LastModified =DateTime.Today,
                Track =5,
                Name ="Defector",
                AlbumId =1
            }

        };
    }
}
//insert into song(id, album_id, track, name) values(1, 1, 1, 'Dead Inside')
//insert into song(id, album_id, track, name) values(2, 1, 2, 'Drill Sargeant')
//insert into song(id, album_id, track, name) values(3, 1, 3, 'Psycho')
//insert into song(id, album_id, track, name) values(4, 1, 4, 'Mercy')
//insert into song(id, album_id, track, name) values(5, 1, 5, 'Reapers')
//insert into song(id, album_id, track, name) values(6, 1, 6, 'The Handler')
//insert into song(id, album_id, track, name) values(7, 1, 7, 'JFK')
//insert into song(id, album_id, track, name) values(8, 1, 8, 'Defector')
//insert into song(id, album_id, track, name) values(9, 1, 9, 'Revolt')
//insert into song(id, album_id, track, name) values(10, 1, 10, 'Aftermath')
//insert into song(id, album_id, track, name) values(11, 1, 11, 'The Globalist')
//insert into song(id, album_id, track, name) values(12, 1, 12, 'Drones'