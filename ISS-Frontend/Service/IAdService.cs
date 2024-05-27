﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ISS_Frontend.Entity;

namespace ISS_Frontend.Service
{
    public interface IAdService
    {
        public void AddAd(Ad adToAdd);
        public List<Ad> GetAdsThatAreNotInAdSet();
        public void UpdateAd(Ad adToUpdate);
        public Ad GetAdByName(string adName);
        public void DeleteAd(Ad adToDelete);
        public List<Ad> GetAdsFromAdSet(string adSetId);
    }
}
