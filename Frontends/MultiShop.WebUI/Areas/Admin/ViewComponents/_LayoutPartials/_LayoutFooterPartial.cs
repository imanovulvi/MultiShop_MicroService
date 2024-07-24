using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents._LayoutPartials
{
    public class _LayoutFooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
        return View();
        }
    }
}
