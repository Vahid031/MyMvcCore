using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;

namespace Web.Permission
{
    internal class Authentication : IConfigureNamedOptions<CookieAuthenticationOptions>
    {
        // You can inject services here
        public Authentication()
        {
        }

        public void Configure(string name, CookieAuthenticationOptions options)
        {
            // Only configure the schemes you want
            if (name == Startup.CookieScheme)
            {
                options.AccessDeniedPath = "/account/AccessDenied";
                options.LoginPath = "/account/Index";
            }
        }

        public void Configure(CookieAuthenticationOptions options)
            => Configure(Options.DefaultName, options);
    }
}
