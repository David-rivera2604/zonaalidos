using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Builder;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Web.Http;
using System.Text;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System.Net.Sockets;

[assembly: OwinStartup(typeof(Aliados.Monge.App_Start.Startup))]
namespace Aliados.Monge.App_Start
{
    public class Startup
    {
        IAppBuilder AppBuilder;

        // Old Global.asax
        //AreaRegistration.RegisterAllAreas();
        //    GlobalConfiguration.Configure(WebApiConfig.Register);
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }


        public void ConfigureAuth(IAppBuilder app)
        {
            AppBuilder = app;

            //app.UseCors( CorsOptions.AllowAll);

            var OAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new AuthorizationServerProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:59822")
                //RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };
            app.UseOAuthBearerTokens(OAuthOptions);
            // app.UseOAuthAuthorizationServer(OAuthOptions);
            // app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = ConfigurationManager.AppSettings["Jwt:Issuer"], //some string, normally web url,  
                        ValidAudience = ConfigurationManager.AppSettings["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["Jwt:SecretKey"]))
                    }
                });

            //        app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            //        {
            //            AuthenticationMode = AuthenticationMode.Active,
            //            AllowedAudiences = new[] { "Any" },
            //            IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
            //            {
            //    new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret)
            //}
            //        });
            //HttpConfiguration config = new HttpConfiguration();
            //WebApiConfig.Register(config);
        }

    }
}