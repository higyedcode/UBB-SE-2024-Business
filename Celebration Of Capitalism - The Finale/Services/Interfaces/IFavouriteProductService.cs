using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services.Interfaces
{
    public interface IFavouriteProductService
    {
        int AddFavouriteProduct(FavouriteProduct favouriteProduct);
        bool DeleteFavouriteProductFromUser(FavouriteProduct favouriteProduct);
        IEnumerable<FavouriteProduct> GetAllFavouriteProducts();
        IEnumerable<FavouriteProduct> GetAllFavouriteProductsOfUser(int userId);
        IEnumerable<int> GetAllUserIdsWhoMarkedProductAsFavourite(int productId);
        FavouriteProduct? GetFavouriteProduct(int id);
    }
}
