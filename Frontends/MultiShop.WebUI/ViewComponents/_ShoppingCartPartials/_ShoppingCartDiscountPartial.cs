using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents._ShoppingCartPartials
{
    public class _ShoppingCartDiscountPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
