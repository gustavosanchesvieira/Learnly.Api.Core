using Learnly.Api.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Learnly.Api.Core.Auth
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthenticationApi : ControllerBase
    {
        public void Auth(HttpRequest re, HttpContext context)
        {
            var headers = re.Headers;

            headers.TryGetValue("ApiKey", out var apiKey);
            headers.TryGetValue("SecretKey", out var secretKey);

            if (headers.Keys.Contains("ApiKey", StringComparer.InvariantCultureIgnoreCase) && headers.Keys.Contains("SecretKey", StringComparer.InvariantCultureIgnoreCase))
            {
                if (apiKey != InfoLearnlySystem.ApiKey)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    throw new Exception(((int)HttpStatusCode.Unauthorized).ToString());
                }
                if (secretKey != InfoLearnlySystem.SecretKey)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    throw new Exception(((int)HttpStatusCode.Unauthorized).ToString());
                }
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                throw new Exception(((int)HttpStatusCode.Unauthorized).ToString());
            }
        }
    }
}
