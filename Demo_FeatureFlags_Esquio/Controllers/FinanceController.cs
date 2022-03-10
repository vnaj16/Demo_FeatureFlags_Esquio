using Esquio.AspNetCore.Endpoints.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace Demo_FeatureFlags_Esquio.Controllers
{
    [FeatureFilter(Name = FeatureFlags.FinanceModule)]
    public class FinanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [FeatureFilter(Name = FeatureFlags.FinanceModule_PrivateData)]
        public IActionResult PrivateData() {
            return View();
        }
    }
}
