using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents._LayoutPartials
{
    public class _LayoutLeftSideBarPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
