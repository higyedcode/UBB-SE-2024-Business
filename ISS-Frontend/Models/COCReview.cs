namespace Celebration_Of_Capitalism___The_Finale.Models
{
    public class COCReview
    {
        public int Id { get; set; } = 0;
        public int ProductId { get; set; } = 0;
        public int UserId { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;
    }
}
