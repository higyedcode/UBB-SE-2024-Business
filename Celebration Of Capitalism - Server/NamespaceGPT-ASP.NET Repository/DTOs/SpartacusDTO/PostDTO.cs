namespace NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public int NumberOfLikes { get; set; }
        public DateTime CreationDate { get; set; }
        public string ImagePath { get; set; }
        public string Caption { get; set; }
        public int BusinessId { get; set; }
    }
}
