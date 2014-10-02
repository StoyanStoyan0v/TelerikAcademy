using Albums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Albums.Services.Models
{
    public class SongModel
    {
        public static Expression<Func<Song, SongModel>> FromSong
        {
            get
            {
                return s => new SongModel()
                {
                    Title = s.Title,
                    Genre = s.Genre,
                    Year = s.Year
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

        public int ArtistId { get; set; }
    }
}