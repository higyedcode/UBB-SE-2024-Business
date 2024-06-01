using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public class FAQService : IFAQService
    {
        private static readonly FAQService InstanceValue = new();
        private readonly List<string> topics = new();
        private readonly HttpClient httpClient;
        private readonly List<FAQ> submittedQuestions;

        public static FAQService Instance
        {
            get { return InstanceValue; }
        }

        public FAQService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.submittedQuestions = new();
        }

        public FAQService()
        {
        }

        public void AddSubmittedQuestion(FAQ newQuestion)
        {
            var response = httpClient.PostAsJsonAsync("api/FAQ/AddSubmittedQuestion", newQuestion).Result;
            this.submittedQuestions.Add(newQuestion);
        }

        public List<FAQ> FilterFAQs(List<FAQ> faqList, string searchText)
        {
            searchText = searchText.ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                return faqList
                    .Where(faq =>
                        faq.Question.Contains(searchText, StringComparison.CurrentCultureIgnoreCase) ||
                        faq.Topic.Equals(searchText, StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            }

            return faqList;
        }

        public List<FAQ> GetAllFAQs()
        {
            var response = httpClient.GetAsync("api/FAQ/GetAllFAQs").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<List<FAQ>>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<FAQ>();
            }
            else
            {
                throw new Exception($"Failed to retrieve FAQs: {response.ReasonPhrase}");
            }
        }

        public FAQ GetFAQById(int id)
        {
            var response = httpClient.GetAsync($"api/FAQ/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadFromJsonAsync<FAQ>().Result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            else
            {
                throw new Exception($"Failed to retrieve FAQ: {response.ReasonPhrase}");
            }
        }

        public void UpdateFAQ(int id, FAQ updatedFAQ)
        {
            var response = httpClient.PutAsJsonAsync($"api/FAQ/{id}", updatedFAQ).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to update FAQ: {response.ReasonPhrase}");
            }
        }


        public List<FAQ> GetSubmittedQuestions()
        {
            return this.submittedQuestions;

        }
        public List<string> GetTopics()
        {
            List<FAQ> faqList = this.GetAllFAQs();
            foreach (FAQ faqItem in faqList)
            {
                if (!this.topics.Contains(faqItem.Topic))
                {
                    this.topics.Add(faqItem.Topic);
                }
            }

            return this.topics;
        }
        public void DeleteFAQ(int id)
        {
            var response = httpClient.DeleteAsync($"api/FAQ/{id}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to delete FAQ: {response.ReasonPhrase}");
            }
        }
    }
}
