namespace RestApi_ISS.Entity
{
    public class FAQ
    {
        private int id;
        private string question;
        private string answer;
        private string topic;

        /// <summary>
        /// Initializes a new instance of the <see cref="FAQ"/> class.
        /// </summary>
        public FAQ()
        {
            this.question = string.Empty;
            this.answer = string.Empty;
            this.topic = string.Empty;
        }

        public FAQ(string question, string answer, string topic)
        {
            this.question = question;
            this.answer = answer;
            this.topic = topic;
        }

        public FAQ(int id, string question, string answer, string topic)
        {
            this.id = id;
            this.question = question;
            this.answer = answer;
            this.topic = topic;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Question
        {
            get { return this.question; }
            set { this.question = value; }
        }

        public string Answer
        {
            get { return this.answer; }
            set { this.answer = value; }
        }

        public string Topic
        {
            get { return this.topic; }
            set { this.topic = value; }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.question}";
        }
    }
}
