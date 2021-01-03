using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.Models.Repository
{
  public  interface IArtisteRepository
    {
        IList<Artiste> GetAll();
        Artiste GetById(int id);
        void Add(Artiste a);
        Artiste Edit(Artiste a);
        void Delete(int ArtisteId);
        int ArtisteCount(int ArtisteId);
    }
}
