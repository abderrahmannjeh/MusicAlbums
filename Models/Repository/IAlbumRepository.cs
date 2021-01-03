using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.Models.Repository
{
    public interface IAlbumRepository
    {
        IList<Album> GetAll();
        Album GetById(int id);
        void Add(Album a);
        Album Edit(Album a);
        void Delete(int AlbumId);
        int AlbumCount(int AlbumId);
    }
}
