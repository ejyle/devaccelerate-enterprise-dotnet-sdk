// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using IdentityModel.Client;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Enterprise.Identity
{
    /// <summary>
    /// Represents a wrapper of the /users API of DevAccelerate Enterprise.
    /// </summary>
    public class DaeUsersApi : DaeApiConsumer
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaeUsersApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="address">The root address of the APIs.</param>
        /// <exception cref="ArgumentNullException">If address or apiVersion, accessToken is empty or null.</exception>
        public DaeUsersApi(string address, string apiVersion, string accessToken)
            : base(address, apiVersion, accessToken) { }


        /// <summary>
        /// Creates an instance of the <see cref="DaeUsersApi"/> class.
        /// </summary>
        /// <param name="address">The root address of the APIs.</param> 
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If address or accessToken is empty or null.</exception>
        public DaeUsersApi(string address, string accessToken)
        : base(address, accessToken) { }

        /// <summary>
        /// Creates an instance of the <see cref="DaeUsersApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If accessToken is empty or null.</exception>
        public DaeUsersApi(string accessToken)
        : base(accessToken) { }

        /// <summary>
        /// Gets a list of users as a JSON string.
        /// </summary>
        public async Task<string> GetUsersAsString()
        {
            return await CallApi("users");
        }
    }
}
