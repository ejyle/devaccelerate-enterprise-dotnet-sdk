// ----------------------------------------------------------------------------------------------------------------------
// Author: Tanveer Yousuf (@tanveery)
// ----------------------------------------------------------------------------------------------------------------------
// Copyright © Ejyle Technologies (P) Ltd. All rights reserved.
// Licensed under the MIT license. See the LICENSE file in the project's root directory for complete license information.
// ----------------------------------------------------------------------------------------------------------------------

using System;

namespace Ejyle.DevAccelerate.IAM.Identity
{
    /// <summary>
    /// Represents a DevAccelerate IAM tenant.
    /// </summary>
    public class DaeTenant : DaeTenant<string>
    { }

    /// <summary>
    /// Represents a DevAccelerate IAM tenant.
    /// </summary>
    public class DaeTenant<TKey>
        where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// Gets the unique ID of a tenant.
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Gets the unique name of a tenant.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets a friendly name of a tenant.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Gets the current status of a tenant.
        /// </summary>
        public DaeTenantStatus Status { get; set; }

        /// <summary>
        /// Gets the ID of a user who owns the tenant.
        /// </summary>
        public string OwnerUserId { get; set; }

        /// <summary>
        /// Gets the country of a tenant.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets the currency of a tenant.
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Gets the system language of a tenant.
        /// </summary>
        public string SystemLanguage { get; set; }

        /// <summary>
        /// Gets the time zone of a tenant.
        /// </summary>
        public string TimeZone { get; set; }

        /// <summary>
        /// Gets the preferred date format of a tenant.
        /// </summary>
        public string DateFormat { get; set; }
    }
}
