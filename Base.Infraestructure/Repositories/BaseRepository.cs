using Base.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class BaseRepository<T>(ApplicationDbContext context) : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context = context;

        public Task<T> AddAsync(T entity)
        {
            _context.Add(entity);
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            return Task.CompletedTask;
        }

        public async Task<int> GetTotalCount()
        {
            return await _context.Set<T>().CountAsync();
        }
    }
}
