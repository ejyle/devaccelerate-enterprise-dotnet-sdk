// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace Ejyle.DevAccelerate.IdM.AspNetCore.Extensions
{
    /// <summary>
    /// Extension methods for setting up authentication services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class DaServiceCollectionExtensions
    {
        private static string[] _scopes = { "email", "phone", "role", "tenant", "api" };

        /// <summary>
        /// Registers services required by authentication services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> parameter.</param>
        /// <param name="authority">The authority parameter. The default value is https://account.ejyle.com.</param>
        /// <param name="clientId">The client ID of the DevAccelerate IAM API service.</param>
        /// <param name="clientSecret">The client secret of the DevAccelerate IAM API service.</param>
        /// <param name="scopes">An array of scopes. If not provided then the default list of scopes will be used.</param>
        /// <param name="claimsFromUserInfoEndpoint">Determines if user info endpoint is used to retrieve additional claims. The default value is true.</param>
        /// <param name="defaultMapInboundClaims">Determines if the InboundClaimTypeMap is used.</param>
        /// <param name="piiInLogs">Determines if the PII is shown in logs.</param>
        /// <param name="events">OpenId events.</param>
        /// <returns>Returns an instance of the <see cref="AuthenticationBuilder"/> class which can be used to further configure authentication.</returns>
        public static AuthenticationBuilder AddDaeOpenIdAuthentication(this IServiceCollection services, string clientId, string clientSecret, string authority = "https://account.ejyle.com", string[] scopes = null, bool claimsFromUserInfoEndpoint = true, bool defaultMapInboundClaims= false, bool piiInLogs = false, OpenIdConnectEvents events = null)
        {
            if(string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if(string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

            JwtSecurityTokenHandler.DefaultMapInboundClaims = defaultMapInboundClaims;
            IdentityModelEventSource.ShowPII = piiInLogs;

            return services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = authority;

                options.ClientId = clientId;
                options.ClientSecret = clientSecret;
                options.ResponseType = "code";

                options.SaveTokens = true;

                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                };

                if(events != null)
                {
					options.Events = events;
				}

				if (scopes == null)
                {
                    foreach (var scope in _scopes)
                    {
                        options.Scope.Add(scope);
                    }
                }
                else
                {
                    foreach (var scope in scopes)
                    {
                        options.Scope.Add(scope);
                    }
                }

                options.GetClaimsFromUserInfoEndpoint = claimsFromUserInfoEndpoint;
            });
        }

		/// <summary>
		/// Registers services required by authentication services.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> parameter.</param>
		/// <param name="authority">The authority parameter. The default value is https://account.ejyle.com.</param>
        /// <param name="validateAudience">Determines if the audience will be validated during token validation.</param>
		/// <returns>Returns an instance of the <see cref="AuthenticationBuilder"/> class which can be used to further configure authentication.</returns>
		public static AuthenticationBuilder AddDaeBearerTokenAuthentication(this IServiceCollection services, string authority = "https://account.ejyle.com", bool validateAudience = false)
		{
			return services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = authority;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
		}

		/// <summary>
		/// Adds authorization policy services to <see cref="IServiceCollection"/> requiring API scope.
		/// </summary>
		/// <param name="services">The <see cref="IServiceCollection"/> parameter.</param>
		/// <param name="policy">The name of the policy. The default value is ApiScope.</param>
		/// <returns>Returns an instance of the <see cref="IServiceCollection"/> class which can be used to further register more services.</returns>
		public static IServiceCollection AddDaeApiAuthorization(this IServiceCollection services, string policy = "ApiScope")
		{
			return services.AddAuthorization(options =>
			{
				options.AddPolicy(policy, policy =>
				{
					policy.RequireAuthenticatedUser();
					policy.RequireClaim("scope", "api");
				});
			});
		}
	}
}
