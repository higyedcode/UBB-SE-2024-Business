using System.Collections.Generic;
using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public interface IFAQService
    {
        List<FAQ> GetAllFAQs();

        FAQ GetFAQById(int id);

        void AddSubmittedQuestion(FAQ newQuestion);

        List<FAQ> GetSubmittedQuestions();

        List<FAQ> FilterFAQs(List<FAQ> faqList, string searchText);

        void UpdateFAQ(int id, FAQ updatedFAQ);

        void DeleteFAQ(int id);
    }
}
