using Albums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Albums.Services.Models
{
    public class ArtistModel
    {
        public static Expression<Func<Artist, ArtistModel>> FromArtist
        {
            get
            {
                return a => new ArtistModel()
                {
                    Name = a.Name,
                    Country = a.Country,
                    DateOfBirth = a.DateOfBirth,
                    Songs = a.Songs.Select(s => s.Title)
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int AlbumId { get; set; }

        public IEnumerable<string> Songs { get; set; }
    }
}