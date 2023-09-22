using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class InsertMovie
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public string Image { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

    }
    public class UpdateMovie
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public float? Rating { get; set; }
        public string? Image { get; set; }

    }
}
