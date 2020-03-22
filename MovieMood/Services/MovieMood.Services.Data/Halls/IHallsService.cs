namespace MovieMood.Services.Data.Halls
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHallsService
    {
        Task CreateAsync(string name);

        IEnumerable<T> All<T>();

        T GetDetailsById<T>(int id);

        Task SoftDeleteHallAsync(int hallId);
    }
}
