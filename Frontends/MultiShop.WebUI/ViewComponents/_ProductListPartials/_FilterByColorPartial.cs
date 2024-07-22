using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents._ProductListPartials
{
    public class _FilterByColorPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
