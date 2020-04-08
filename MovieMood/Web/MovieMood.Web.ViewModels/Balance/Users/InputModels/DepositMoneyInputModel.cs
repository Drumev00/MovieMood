namespace MovieMood.Web.ViewModels.Balance.Users.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class DepositMoneyInputModel
    {
        [Required]
        [Range(1, 150)]
        public decimal Money { get; set; }
    }
}
