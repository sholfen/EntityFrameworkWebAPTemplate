using System;
using System.Collections.Generic;

namespace EntityFrameworkWebAPTemplate.Models.DBModels.SQLiteModels
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public long PlaylistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}
