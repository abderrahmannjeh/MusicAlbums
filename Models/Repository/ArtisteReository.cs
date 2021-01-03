using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.Models.Repository
{
    public class ArtisteReository : IArtisteRepository
    {
        private readonly MusicContext _context;
        public ArtisteReository(MusicContext context)
        {
            this._context = context;
        }
        public void Add(Artiste a)
        {
            this._context.Artists.Add(a);
            this._context.SaveChanges();

        }

        public int ArtisteCount(int ArtisteId)
        {
            return this._context.Artists.Count();


        }

        public void Delete(int ArtisteId)
        {
            Artiste artiste = this._context.Artists.Find(ArtisteId);
            if (artiste != null)
            {
                this._context.Artists.Remove(artiste);
                this._context.SaveChanges();
            }
        }

        public Artiste Edit(Artiste a)
        {
            Artiste artiste = this._context.Artists.Find(a.Id);
            if (artiste != null)
            {
                artiste.Name = a.Name;
                artiste.Image = a.Image;
                this._context.SaveChanges();
                return artiste;
            }
            return null;
        }

        public IList<Artiste> GetAll()
        {
           return this._context.Artists.ToList();
        }

        public Artiste GetById(int id)
        {
            return this._context.Artists.Find(id);
        }
    }
}
