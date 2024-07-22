using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI._LayoutPartials.ViewComponents
{
    public class _FooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
