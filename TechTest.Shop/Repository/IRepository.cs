namespace TechTest.Shop.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetByName(string name);
    }
}
