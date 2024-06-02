namespace NamespaceGPT_ASP.NET_Repository.DTOs.SpartacusDTO
{
    public class CommentDTO
    {
        public int Id
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }
        public string Content
        {
            get;
            set;
        }

        public DateTime DateOfCreation
        {
            get;
            set;
        }

        public DateTime DateOfUpdate
        {
            get;
            set;
        }
        public int PostId { get; set; }
    }
}
