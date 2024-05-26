namespace Backend.Models
{
    public class ReviewClass
    {
        private string user;
        private string review;

        public ReviewClass(string user, string review)
        {
            this.user = user;
            this.review = review;
        }

        public ReviewClass()
        {
            this.user = string.Empty;
            this.review = string.Empty;
        }

        public string User
        {
            get { return this.user; }
            set { this.user = value; }
        }

        public string Review
        {
            get { return this.review; }
            set { this.review = value; }
        }

        public override string ToString()
        {
            return $"--> {this.review} (left from {this.user})\n";
        }
    }
}
