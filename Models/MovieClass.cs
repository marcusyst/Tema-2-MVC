using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tema_2___Movies.Models
{
    public class MovieClass
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string genre { get; set; }
        public string releasedate { get; set; }
        public string agerating { get; set; }
        public string movierating { get; set; }
    }
}
