namespace FinalProjectMVC
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Fragrance>> GetFragrances(string sTerm = "", int categoryId = 0);
        Task<IEnumerable<Category>> Categories();
    }
}