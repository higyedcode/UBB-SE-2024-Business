// <copyright file="FAQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RestApi_ISS.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using Backend.Models;
    using RestApi_ISS.Entity;
    using RestApi_ISS.Repository;

    public class FAQService : IFAQService
    {
        // private static readonly FAQService InstanceValue = new ();
        private readonly List<string> topics = new ();
       /* private readonly FAQfAQRepository fAQRepository;*/
        private readonly List<FAQ> submittedQuestions;
        private IFAQRepository fAQRepository;
        public FAQService(IFAQRepository fAQRepository)
        {
            this.fAQRepository = fAQRepository;
            this.submittedQuestions = new ();
        }
       /* public static FAQService Instance
        {
            get { return InstanceValue; }
        }*/

        public List<FAQ> GetAllFAQs()
        {
            return this.fAQRepository.GetFAQList();
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

        public void AddSubmittedQuestion(FAQ newQuestion)
        {
            this.submittedQuestions.Add(newQuestion);
            this.fAQRepository.AddFAQ(newQuestion);
        }

        public void DeleteFAQ(int id)
        {
            FAQ faqToDelete = this.fAQRepository.GetFAQList().FirstOrDefault(f => f.Id == id);
            if (faqToDelete != null)
            {
                this.fAQRepository.DeleteFAQ(faqToDelete); // Delete from the database
            }
        }

        public List<FAQ> GetSubmittedQuestions()
        {
            return this.submittedQuestions;
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
    }
}
