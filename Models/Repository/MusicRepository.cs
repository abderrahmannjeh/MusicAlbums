using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.Models.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MusicContext _context;
        public MusicRepository(MusicContext context)
        {
            this._context = context;
        }
        public Music  Add(Music a)
        {
             this._context.Musics.Add(a);
            this._context.SaveChanges();
            return a;

        }

        public int MusicCount(int MusicId)
        {
            return this._context.Musics.Count();


        }

        public void Delete(int MusicId)
        {
            Music Music = this._context.Musics.Find(MusicId);
            if (Music != null)
            {
                this._context.Musics.Remove(Music);
                this._context.SaveChanges();
            }
        }

        public void Edit(Music m)
        {
            Music Music = this._context.Musics.Find(m.Id);
            if (Music != null)
            {
                Music.Name = m.Name;
                Music.Link = m.Link;
                Music.DateCreation = m.DateCreation;
                Music.Artiste = m.Artiste;
                Music.AlbumId = m.AlbumId;
                Music.ArtisteID = m.ArtisteID;
                
                this._context.SaveChanges();
            }
        }

        public IList<Music> GetAll()
        {
            return this._context.Musics.Include(m => m.Album).Include(m => m.Artiste).ToList();
        }

        public Music GetById(int id)
        {
            return this._context.Musics.Include(m => m.Album).Include(m => m.Artiste).FirstOrDefault();
        }

        public IList<Music> FindByName(string name)
        {
            return _context.Musics.Where(m => m.Name.Contains(name)).Include(m => m.Album).Include(m => m.Artiste).ToList();
        }

        public IList<Music> GetMusicByAlbumId(int? albumId)
        {
            return _context.Musics.Where(m => m.AlbumId == albumId).Include(m => m.Album).Include(m => m.Artiste).ToList();
        }
    }
}

