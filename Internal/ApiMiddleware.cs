using System.Net;

namespace AlgoServer.Internal
{
    public class ApiMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var path = context.Request.Path;

            if (IsExclude(path) == false)
            {
                var ip = context.Connection.RemoteIpAddress;
                string hostname = Dns.GetHostEntry(ip).HostName;
                if (!AllowHostCheck(hostname))
                {
                    context.Response.StatusCode = 403;
                    await context.Response.CompleteAsync();
                    return;
                }
            }

            await next(context);
        }

        private bool IsExclude(string path)
        {
            path = path.ToLower();
            List<string> exclude = new List<string>
            {
                "/",
                "/login/index",
                "/Login/SignIn",
                "/Login/ChangePasswd",
                "/Login/PostChangePasswd",
            };

            return exclude.Exists(t => t.ToLower() == path);
        }

        private bool AllowHostCheck(string hostname)
        {
            List<string> allowHosts = new List<string>
            {
                "localhost",
                "/login/index",
                "/Login/SignIn",
                "/Login/ChangePasswd",
                "/Login/PostChangePasswd",
            };

            return allowHosts.Exists(t => t.ToLower() == hostname);
        }
    }
}
