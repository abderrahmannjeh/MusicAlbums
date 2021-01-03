using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.Models.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly MusicContext _context;
        public AlbumRepository(MusicContext context)
        {
            this._context = context;
        }
        public void Add(Album a)
        {
            this._context.Albums.Add(a);
            this._context.SaveChanges();

        }

        public int AlbumCount(int AlbumId)
        {
            return this._context.Albums.Count();


        }

        public void Delete(int AlbumId)
        {
            Album Album = this._context.Albums.Find(AlbumId);
            if (Album != null)
            {
                this._context.Albums.Remove(Album);
                this._context.SaveChanges();
            }
        }

        public Album Edit(Album a)
        {
            Album Album = this._context.Albums.Find(a.AlbumId);
            if (Album != null)
            {
                Album.Name = a.Name;
                Album.Image = a.Image;
                Album.Type = a.Type;

                this._context.SaveChanges();
                
            }
            return Album;
        }

        public IList<Album> GetAll()
        {
            return this._context.Albums.ToList();
        }

        public Album GetById(int id)
        {
            return this._context.Albums.Find(id);
        }
    }
}

