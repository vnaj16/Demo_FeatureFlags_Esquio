using Esquio.AspNetCore.Endpoints.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Demo_FeatureFlags_Esquio.Controllers
{
    [FeatureFilter(Name = FeatureFlags.SalesModule)]
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
