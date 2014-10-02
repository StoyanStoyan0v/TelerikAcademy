using Albums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Albums.Services.Models
{
    public class AlbumModel
    {
        public static Expression<Func<Album, AlbumModel>> FromAlbum
        {
            get
            {
                return a => new AlbumModel()
                {
                    Producer = a.Producer,
                    Title = a.Title,
                    Year = a.Year,
                    Artists = a.Artists.Select(ar => ar.Name)
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Producer { get; set; }

        public IEnumerable<string> Artists { get; set; }
    }
}