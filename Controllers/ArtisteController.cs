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
    public class ArtisteController : Controller
    {
        IArtisteRepository _artisteRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public ArtisteController(IArtisteRepository artisteRepository, IWebHostEnvironment hostingEnvironment)
        {
            this._artisteRepository = artisteRepository;
            this.hostingEnvironment = hostingEnvironment;

        }
        // GET: Artiste
        public ActionResult Index()
        {
            var artistes = this._artisteRepository.GetAll();
            return View(artistes);
        }

        // GET: Artiste/Details/5
        public ActionResult Details(int id)
        {
            Artiste artiste = _artisteRepository.GetById(id);
            return View(artiste);
        }

        // GET: Artiste/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artiste/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtisteViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                // If the Photo property on the incoming model object is not null, then the user
                // has selected an image to upload.
                if (model.Photo != null)
                {
                    // The image must be uploaded to the images folder in wwwroot
                    // To get the path of the wwwroot folder we are using the inject
                    // HostingEnvironment service provided by ASP.NET Core

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");

                    // To make sure the file name is unique we are appending a new
                    // GUID value and an underscore to the file name

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Use CopyTo() method provided by IFormFile interface to
                    // copy the file to wwwroot/images folder

                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Artiste artiste = new Artiste();
                artiste.Id = 0;
                artiste.Name = model.Name;
                artiste.Image = uniqueFileName;
                this._artisteRepository.Add(artiste);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Artiste/Edit/5
        public ActionResult Edit(int id)
        {
            Artiste artiste = this._artisteRepository.GetById(id);
            ArticteEditModel artisteModel = new ArticteEditModel();
            artisteModel.Id = artiste.Id;
            artisteModel.Name = artiste.Name;
            artisteModel.ExistingPhotoPath = artiste.Image;
            
            return View(artisteModel);
        }

        // POST: Artiste/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ArticteEditModel model)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the employee being edited from the database
                Artiste artiste = _artisteRepository.GetById(model.Id);
                // Update the employee object with the data in the model object
                artiste.Name = model.Name;
                
                

                // If the user wants to change the photo, a new photo will be
                // uploaded and the Photo property on the model object receives
                // the uploaded photo. If the Photo property is null, user did
                // not upload a new photo and keeps his existing photo
                if (model.Photo != null)
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
                    artiste.Image = ProcessUploadedFile(model);
                }

                // Call update method on the repository service passing it the
                // employee object to update the data in the database table
                Artiste updatedArtiste = _artisteRepository.Edit(artiste);
                if (updatedArtiste != null)
                    return RedirectToAction("index");
                else
                    return NotFound();
            }

            return View(model);
        }

        // GET: Artiste/Delete/5
        public ActionResult Delete(int id)
        {
            Artiste artiste = _artisteRepository.GetById(id);
            if(artiste!= null)
            {

              
                return View(artiste);
            }
            return View();
        }

        // POST: Artiste/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Artiste a)
        {
            try
            {
                _artisteRepository.Delete(a.Id);
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [NonAction]
        private string ProcessUploadedFile(ArticteEditModel model)
        {
            string uniqueFileName = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}