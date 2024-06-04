using NamespaceGPT.Data.DTOs;
using NamespaceGPT.Data.Models;
using NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO;
using NamespaceGPT_ASP.NET_Repository.Models.SpartacusModels;

namespace NamespaceGPT_ASP.NET_Repository.Utils
{
    public static class DTOToBaseConverters
    {
        public static AdRecommendation Converter_DTOToAdRecommendation(AdRecommendationDTO adRecommendationDTO) => new AdRecommendation { Id = adRecommendationDTO.Id, ListingId = adRecommendationDTO.ListingId };
        public static User Converter_DTOToUser(UserDTO userDTO) => new User { Id = userDTO.Id, Username = userDTO.Username, Password = userDTO.Password };
        public static Product Converter_DTOToProduct(ProductDTO productDTO) => new Product { Id = productDTO.Id, Name = productDTO.Name, Brand = productDTO.Brand, Category = productDTO.Category, Description = productDTO.Description, ImageURL = productDTO.ImageURL, Attributes = productDTO.Attributes };
        public static Review Converter_DTOToReview(ReviewDTO reviewDTO) => new Review { Id = reviewDTO.Id, UserId = reviewDTO.UserId, ProductId = reviewDTO.ProductId, Description = reviewDTO.Description, Title = reviewDTO.Title, Rating = reviewDTO.Rating };
        public static BackInStockAlert Converter_DTOToBackInStockAlert(BackInStockAlertDTO backInStockAlertDTO) => new BackInStockAlert { Id = backInStockAlertDTO.Id, MarketplaceId = backInStockAlertDTO.MarketplaceId, ProductId = backInStockAlertDTO.ProductId, UserId = backInStockAlertDTO.UserId };
        public static NewProductAlert Converter_DTOToNewProductAlert(NewProductAlertDTO newProductAlertDTO) => new NewProductAlert { Id = newProductAlertDTO.Id, ProductId = newProductAlertDTO.ProductId, UserId = newProductAlertDTO.UserId };
        public static PriceDropAlert Converter_DTOToPriceDropAlert(PriceDropAlertDTO priceDropAlertDTO) => new PriceDropAlert { Id = priceDropAlertDTO.Id, UserId = priceDropAlertDTO.UserId, ProductId = priceDropAlertDTO.ProductId, OldPrice = priceDropAlertDTO.OldPrice, NewPrice = priceDropAlertDTO.NewPrice };
        public static Sale Converter_DTOToSale(SaleDTO saleDTO) => new Sale { Id = saleDTO.Id, UserId = saleDTO.UserId, ListingId = saleDTO.ListingId };
        public static UserActivity Converter_DTOToUserActivity(UserActivityDTO userActivityDTO) => new UserActivity { Id = userActivityDTO.Id, UserId = userActivityDTO.UserId, ActionType = userActivityDTO.ActionType };
        public static Listing Converter_DTOToListing(ListingDTO listingDTO) => new Listing { Id = listingDTO.Id, MarketplaceId = listingDTO.Id, Price = listingDTO.Price, ProductId = listingDTO.ProductId };
        public static FavouriteProduct Converter_DTOToFavouriteProduct(FavouriteProductDTO favouriteProductDTO) => new FavouriteProduct { Id = favouriteProductDTO.Id, UserId = favouriteProductDTO.UserId, ProductId = favouriteProductDTO.ProductId };
        public static Marketplace Converter_DTOToMarketplace(MarketplaceDTO marketplaceDTO) => new Marketplace { Id = marketplaceDTO.Id, Country = marketplaceDTO.Country, MarketplaceName = marketplaceDTO.MarketplaceName, WebsiteURL = marketplaceDTO.WebsiteURL };
        public static FAQ Converter_DTOToFAQ(FAQDTO faqDTO) => new FAQ
        {
            Id = faqDTO.Id,
            Question = faqDTO.Question,
            Answer = faqDTO.Answer,
            BusinessId = faqDTO.BusinessId
        };
        public static SpartacusReview Converter_DTOToSpartacusReview(SpartacusReviewDTO spartacusReviewDTO) => new SpartacusReview
        {
            Id = spartacusReviewDTO.Id,
            UserName = spartacusReviewDTO.UserName,
            Rating = spartacusReviewDTO.Rating,
            Comment = spartacusReviewDTO.Comment,
            Title = spartacusReviewDTO.Title,
            ImagePath = spartacusReviewDTO.ImagePath,
            DateOfCreation = spartacusReviewDTO.DateOfCreation,
            AdminCommentId = spartacusReviewDTO.AdminCommentId,
            BusinessId = spartacusReviewDTO.BusinessId
        };
        public static Post Converter_DTOToPost(PostDTO postDTO) => new Post
        {
            Id = postDTO.Id,
            NumberOfLikes = postDTO.NumberOfLikes,
            CreationDate = postDTO.CreationDate,
            ImagePath = postDTO.ImagePath,
            Caption = postDTO.Caption,
            BusinessId = postDTO.BusinessId
        };
        public static Business Converter_DTOToBusiness(BussinessDTO businessDTO) => new Business
        {
            Id = businessDTO.Id,
            Name = businessDTO.Name,
            Description = businessDTO.Description,
            Category = businessDTO.Category,
            LogoFileName = businessDTO.LogoFileName,
            Logo = businessDTO.Logo,
            BannerShort = businessDTO.BannerShort,
            Banner = businessDTO.Banner,
            PhoneNumber = businessDTO.PhoneNumber,
            Email = businessDTO.Email,
            Website = businessDTO.Website,
            Address = businessDTO.Address,
            CreatedAt = businessDTO.CreatedAt,
            AccountId = businessDTO.AccountId
        };
        public static Account Converter_DTOToAccount(AccountDTO accountDTO) => new Account
        {
            Id = accountDTO.Id,
            Username = accountDTO.Username,
            Password = accountDTO.Password,
            Firstname = accountDTO.Firstname,
            Lastname = accountDTO.Lastname,
            Email = accountDTO.Email,
            Birthday = accountDTO.Birthday,
            Gender = accountDTO.Gender
        };
        public static Comment Converter_DTOToComment(CommentDTO commentDTO) => new Comment
        {
            Id = commentDTO.Id,
            Username = commentDTO.Username,
            Content = commentDTO.Content,
            DateOfCreation = commentDTO.DateOfCreation,
            DateOfUpdate = commentDTO.DateOfUpdate,
            PostId = commentDTO.PostId
        };
    }
}
