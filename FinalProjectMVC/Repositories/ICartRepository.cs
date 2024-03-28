namespace FinalProjectMVC
{
    public interface ICartRepository
    {
        Task<int> AddItem(int fragranceId, int qty);
        Task<int> RemoveItem(int fragranceId);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout();

    }
}