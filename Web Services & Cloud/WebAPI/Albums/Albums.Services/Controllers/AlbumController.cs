using Albums.Models;
using Albums.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Albums.Services.Controllers
{
    public class AlbumController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.Data.Albums.All().Select(AlbumModel.FromAlbum);

            return Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var course = this.Data.Albums
                             .All()
                             .Where(s => s.Id == id)
                             .Select(AlbumModel.FromAlbum)
                             .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Album does not exists - invalid id");
            }
            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newCourse = new Album()
            {
                Producer = album.Producer,
                Title = album.Title,
                Year = album.Year
            };

            this.Data.Albums.Add(newCourse);
            this.Data.SaveChanges();

            return this.Ok(newCourse);
        }
        
        [HttpPut]
        public IHttpActionResult Update(int id, AlbumModel album)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingAlbum = this.Data.Albums.All().FirstOrDefault(s => s.Id == id);

            if (existingAlbum == null)
            {
                return this.BadRequest("Such album does not exists!");
            }

            if (album.Title != null)
            {
                existingAlbum.Title = album.Title;
            }
           
            existingAlbum.Year = album.Year;
            
            if (album.Producer != null)
            {
                existingAlbum.Producer = album.Producer;
            }
            
            this.Data.SaveChanges();
            album.Id = id;
            return this.Ok(album);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = this.Data.Albums.All().FirstOrDefault(s => s.Id == id);
            if (album == null)
            {
                return this.BadRequest("Such album does not exist");
            }

            this.Data.SaveChanges();
            this.Data.Albums.Delete(album);
            this.Data.SaveChanges();

            return this.Ok(album);
        }
    }
}