using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mouzikty.Models;
using mouzikty.Models.Repository;
using mouzikty.ViewModels;

namespace mouzikty.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumRepository _albumRepository;

        private readonly IWebHostEnvironment hostingEnvironment;
        public AlbumController(IAlbumRepository albumRepository, IWebHostEnvironment hostingEnvironment)
        {
            _albumRepository = albumRepository;
            this.hostingEnvironment = hostingEnvironment;

        }
        // GET: Music
        public ActionResult Index()
        {
            IList<Album> albums = _albumRepository.GetAll();
            return View(albums);
        }

        // GET: Music/Details/5
        public ActionResult Details(int id)
        {
            Album album = _albumRepository.GetById(id);

            return View(album);
        }

        // GET: Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Music/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AlbumCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Image != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    // To make sure the file name is unique we are appending a new
                    // GUID value and an underscore to the file name

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder

                    model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Album album = new Album();
                album.AlbumId = 0;
                album.Name = model.Name;
                album.Type = model.Type;
                album.Image = uniqueFileName;
                this._albumRepository.Add(album);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Music/Edit/5
        public ActionResult Edit(int id)
        {
            Album album = _albumRepository.GetById(id);
            AlbumEditViewModel albumModel = new AlbumEditViewModel();
            albumModel.Name = album.Name;
            albumModel.Musics = album.Musics;
            albumModel.ExistingPhotoPath = album.Image;
            albumModel.Id = album.AlbumId;
            albumModel.Type = album.Type;

            return View(albumModel);
        }

        // POST: Music/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AlbumEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                Album album = _albumRepository.GetById(model.Id);
                // Update the employee object with the data in the model object
                album.AlbumId = model.Id;
                album.Name = model.Name;
                album.Type = model.Type;



                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.Image != null)
                {
                    // If a new photo is uploaded, the existing photo must be
                    // deleted. So check if there is an existing photo and delete
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    // Save the new photo in wwwroot/images folder and update
                    // PhotoPath property of the employee object which will be
                    // eventually saved in the database
                    album.Image = ProcessUploadedFile(model);
                }

                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                Album updatedArtiste = _albumRepository.Edit(album);
                if (updatedArtiste != null)
                    return RedirectToAction("index");
                else
                    return NotFound();
            }

            return View(model);
        }

        // GET: Music/Delete/5
        public ActionResult Delete(int id)
        {
            Album album = _albumRepository.GetById(id);
            if(album != null)
            {
                
                return View(album);

            }
            return View();
        }

        // POST: Music/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Album a)
        {
            try
            {
                // TODO: Add delete logic here
                _albumRepository.Delete(a.AlbumId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private string ProcessUploadedFile(AlbumEditViewModel model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
