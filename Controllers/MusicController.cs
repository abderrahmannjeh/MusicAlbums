using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mouzikty.Models;
using mouzikty.Models.Repository;

namespace mouzikty.Controllers
{
    public class MusicController : Controller
    {

        private readonly IMusicRepository _musicRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IArtisteRepository _artisteRepository; 
        public MusicController(IMusicRepository musicRepository , IAlbumRepository albumRepository, IArtisteRepository artisteRepository)
        {

            _musicRepository = musicRepository;
            _albumRepository = albumRepository;
            _artisteRepository = artisteRepository;
        
        }
        // GET: Music
        public ActionResult Index()
        {
            ViewBag.Albums = new SelectList(_albumRepository.GetAll(), "AlbumId", "Name");
            IList<Music> musics = _musicRepository.GetAll();
          /*  foreach(Music m in musics)
            {
               m.Album = _albumRepository.GetById(m.AlbumId);
                m.Artiste = _artisteRepository.GetById(m.ArtisteID);
            }*/
            return View(musics);
        }

        // GET: Music/Details/5
        public ActionResult Details(int id)
        {
            Music m = _musicRepository.GetById(id);

            return View(m);
        }

        // GET: Music/Create
        public ActionResult Create()
        {
            ViewBag.Albums = new SelectList(_albumRepository.GetAll(), "AlbumId", "Name");
            ViewBag.Artistes = new SelectList(_artisteRepository.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Music/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Music model)
        {
            try
            {
                
              var x =  _musicRepository.Add(model);
                return RedirectToAction(nameof(Index));


            }
            catch 
            {
                return View();
            }
            
        }

        // GET: Music/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Albums = new SelectList(_albumRepository.GetAll(), "AlbumId", "Name");
            ViewBag.Artistes = new SelectList(_artisteRepository.GetAll(), "Id", "Name");
            Music m = _musicRepository.GetById(id);
            
            return View(m);
        }

        // POST: Music/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Music m)
        {
            _musicRepository.Edit(m);
            return RedirectToAction(nameof(Index));

        }

        // GET: Music/Delete/5
        public ActionResult Delete(int id)
        {
            Music m = _musicRepository.GetById(id);
            if(m!=null)
            {
                
                return View(m);
            }
            return View();

        }

        // POST: Music/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Music m)
        {
            try
            {

                _musicRepository.Delete(m.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Search(string name, int? AlbumId)
        {
            var result = _musicRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = _musicRepository.FindByName(name);
            else
            if (AlbumId != null)
                result = _musicRepository.GetMusicByAlbumId(AlbumId);
            ViewBag.Albums = new SelectList(_musicRepository.GetAll(), "AlbumId", "Name");
            return View("Index", result);
        }
    }
}