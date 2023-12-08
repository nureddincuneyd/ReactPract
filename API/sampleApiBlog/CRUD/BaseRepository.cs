using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using sampleApiBlog.Data;
using sampleApiBlog.Models;

namespace sampleApiBlog.CRUD
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity 
    {
        private AppDbContext _context;
        protected DbSet<T> _table;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public T Add(T entity)
        {
            try
            {
                entity.CREATEDATE = DateTime.Now;
                entity.ISACTIVE = true;
                entity.ID = 0;
                _table.Add(entity);
                _context.SaveChanges();
                
                return entity;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                return _table.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetByPk(long id)
        {
            try
            {
                T item = _table.FirstOrDefault(z => z.ID == id);
                if (item != null)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Remove(long id)
        {
            try
            {
                T item = GetByPk(id);
                if (item != null)
                {
                    _table.Remove(item);
                    _context.SaveChanges();
                    return item;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            

        }

        public T Update(T entity)
        {
            try
            {
                _table.Update(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
