![DevAccelerate Logo](https://github.com/ejyle/devaccelerate-dotnet/blob/dev/assets/da_logo_sm.png?raw=true)
# DevAccelerate Enterprise SDK for .NET
**DevAccelerate Enterprise SDK for .NET** is a .NET SDK for Ejyle's DevAccelerate Enterprise. The SDK is free and open source. It contains wrappers that facilitate developers to make DevAccelerate Enterprise API calls. The usage of the framework is governed by the terms and conditions of its [License](https://github.com/ejyle/devaccelerate-enterprise-dotnet-sdk/blob/master/LICENSE).
## 1.0.0 Preview 1.0 & Preview 1.1 Changes
DevAccelerate Enterprise SDK for .NET 1.0 is the first release and contains wrappers for several DevAceelerate Enterprise APIs. The following are the highlights:
* DaeServiceCollectionExtensions class has an extension method AddDaeOpenIdAuthentication to configure DevAccelerate Enterprise authentication in a ASP.NET Core.
* DaeClaimsPrincipalExtensions class has an exntension method GetDaeUser() that returns an instance of DaeClaimsUser based on the available claims.
* DaeApiConsumer class offers generic methods that can be used to conveniently call DevAccelerate Enterprise APIs.
* DaeUsersApi class is a wrapper for /users APIs.
* DaeTenantsApi class is a wrapper for /tenants APIs.
## Packages
DevAccelerate Enterprise SDK for .NET is broken down into multiple NuGet package. The following is the list:
* [DevAccelerateEnterpriseSdk](https://www.nuget.org/packages/DevAccelerateEnterpriseSdk)
* [DevAccelerateEnterpriseSdkAspNetCore](https://www.nuget.org/packages/DevAccelerateEnterpriseSdkAspNetCore)
## Installation
Use ```dotnet add package``` command to install DevAccelerate Enterprise SDK for .NET packages:
```
dotnet add package DevAccelerateEnterpriseSdk
dotnet add package DevAccelerateEnterpriseSdkAspNetCore
```
## Issues
If you find a bug in the library or you have an idea about a new feature, please try to search in the existing list of [issues](https://github.com/ejyle/devaccelerate-enterprise-dotnet-sdk/issues). If the bug or idea is not listed and addressed there, please [open a new issue](https://github.com/ejyle/devaccelerate-enterprise-dotnet-sdk/issues/new).
