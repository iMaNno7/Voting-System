using Microsoft.AspNetCore.Mvc;
namespace WebUI.IntegrationTests.Common
{

    public static class ActionResultHelper
    {
        public static async Task<T> Val<T>(this Task<ActionResult<T>> action)
        {
            return (T)((await action).Result as OkObjectResult).Value;
        }
    }
}
