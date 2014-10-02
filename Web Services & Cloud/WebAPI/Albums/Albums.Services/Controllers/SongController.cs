using System;
using System.Linq;
using System.Web.Http;
using Albums.Services.Models;
using Albums.Models;

namespace Albums.Services.Controllers
{
    public class SongController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult All()
        {
            var songs = this.Data.Songs.All().Select(SongModel.FromSong);

            return Ok(songs);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var course = this.Data.Songs
                             .All()
                             .Where(s => s.Id == id)
                             .Select(SongModel.FromSong)
                             .FirstOrDefault();

            if (course == null)
            {
                return this.BadRequest("Song does not exists - invalid id");
            }
            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult Create(SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newCourse = new Song()
            {
                Title = song.Title,
                Genre = song.Genre,
                Year = song.Year
            };

            this.Data.Songs.Add(newCourse);
            this.Data.SaveChanges();

            return this.Ok(newCourse);
        }
        
        [HttpPut]
        public IHttpActionResult Update(int id, SongModel song)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var existingSong = this.Data.Songs.All().FirstOrDefault(s => s.Id == id);

            if (existingSong == null)
            {
                return this.BadRequest("Such song does not exists!");
            }

            if (song.Title != null)
            {
                existingSong.Title = song.Title;
            }
            
            existingSong.Year = song.Year;
            
            if (song.Genre != null)
            {
                existingSong.Genre = song.Genre;
            }

            this.Data.SaveChanges();
            song.Id = id;
            return this.Ok(song);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var song = this.Data.Songs.All().FirstOrDefault(s => s.Id == id);
            if (song == null)
            {
                return this.BadRequest("Such song does not exist");
            }

            this.Data.SaveChanges();
            this.Data.Songs.Delete(song);
            this.Data.SaveChanges();

            return this.Ok(song);
        }
    }
}