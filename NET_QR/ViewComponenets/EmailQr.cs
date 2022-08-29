using Microsoft.AspNetCore.Mvc;

namespace NET_QR.ViewComponenets
{
    public class EmailQr : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Default");
        }
    }
}
