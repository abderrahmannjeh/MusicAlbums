using Microsoft.AspNetCore.Http;
using mouzikty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.ViewModels
{
    public class AlbumCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IFormFile Image { get; set; }

        public string Type { get; set; }

        public ICollection<Music> Musics { get; set; }
    }
}
