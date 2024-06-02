namespace Celebration_Of_Capitalism___The_Finale.Models
{
    public class FavouriteProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public Product? Product { get; set; }
    }
}
