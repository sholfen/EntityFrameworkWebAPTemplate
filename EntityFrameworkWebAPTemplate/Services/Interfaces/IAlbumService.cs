using EntityFrameworkWebAPTemplate.Models.DBModels.SQLiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkWebAPTemplate.Services.Interfaces
{
    public interface IAlbumService
    {
        List<Album> GetAll();
    }
}
