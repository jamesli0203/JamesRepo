using Microsoft.EntityFrameworkCore;
using Music.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Service.Repositories
{
    public class AlbumRepository : Repository<Album>
    {
        public AlbumRepository(MusicContext dataContext)
            : base(dataContext)
        {
        }
    }
}
