using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents._OrderPartials
{
    public class _OrderTotalPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
