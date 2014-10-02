using Albums.Models;
using Albums.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Albums.Services.Controllers
{
    public class ArtistController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.Data.Artists.All().Select(ArtistModel.FromArtist);

            return Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var course = this.Data.Artists
                             .All()
                             .Where(s => s.Id == id)
                             .Select(ArtistModel.FromArtist)
                             .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Artist does not exists - invalid id");
            }
            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newArtist = new Artist()
            {
                Name = artist.Name,
                Country = artist.Country,
                DateOfBirth = artist.DateOfBirth
            };

            this.Data.Artists.Add(newArtist);
            this.Data.SaveChanges();

            return this.Ok(newArtist);
        }
        
        [HttpPut]
        public IHttpActionResult Update(int id, ArtistModel artist)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingSong = this.Data.Artists.All().FirstOrDefault(s => s.Id == id);

            if (existingSong == null)
            {
                return this.BadRequest("Such artist does not exists!");
            }

            if (artist.Country != null)
            {
                existingSong.Country = artist.Country;
            }
            if (artist.Name != null)
            {
                existingSong.Name = artist.Name;
            }
            if (artist.DateOfBirth != null)
            {
                existingSong.DateOfBirth = artist.DateOfBirth;
            }

            this.Data.SaveChanges();
            artist.Id = id;
            return this.Ok(artist);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var artist = this.Data.Artists.All().FirstOrDefault(s => s.Id == id);
            if (artist == null)
            {
                return this.BadRequest("Such artist does not exist");
            }

            this.Data.SaveChanges();
            this.Data.Artists.Delete(artist);
            this.Data.SaveChanges();

            return this.Ok(artist);
        }
    }
}