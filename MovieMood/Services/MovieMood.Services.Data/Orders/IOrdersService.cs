namespace MovieMood.Services.Data.Orders
{
    using System.Threading.Tasks;

    using MovieMood.Web.ViewModels.Orders.Users.InputModels;

    public interface IOrdersService
    {
        Task BuyAsync(OrderTicketsInputModel model);
    }
}
