using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.ViewComponents._LayoutPartials
{
    public class _LayoutHeaderPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
