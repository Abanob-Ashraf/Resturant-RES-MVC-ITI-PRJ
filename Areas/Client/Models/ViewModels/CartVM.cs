namespace Resturant_RES_MVC_ITI_PRJ.Areas.Client.Models.ViewModels
{
	public class CartVM
	{
		public int PaymentMethodID { get; set; }
		public List<CartDishesVM> cartDishes { get; set; }
	}
}
