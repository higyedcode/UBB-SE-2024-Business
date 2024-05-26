// <copyright file="IFAQService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RestApi_ISS.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using RestApi_ISS.Entity;

    public interface IFAQService
    {
        List<FAQ> GetAllFAQs();

        void AddSubmittedQuestion(FAQ newQuestion);

        List<FAQ> GetSubmittedQuestions();

        List<FAQ> FilterFAQs(List<FAQ> faqList, string searchText);
    }
}
