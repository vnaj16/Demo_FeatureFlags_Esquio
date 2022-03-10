using Esquio.AspNetCore.Endpoints.Metadata;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Demo_FeatureFlags_Esquio.Controllers
{
    [FeatureFilter(Name = FeatureFlags.NewTopFeatureModule)]
    public class NewTopFeatureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
