using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _ShopProductPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
