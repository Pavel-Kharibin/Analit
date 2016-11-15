using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Analit.Data.Bases
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected RepositoryBase()
        {
            DataContext = new AnalitDataContext();
            DbSet = DataContext.Set<T>();
        }

        public DbSet<T> DbSet { get; set; }
        public AnalitDataContext DataContext { get; set; }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            var entity = await DbSet.FindAsync(id);

            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            DbSet.Add(entity);
            await DataContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
            await DataContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task DeleteAsync(object id)
        {
            var entityToDelete = await DbSet.FindAsync(id);

            if (DataContext.Entry(entityToDelete).State == EntityState.Detached)
                DbSet.Attach(entityToDelete);

            DbSet.Remove(entityToDelete);

            await DataContext.SaveChangesAsync();
        }
    }
}