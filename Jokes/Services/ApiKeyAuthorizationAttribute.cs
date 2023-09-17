using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jokes.Services
{
    public class ApiKeyAuthorizationAttribute : ActionFilterAttribute
    {
        private readonly string apiKey;

        public ApiKeyAuthorizationAttribute(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!IsApiKeyValid(context.HttpContext.Request))
            {
                context.Result = new UnauthorizedObjectResult("Invalid API Key");
                return;
            }

            base.OnActionExecuting(context);
        }

        private bool IsApiKeyValid(HttpRequest request)
        {
            if (request.Headers.TryGetValue("Api-Key", out var apiKeyHeader))
            {
                var apiKeyValue = apiKeyHeader.ToString();
                return !string.IsNullOrEmpty(apiKeyValue) && apiKeyValue == apiKey;
            }

            return false;
        }
    }
}
