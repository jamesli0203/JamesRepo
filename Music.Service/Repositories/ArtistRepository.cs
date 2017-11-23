using Microsoft.EntityFrameworkCore;
using Music.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Music.Service.Repositories
{
    public class ArtistRepository : Repository<Artist>
    {
        
        public ArtistRepository(MusicContext dataContext)
            : base(dataContext)
        {
        }
    }
}
