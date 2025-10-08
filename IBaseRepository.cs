using System.Linq.Expressions;

namespace isgasoir
{
    public interface IBaseRepository<T, K> where T : class
    {
        public T add(T entity);
        public void remove(T entity);
        public T update(T entity);
        public T? findById(K key);
        public IEnumerable<T> findByCretiria(Expression<Func<T,bool>> critiria);
        public List<T> findAll();
        
        IQueryable<T> Query {  get; }

    }
}
