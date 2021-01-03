using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.Models
{
    public class Music
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public DateTime DateCreation { get; set; }
        public int  ArtisteID { get; set; }
        public  Artiste Artiste { get; set; }
        public  int AlbumId { get; set; }
        public  Album Album { get; set; }
        
    }
}
