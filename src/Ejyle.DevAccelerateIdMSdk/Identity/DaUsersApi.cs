// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.IdM.Identity
{
    /// <summary>
    /// Represents a wrapper of the /users API of DevAccelerate IdM.
    /// </summary>
    public class DaUsersApi : DaApiConsumer
    {
        /// <summary>
        /// Creates an instance of the <see cref="DaUsersApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <param name="apiVersion">The API version.</param>
        /// <param name="address">The root address of the APIs.</param>
        /// <exception cref="ArgumentNullException">If address or apiVersion, accessToken is empty or null.</exception>
        public DaUsersApi(string address, string apiVersion, string accessToken)
            : base(address, apiVersion, accessToken) { }


        /// <summary>
        /// Creates an instance of the <see cref="DaUsersApi"/> class.
        /// </summary>
        /// <param name="address">The root address of the APIs.</param> 
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If address or accessToken is empty or null.</exception>
        public DaUsersApi(string address, string accessToken)
        : base(address, accessToken) { }

        /// <summary>
        /// Creates an instance of the <see cref="DaUsersApi"/> class.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <exception cref="ArgumentNullException">If accessToken is empty or null.</exception>
        public DaUsersApi(string accessToken)
        : base(accessToken) { }

        /// <summary>
        /// Gets a list of users as a JSON string.
        /// </summary>
        /// <returns>Returns a JSON string.</returns>
        public async Task<string> GetUsersAsStringAsync()
        {
            return await GetStringAsync("users");
        }

        /// <summary>
        /// Gets a list of users.
        /// </summary>
        /// <returns>Returns an array of <see cref="DaUser"/>.</returns>
        public async Task<DaUser[]> GetUsersAsync()
        {
            var users = await GetArrayAsync<DaUser>("users");
            return users;
        }

        /// <summary>
        /// Gets a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public async Task<DaUser> GetUserByIdAsync(string id)
        {
            return await GetAsync<DaUser>("users" , new Dictionary<string, string> { { "id", id } });
        }

        /// <summary>
        /// Gets a user by user ID as a JSON string.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>Returns a JSON string.</returns>
        public async Task<string> GetUserByIdAsStringAsync(string id)
        {
            return await GetStringAsync("users", new Dictionary<string, string> {{ "id", id }});
        }
    }
}
