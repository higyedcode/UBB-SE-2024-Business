using NamespaceGPT.Data.DTOs;
using NamespaceGPT.Data.Models;
using NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO;
using NamespaceGPT_ASP.NET_Repository.Models.SpartacusModels;

namespace NamespaceGPT_ASP.NET_Repository.Utils
{
    public static class BaseToDTOConverters
    {
        public static AdRecommendationDTO Converter_AdRecommendationToDTO(AdRecommendation adRecommendation) => new AdRecommendationDTO { Id = adRecommendation.Id, ListingId = adRecommendation.ListingId };
        public static UserDTO Converter_UserToDTO(User user) => new UserDTO { Id = user.Id, Username = user.Username, Password = user.Password };
        public static ProductDTO Converter_ProductToDTO(Product product) => new ProductDTO { Id = product.Id, Name = product.Name, Brand = product.Brand, Category = product.Category, Description = product.Description, ImageURL = product.ImageURL, Attributes = product.Attributes };
        public static ReviewDTO Converter_ReviewToDTO(Review review) => new ReviewDTO { Id = review.Id, UserId = review.UserId, ProductId = review.ProductId, Description = review.Description, Title = review.Title, Rating = review.Rating };
        public static BackInStockAlertDTO Converter_BackInStockAlertToDTO(BackInStockAlert backInStockAlert) => new BackInStockAlertDTO { Id = backInStockAlert.Id, MarketplaceId = backInStockAlert.MarketplaceId, ProductId = backInStockAlert.ProductId, UserId = backInStockAlert.UserId };
        public static NewProductAlertDTO Converter_NewProductAlertToDTO(NewProductAlert newProductAlert) => new NewProductAlertDTO { Id = newProductAlert.Id, ProductId = newProductAlert.ProductId, UserId = newProductAlert.UserId };
        public static PriceDropAlertDTO Converter_PriceDropAlertToDTO(PriceDropAlert priceDropAlert) => new PriceDropAlertDTO { Id = priceDropAlert.Id, UserId = priceDropAlert.UserId, ProductId = priceDropAlert.ProductId, OldPrice = priceDropAlert.OldPrice, NewPrice = priceDropAlert.NewPrice };
        public static SaleDTO Converter_SaleToDTO(Sale sale) => new SaleDTO { Id = sale.Id, UserId = sale.UserId, ListingId = sale.ListingId };
        public static UserActivityDTO Converter_UserActivityToDTO(UserActivity userActivity) => new UserActivityDTO { Id = userActivity.Id, UserId = userActivity.UserId, ActionType = userActivity.ActionType };
        public static ListingDTO Converter_ListingToDTO(Listing listing) => new ListingDTO { Id = listing.Id, MarketplaceId = listing.Id, Price = listing.Price, ProductId = listing.ProductId };
        public static FavouriteProductDTO Converter_FavouriteProductToDTO(FavouriteProduct favouriteProduct) => new FavouriteProductDTO { Id = favouriteProduct.Id, UserId = favouriteProduct.UserId, ProductId = favouriteProduct.ProductId };
        public static MarketplaceDTO Converter_MarketplaceToDTO(Marketplace marketplace) => new MarketplaceDTO { Id = marketplace.Id, Country = marketplace.Country, MarketplaceName = marketplace.MarketplaceName, WebsiteURL = marketplace.WebsiteURL };
        public static CommentDTO Converter_CommentToDTO(Comment comment) => new CommentDTO
        {
            Id = comment.Id,
            Username = comment.Username,
            Content = comment.Content,
            DateOfCreation = comment.DateOfCreation,
            DateOfUpdate = comment.DateOfUpdate
        };

        public static SpartacusReviewDTO Converter_SpartacusReviewToDTO(SpartacusReview spartacusReview) => new SpartacusReviewDTO
        {
            Id = spartacusReview.Id,
            UserName = spartacusReview.UserName,
            Rating = spartacusReview.Rating,
            Comment = spartacusReview.Comment,
            Title = spartacusReview.Title,
            ImagePath = spartacusReview.ImagePath,
            DateOfCreation = spartacusReview.DateOfCreation,
            AdminCommentId = spartacusReview.AdminCommentId
        };
        public static AccountDTO Converter_AccountToDTO(Account account) => new AccountDTO
        {
            Id = account.Id,
            Username = account.Username,
            Password = account.Password,
            Firstname = account.Firstname,
            Lastname = account.Lastname,
            Email = account.Email,
            Birthday = account.Birthday,
            Gender = account.Gender
        };

        public static BussinessDTO Converter_BusinessToDTO(Business business) => new BussinessDTO
        {
            Id = business.Id,
            Name = business.Name,
            Description = business.Description,
            Category = business.Category,
            Logo = business.Logo,
            Banner = business.Banner,
            LogoFileName = business.LogoFileName,
            BannerShort = business.BannerShort,
            PhoneNumber = business.PhoneNumber,
            Email = business.Email,
            Website = business.Website,
            Address = business.Address,
            CreatedAt = business.CreatedAt
        };

        public static FAQDTO Converter_FAQToDTO(FAQ faq) => new FAQDTO
        {
            Id = faq.Id,
            Question = faq.Question,
            Answer = faq.Answer
        };

        public static PostDTO Converter_PostToDTO(Post post) => new PostDTO
        {
            Id = post.Id,
            NumberOfLikes = post.NumberOfLikes,
            CreationDate = post.CreationDate,
            ImagePath = post.ImagePath,
            Caption = post.Caption
        };
    }
}