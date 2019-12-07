using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace web.Services
{
    /// <summary>
    /// Gọi pageview Component để hiển thị paging
    /// </summary>
    public class PagerViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
        {
            return Task.FromResult((IViewComponentResult)View("myView", result));
        }
    }
}
