using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web_API.Data.Context;
using Web_API.Modals;

namespace Web_API.Repositories.PatternRepository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Context _context;
        public Repository(Context context) 
        {
            _context = context;
        }
        public async Task<bool> Create(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                var isSaved = _context.SaveChanges() > 0 ? true : false;

                if (!isSaved)
                    throw new Exception("Entity couldn't be saved");

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);

                if (entity == null)
                    throw new Exception("There isn't an entity with this id number");

                _context.Set<T>().Remove(entity);

                var isDeleted = _context.SaveChanges() > 0 ? true : false;

                if (!isDeleted)
                    throw new Exception("Entity couldn't be deleted");

                return isDeleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);

                if (result == null)
                    throw new Exception("There is not entity with this id number");

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Update(T entity, int id)
        {
            try
            {
                var oldEntity = await _context.Set<T>().FindAsync(id);
                
                if (oldEntity == null)
                    throw new Exception("Entity couldn't be found");

                _context.ChangeTracker.Clear();
                _context.Set<T>().Update(entity);

                var isSaved = _context.SaveChanges() > 0 ? true : false;

                if (!isSaved)
                    throw new Exception("Employee couldn't be updated");

                return isSaved;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
