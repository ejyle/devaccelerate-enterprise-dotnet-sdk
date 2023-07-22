// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using Ejyle.DevAccelerate.Enterprise.AspNetCore.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ejyle.DevAccelerate.Enterprise.AspNetCore.Extensions
{
    /// <summary>
    /// Extension methods for setting up authentication services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class DaeServiceCollectionExtensions
    {
        private static string[] _scopes = { "email", "phone", "role", "tenant", "api" };

        /// <summary>
        /// Registers services required by authentication services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> parameter.</param>
        /// <param name="authority">The authority parameter. The default value is https://account.ejyle.com.</param>
        /// <param name="clientId">The client ID of the DevAccelerate IAM service.</param>
        /// <param name="clientSecret">The client secret of the DevAccelerate Enterprise IAM service.</param>
        /// <param name="scopes">An array of scopes. The default list of scopes is: <see cref="_scopes"/>.</param>
        /// <param name="getClaimsFromUserInfoEndpoint">The getClaimsFromUserInfoEndpoint parameter. The default value is true.</param>
        /// <returns>A <see cref="AuthenticationBuilder"/> that can be used to further configure authentication.</returns>
        public static AuthenticationBuilder AddDaeAuthentication(this IServiceCollection services, string clientId = null, string clientSecret = null ,string authority = "https://account.ejyle.com", string[] scopes = null, bool getClaimsFromUserInfoEndpoint = true)
        {
            if(string.IsNullOrEmpty(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if(string.IsNullOrEmpty(clientSecret))
            {
                throw new ArgumentNullException(nameof(clientSecret));
            }

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


                options.GetClaimsFromUserInfoEndpoint = getClaimsFromUserInfoEndpoint;
            });
        }
    }
}
