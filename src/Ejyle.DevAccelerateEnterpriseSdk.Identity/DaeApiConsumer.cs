// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;

namespace Ejyle.DevAccelerate.Enterprise.Identity
{
    /// <summary>
    /// Represents the core DevAccelerate Enterprise API wrapper.
    /// </summary>
    public class DaeApiConsumer
    {
        private const string DEFAULT_API_VERSION = "v1";
        private const string DEFAULT_ADDRESS = "https://api.ejyle.com";
        /// <summary>
        /// Creates an instance of the <see cref="DaeApiConsumer"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="address">The root address of the APIs.</param>
        /// <exception cref="ArgumentNullException">If address or apiVersion, accessToken is empty or null.</exception>
        public DaeApiConsumer(string address, string apiVersion, string accessToken)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new ArgumentNullException(nameof(address));
            }

            if (string.IsNullOrEmpty(apiVersion))
            {
                throw new ArgumentNullException(nameof(apiVersion));
            }

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            this.Address = address;
            this.AccessToken = accessToken;
            this.ApiVersion = apiVersion;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaeApiConsumer"/> class.
        /// </summary>
        /// <param name="address">The root address of the APIs.</param> 
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If address or accessToken is empty or null.</exception>
        public DaeApiConsumer(string address, string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            this.Address = address;
            this.AccessToken = accessToken;
            this.ApiVersion = DEFAULT_API_VERSION;
        }

        /// <summary>
        /// Creates an instance of the <see cref="DaeApiConsumer"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If accessToken is empty or null.</exception>
        public DaeApiConsumer(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            this.Address = DEFAULT_ADDRESS;
            this.AccessToken = accessToken;
            this.ApiVersion = DEFAULT_API_VERSION;
        }

        /// <summary>
        /// Gets or sets the root address of the API.
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Gets or sets the API version. This value is appended to the API URI.
        /// </summary>
        protected string ApiVersion { get; private set; }

        /// <summary>
        /// Gets or sets the access token for API authorization.
        /// </summary>
        protected string AccessToken { get; private set; }

        /// <summary>
        /// Calls a DevAccelerate Enterprise APIs.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <returns>Returns API response as a string.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        protected async Task<string> CallApi(string path)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(AccessToken);

            string sPath = path;

            if(!sPath.StartsWith("/"))
            {
                sPath = "/" + sPath;
            }

            var uri = $"{Address}/{ApiVersion}{sPath}";

            var response = await apiClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
