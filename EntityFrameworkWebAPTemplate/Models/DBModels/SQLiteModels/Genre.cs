﻿using System;
using System.Collections.Generic;

namespace EntityFrameworkWebAPTemplate.Models.DBModels.SQLiteModels
{
    public partial class Genre
    {
        public Genre()
        {
            Track = new HashSet<Track>();
        }

        public long GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Track> Track { get; set; }
    }
}
