using Microsoft.EntityFrameworkCore;
using RestWithASPNET10.Models.Base;
using RestWithASPNET10.Models.Context;
using RestWithASPNET10.Repositories.Interface;

namespace RestWithASPNET10.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
		private readonly MSSQLContext _context;
        private DbSet<T> _dataset;

		public GenericRepository(MSSQLContext context)
		{
			_context = context;
			_dataset = _context.Set<T>();
		}

		public List<T> FindAll()
        {
			return _dataset.ToList();
		}

        public T FindById(long id)
        {
			return _dataset.Find(id);
		}

        public T Create(T item)
        {
			_context.Add(item);
			_context.SaveChanges();
			return item;
		}

        public void Delete(long id)
        {
			var existingItem = FindById(id);
			if (existingItem == null)
				throw new KeyNotFoundException($"O registro com ID {id} não foi encontrado.");
			_context.Remove(existingItem);
			_context.SaveChanges();
			return;
		}

        public T Update(T item)
        {
			var existingItem = FindById(item.Id);
			if (existingItem == null)
				throw new KeyNotFoundException($"O registro com ID {item.Id} não foi encontrado.");

			_context.Entry(existingItem).CurrentValues.SetValues(item);
			_context.SaveChanges();
			return item;
		}

        public bool Exists(long id)
        {
            return _dataset.Any(e => e.Id == id);
		}

    }
}
