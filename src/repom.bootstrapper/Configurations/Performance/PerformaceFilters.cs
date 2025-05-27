using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace repom.bootstrapper.Configurations.Performance;

public class PerformaceFilters : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var clock = new Stopwatch();
        clock.Start();

        var resultContext = await next();
        clock.Stop();

        if (resultContext.Result is ObjectResult view)
        {
            var item = view.Value;
            if (item.GetType().GetProperty("TimerProcessing") != null)
                item.GetType().GetProperty("TimerProcessing")
                    ?.SetValue(item, Convert.ToInt32(clock.Elapsed.TotalMilliseconds));
            view.Value = item;
        }
    }
}