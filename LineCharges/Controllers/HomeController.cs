using LineCharges.Models;
using System.Web.Mvc;

namespace LineCharges.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ChargeForm());
        }

        [HttpPost]
        public ActionResult Index(ChargeForm chargeForm)
        {
            if (!ModelState.IsValid)
            {
                //error
                return View(new ChargeForm(chargeForm));
            }

            chargeForm.SaveEntry();
            ModelState.Clear();
            return View(new ChargeForm(chargeForm));
        }

        [HttpGet]
        public ActionResult Javascript()
        {
            return View();
        }
    }
}