namespace MovieMood.Services.Data.Orders
{
    using System.Threading.Tasks;

    using MovieMood.Web.ViewModels.Orders.Users.InputModels;

    public interface IOrdersService
    {
        Task BuyAsync(OrderTicketsInputModel model);

        T GetOrder<T>(string projectionId, string userId, int ticketsCount);

        int GetHallId(string orderId);

        string GetProjectionId(string orderId);
    }
}
