// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.Enterprise.Identity
{
    /// <summary>
    /// Represents a DevAccelerate Enterprise user.
    /// </summary>
    public class DaeUser : DaeUser<string>
    { }

    /// <summary>
    /// Represents a DevAccelerate Enterprise user.
    /// </summary>
    public class DaeUser<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets the unique of a user.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets the unique name of a user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets the email address of a user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Determines if a user's email address is verified or not.
        /// </summary>
        public bool IsEmailConfirmed { get; set; }

        /// <summary>
        /// Gets the first name of a user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets the last name of a user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the current status of a user.
        /// </summary>
        public DaeAccountStatus Status { get; set; }
    }
}
