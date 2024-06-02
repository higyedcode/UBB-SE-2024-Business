namespace NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO
{
    public class SpartacusReviewDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int AdminCommentId { get; set; }
        public int BusinessId { get; set; }
    }
}
