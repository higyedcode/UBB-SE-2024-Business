using Celebration_Of_Capitalism___The_Finale.Models;

namespace Celebration_Of_Capitalism___The_Finale.Services.Interfaces
{
    public interface ICOCFavouriteProductService
    {
        int AddFavouriteProduct(COCFavouriteProduct favouriteProduct);
        bool DeleteFavouriteProductFromUser(COCFavouriteProduct favouriteProduct);
        IEnumerable<COCFavouriteProduct> GetAllFavouriteProducts();
        IEnumerable<COCFavouriteProduct> GetAllFavouriteProductsOfUser(int userId);
        IEnumerable<int> GetAllUserIdsWhoMarkedProductAsFavourite(int productId);
        COCFavouriteProduct? GetFavouriteProduct(int id);
    }
}
