using Microsoft.AspNetCore.Mvc;

namespace POS.WebApi.Common.Results;

public class CustomOkResult : IActionResult
{
    public Task ExecuteResultAsync(ActionContext context)
    {
        throw new NotImplementedException();
    }
}