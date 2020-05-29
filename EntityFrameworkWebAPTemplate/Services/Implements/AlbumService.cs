using EntityFrameworkWebAPTemplate.DBTools.Repository.Interfaces;
using EntityFrameworkWebAPTemplate.Models.DBModels;
using EntityFrameworkWebAPTemplate.Models.DBModels.SQLiteModels;
using EntityFrameworkWebAPTemplate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.Services.Implements
{
    public class AlbumService : IAlbumService
    {
        private IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public List<Album> GetAll()
        {
            var query = _albumRepository.Query();
            return query.ToList();
        }
    }
}
