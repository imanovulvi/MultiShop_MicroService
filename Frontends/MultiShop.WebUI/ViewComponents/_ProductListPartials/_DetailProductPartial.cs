using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _DetailProductPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
