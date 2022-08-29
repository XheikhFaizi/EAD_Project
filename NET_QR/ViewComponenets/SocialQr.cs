using Microsoft.AspNetCore.Mvc;

namespace NET_QR.ViewComponenets
{
    public class SocialQr : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default");
        }
    }
}
