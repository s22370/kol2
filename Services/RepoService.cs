using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Entities;
using kol2.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace kol2.Services
{
    public class RepoService : IRepoService
    {
        private readonly RepositoryContext _repository;
        public RepoService(RepositoryContext repository)
        {
            _repository = repository;
        }
        public Task CreateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<Musician> Delete(int IdMusician)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Album> GetAlbumById(int IdAlbum)
        {
            return _repository.Album.Where(e=>e.IdAlbum==IdAlbum).
            Include(e=>e.Track);
        }

        public IQueryable<Musician> GetMusicianById(int IdMusician)
        {
           return _repository.Musician.Where(e => e.IdMusician == IdMusician);
        }
        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}