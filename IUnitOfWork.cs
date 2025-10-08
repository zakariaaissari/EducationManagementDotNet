namespace isgasoir
{
    public interface IUnitOfWork:IDisposable
    {
        IBaseRepository<Studant,long> studantRepository { get; }
        IBaseRepository<Product,long> productRepository { get; }
        IBaseRepository<Semestre, long> semestreRepository { get; }
        IBaseRepository<Module, long> moduleRepository { get; }
        int complete();
    }
}
