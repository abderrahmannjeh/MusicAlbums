using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.Models.Repository
{
   public interface IMusicRepository
    {
        IList<Music> GetAll();
        Music GetById(int id);
        Music Add(Music m);
        void Edit(Music m);
        void Delete(int MusicId);
        int MusicCount(int MusicId);
        IList<Music> FindByName(string name);
        IList<Music> GetMusicByAlbumId(int? albumId);
    }
}
