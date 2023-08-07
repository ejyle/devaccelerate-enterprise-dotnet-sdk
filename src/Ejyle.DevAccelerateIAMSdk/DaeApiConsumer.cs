// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace Ejyle.DevAccelerate.IAM
{
    /// <summary>
    /// Represents the core DevAccelerate IAM API wrapper.
    /// </summary>
    public class DaeApiConsumer
    {
        private const string DEFAULT_API_VERSION = "v1";
        private const string DEFAULT_ADDRESS = "https://api.iam.ejyle.com";
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
        /// Calls a DevAccelerate IAM API and returns an array of objects.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <returns>Returns API response as an array of the generic type of T.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        public async Task<T[]> GetArrayAsync<T>(string path)
        {
            var response = await GetStringAsync(path);
            var deserializedData = JsonConvert.DeserializeObject<DaeApiResponseArray<T>>(response);
            return deserializedData.Data;
        }

        /// <summary>
        /// Calls a DevAccelerate IAM API and returns an array of objects.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <param name="parameters">The set of parameters to be included in the API call.</param>
        /// <returns>Returns API response as an array of the generic type of T.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        public async Task<T[]> GetArrayAsync<T>(string path, Dictionary<string, string> parameters)
        {
            var response = await GetStringAsync(path, parameters);
            var deserializedData = JsonConvert.DeserializeObject<DaeApiResponseArray<T>>(response);
            return deserializedData.Data;
        }

        /// <summary>
        /// Calls a DevAccelerate IAM API and returns an object.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <param name="parameters">The set of parameters to be included in the API call.</param>
        /// <returns>Returns API response as an array of the generic type of T.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        public async Task<T> GetAsync<T>(string path, Dictionary<string, string> parameters)
        {
            var response = await GetStringAsync(path, parameters);
            var deserializedData = JsonConvert.DeserializeObject<DaeApiResponse<T>> (response);
            return deserializedData.Data;
        }

        /// <summary>
        /// Calls a DevAccelerate IAM API and returns an object.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <returns>Returns API response as an array of the generic type of T.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        public async Task<T> GetAsync<T>(string path)
        {
            var response = await GetStringAsync(path);
            var deserializedData = JsonConvert.DeserializeObject<T>(response);
            return deserializedData;
        }

        /// <summary>
        /// Calls a DevAccelerate IAM API and returns a string response.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <returns>Returns API response as a string.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        protected Task<string> GetStringAsync(string path)
        {
            return GetStringAsync(path, null);
        }

        /// <summary>
        /// Calls a DevAccelerate IAM API and returns a string response.
        /// </summary>
        /// <param name="path">The path of the API</param>
        /// <param name="parameters">The set of parameters to be included in the API call.</param>
        /// <returns>Returns API response as a string.</returns>
        /// <exception cref="HttpRequestException">If API returns a non-success HTTP status code. The HTTP status code included in the Message property of the exception.</exception>
        protected async Task<string> GetStringAsync(string path, Dictionary<string, string> parameters)
        {
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(AccessToken);

            var uri = new StringBuilder();
            uri.Append($"{Address}/{ApiVersion}");

            if (!path.StartsWith("/"))
            {
                uri.Append("/");
            }

            uri.Append(path);

            if (parameters != null && parameters.Count > 0)
            {
                if(!path.Contains("?"))
                {
                    uri.Append("?");
                }
                else
                {
                    if(!path.EndsWith("?"))
                    {
                        uri.Append("&");
                    }
                }

                foreach(var key in parameters.Keys)
                {
                    uri.Append($"{key}={parameters[key]}&");
                }
            }

            var response = await apiClient.GetAsync(uri.ToString());

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
