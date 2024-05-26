using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss
{
    public static class Constants
    {
        public static readonly List<string> DOMAIN_OF_ACTIVITIES = ["Food", "Clothing", "Electronics"];
        public static readonly List<string> AUTHORIZING_INSTITUTIONS = ["ANAF", "ITM", "ISU"];
        public static readonly Dictionary<string, int> NUMBER_OF_CAMPAIGNS_FOR_SUBSCRIPTION = new Dictionary<string, int>
        {
            { "Basic", 2 },
            { "Silver", 3 },
            { "Gold", 5 }
        };
        public static readonly Dictionary<string, int> CRAZY_PAYMENTS = new Dictionary<string, int>
        {
            { "KFC Wings", 2 },
            { "Bananas", 1 },
            { "Grams of Gold", 5 }
        };
    }
}
