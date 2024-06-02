using NamespaceGPT.Data.DTOs;
using NamespaceGPT.Data.Models;
using NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO;
using NamespaceGPT_ASP.NET_Repository.Models.SpartacusModels;

namespace NamespaceGPT_ASP.NET_Repository.Utils
{
    public static class DTOToBaseConverters
    {
        public static COCAdRecommendation Converter_DTOToAdRecommendation(AdRecommendationDTO adRecommendationDTO) => new COCAdRecommendation { Id = adRecommendationDTO.Id, ListingId = adRecommendationDTO.ListingId };
        public static COCUser Converter_DTOToUser(UserDTO userDTO) => new COCUser { Id = userDTO.Id, Username = userDTO.Username, Password = userDTO.Password };
        public static COCProduct Converter_DTOToProduct(ProductDTO productDTO) => new COCProduct { Id = productDTO.Id, Name = productDTO.Name, Brand = productDTO.Brand, Category = productDTO.Category, Description = productDTO.Description, ImageURL = productDTO.ImageURL, Attributes = productDTO.Attributes };
        public static COCReview Converter_DTOToReview(ReviewDTO reviewDTO) => new COCReview { Id = reviewDTO.Id, UserId = reviewDTO.UserId, ProductId = reviewDTO.ProductId, Description = reviewDTO.Description, Title = reviewDTO.Title, Rating = reviewDTO.Rating };
        public static COCBackInStockAlert Converter_DTOToBackInStockAlert(BackInStockAlertDTO backInStockAlertDTO) => new COCBackInStockAlert { Id = backInStockAlertDTO.Id, MarketplaceId = backInStockAlertDTO.MarketplaceId, ProductId = backInStockAlertDTO.ProductId, UserId = backInStockAlertDTO.UserId };
        public static COCNewProductAlert Converter_DTOToNewProductAlert(NewProductAlertDTO newProductAlertDTO) => new COCNewProductAlert { Id = newProductAlertDTO.Id, ProductId = newProductAlertDTO.ProductId, UserId = newProductAlertDTO.UserId };
        public static COCPriceDropAlert Converter_DTOToPriceDropAlert(PriceDropAlertDTO priceDropAlertDTO) => new COCPriceDropAlert { Id = priceDropAlertDTO.Id, UserId = priceDropAlertDTO.UserId, ProductId = priceDropAlertDTO.ProductId, OldPrice = priceDropAlertDTO.OldPrice, NewPrice = priceDropAlertDTO.NewPrice };
        public static COCSale Converter_DTOToSale(SaleDTO saleDTO) => new COCSale { Id = saleDTO.Id, UserId = saleDTO.UserId, ListingId = saleDTO.ListingId };
        public static COCUserActivity Converter_DTOToUserActivity(UserActivityDTO userActivityDTO) => new COCUserActivity { Id = userActivityDTO.Id, UserId = userActivityDTO.UserId, ActionType = userActivityDTO.ActionType };
        public static COCListing Converter_DTOToListing(ListingDTO listingDTO) => new COCListing { Id = listingDTO.Id, MarketplaceId = listingDTO.Id, Price = listingDTO.Price, ProductId = listingDTO.ProductId };
        public static COCFavouriteProduct Converter_DTOToFavouriteProduct(FavouriteProductDTO favouriteProductDTO) => new COCFavouriteProduct { Id = favouriteProductDTO.Id, UserId = favouriteProductDTO.UserId, ProductId = favouriteProductDTO.ProductId };
        public static COCMarketplace Converter_DTOToMarketplace(MarketplaceDTO marketplaceDTO) => new COCMarketplace { Id = marketplaceDTO.Id, Country = marketplaceDTO.Country, MarketplaceName = marketplaceDTO.MarketplaceName, WebsiteURL = marketplaceDTO.WebsiteURL };
        public static SpartacusFAQ Converter_DTOToFAQ(FAQDTO faqDTO) => new SpartacusFAQ
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
        public static SpartacusPost Converter_DTOToPost(PostDTO postDTO) => new SpartacusPost
        {
            Id = postDTO.Id,
            NumberOfLikes = postDTO.NumberOfLikes,
            CreationDate = postDTO.CreationDate,
            ImagePath = postDTO.ImagePath,
            Caption = postDTO.Caption,
            BusinessId = postDTO.BusinessId
        };
        public static SpartacusBusiness Converter_DTOToBusiness(BussinessDTO businessDTO) => new SpartacusBusiness
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
            CreatedAt = businessDTO.CreatedAt
        };
        public static SpartacusAccount Converter_DTOToAccount(AccountDTO accountDTO) => new SpartacusAccount
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
        public static SpartacusComment Converter_DTOToComment(CommentDTO commentDTO) => new SpartacusComment
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
