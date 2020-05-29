using EntityFrameworkWebAPTemplate.DBTools.Repository.Interfaces;
using EntityFrameworkWebAPTemplate.DBTools.Tools;
using EntityFrameworkWebAPTemplate.Models.DBModels;
using EntityFrameworkWebAPTemplate.Models.DBModels.SQLiteModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.DBTools.Repository.Implements
{
    public class AlbumRepository : BaseRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(IEnumerable<DbContext> dbContexts) : base(dbContexts, DatabaseTools.DBName.main.ToString())
        {

        }
    }
}
