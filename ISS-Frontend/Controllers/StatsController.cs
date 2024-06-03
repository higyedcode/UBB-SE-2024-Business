using Microsoft.AspNetCore.Mvc;

namespace ISS_Frontend.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetEngagementData()
        {
            var data = new
            {
                labels = Enumerable.Range(0, 24).Select(i => i.ToString()).ToArray(),
                values = GetRandomData(24, 10)
            };
            return Json(data);
        }

        public JsonResult GetClicksData()
        {
            var data = new
            {
                labels = Enumerable.Range(0, 24).Select(i => i.ToString()).ToArray(),
                values = GetRandomData(24, 1000)
            };
            return Json(data);
        }

        public JsonResult GetImpressionsData()
        {
            var clicks = GetRandomData(24, 1000);
            var data = new
            {
                labels = Enumerable.Range(0, 24).Select(i => i.ToString()).ToArray(),
                values = clicks.Select(c => new Random().Next((int)c, 10000)).ToArray()
            };
            return Json(data);
        }

        public JsonResult GetCTRData()
        {
            var clicks = GetRandomData(24, 1000);
            var impressions = clicks.Select(c => new Random().Next((int)c, 10000)).ToArray();
            var ctr = clicks.Zip(impressions, (click, impression) => click / impression).ToArray();
            var data = new
            {
                labels = Enumerable.Range(0, 24).Select(i => i.ToString()).ToArray(),
                values = ctr
            };
            return Json(data);
        }

        public JsonResult GetPurchasesData()
        {
            var clicks = GetRandomData(24, 1000);
            var data = new
            {
                labels = Enumerable.Range(0, 24).Select(i => i.ToString()).ToArray(),
                values = clicks.Select(c => new Random().Next((int)c / 10, (int)c / 2)).ToArray()
            };
            return Json(data);
        }

        public JsonResult GetEngagementTypesData()
        {
            var clicks = GetRandomData(24, 1000);
            var purchases = clicks.Select(c => new Random().Next((int)c / 10, (int)c / 2)).ToArray();
            var data = new
            {
                labels = new[] { "Users that clicked the ad and bought", "Users that only clicked the ad" },
                values = new[] { purchases.Sum(), clicks.Sum() }
            };
            return Json(data);
        }

        private static double[] GetRandomData(int length, int max)
        {
            Random random = new Random();
            return Enumerable.Range(0, length).Select(i => (double)random.Next(max)).ToArray();
        }
    }
}
