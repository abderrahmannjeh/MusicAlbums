using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mouzikty.ViewModels
{
    public class ArtisteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public IFormFile Photo { get; set; }
    }
}
