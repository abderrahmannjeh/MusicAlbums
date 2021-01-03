using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mouzikty.Models;

namespace mouzikty.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions<MusicContext> options):base(options)
        {

        }

       public DbSet<Music> Musics { get; set; }
        public DbSet<Artiste> Artists { get; set; }
        public  DbSet<Album> Albums { get; set; }

    }
}
