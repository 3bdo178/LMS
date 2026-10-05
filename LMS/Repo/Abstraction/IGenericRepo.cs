namespace LMS.Repo.Abstraction
{
    public interface IGenericRepo<T> where T : class
    {
        public List<T> GetAll();
        public T GetById(int Id);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
