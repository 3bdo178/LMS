using LMS.Data;
using LMS.Repo.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repo.Implementation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext Context;
        public GenericRepo(AppDbContext context)
        {
            Context = context;
        }

        

        public void Create(T entity)
        {
           Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return Context.Set<T>().Find(Id);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Update(entity);
        }
    }
}
