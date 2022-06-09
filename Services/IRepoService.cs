using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Entities.Models;

namespace kol2.Services
{
    public interface IRepoService
    {
        IQueryable<Album> GetAlbumById(int IdAlbum);
    
         Task SaveChangesAsync();
          IQueryable<Musician> GetMusicianById(int IdMusician);
          IQueryable<Musician> Delete(int IdMusician);
         Task CreateAsync<T>(T entity) where T : class;
    }
}