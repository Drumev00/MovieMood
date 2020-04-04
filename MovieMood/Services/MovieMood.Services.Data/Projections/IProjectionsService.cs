namespace MovieMood.Services.Data.Projections
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MovieMood.Web.ViewModels.Projections.Administration.InputModels;

    public interface IProjectionsService
    {
        Task CreateAsync(CreateProjectionInputModel model);

        IEnumerable<T> All<T>();

        T GetById<T>(string projectionId);

        Task DeleteAsync(string projectionId);
    }
}
