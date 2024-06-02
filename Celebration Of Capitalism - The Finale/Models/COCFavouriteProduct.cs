namespace Celebration_Of_Capitalism___The_Finale.Models
{
    public class COCFavouriteProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public COCProduct? Product { get; set; }
    }
}
