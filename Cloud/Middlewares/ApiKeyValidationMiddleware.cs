using Microsoft.AspNetCore.Http;

namespace SmartSolucionesCuba.Covid19CubaInfo.Cloud.Middlewares
{
    public sealed class ApiKeyValidationMiddleware
    {
        private const string API_KEY_HEADER_PROPERTY = "X-Api-Key";

        private readonly RequestDelegate next;

        private readonly Microsoft.Extensions.Options.IOptions<Options.ApiKeyOptions> apiKeyOptions;

        public ApiKeyValidationMiddleware(RequestDelegate next, Microsoft.Extensions.Options.IOptions<Options.ApiKeyOptions> apiKeyOptions)
        {
            this.next = next;
            this.apiKeyOptions = apiKeyOptions;
        }

        public async System.Threading.Tasks.Task Invoke(HttpContext context)
        {
            if (context.Request.Path.StartsWithSegments(new PathString("/api/backend/")) && (!context.Request.Headers.Keys.Contains(API_KEY_HEADER_PROPERTY) || !context.Request.Headers[API_KEY_HEADER_PROPERTY][0].Equals(apiKeyOptions.Value.BackendSecret)))
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.UpgradeRequired;

                await context.Response.WriteAsync("Upgrade Required!");

                return;
            }

            if (context.Request.Path.StartsWithSegments(new PathString("/api/")) && (!context.Request.Headers.Keys.Contains(API_KEY_HEADER_PROPERTY) || !context.Request.Headers[API_KEY_HEADER_PROPERTY][0].Equals(apiKeyOptions.Value.FrontendSecret)))
            {
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.UpgradeRequired;

                await context.Response.WriteAsync("Upgrade Required!");

                return;
            }

            await next.Invoke(context);
        }
    }
}
