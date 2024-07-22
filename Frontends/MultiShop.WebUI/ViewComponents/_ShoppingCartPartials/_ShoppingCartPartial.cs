using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents._ShoppingCartPartials
{
    public class _ShoppingCartPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
