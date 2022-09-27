using Microsoft.AspNetCore.Mvc;

namespace NET_QR.ViewComponenets
{
    public class FactoryTextQr : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default");
        }
    }
}
