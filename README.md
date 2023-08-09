![DevAccelerate Logo](https://github.com/ejyle/devaccelerate-dotnet/blob/dev/assets/da_logo_sm.png?raw=true)
# DevAccelerate IdM SDK for .NET
**DevAccelerate IdM SDK for .NET** is a .NET SDK for Ejyle's DevAccelerate IdM. The SDK is free and open source. It contains wrappers that facilitate developers to make DevAccelerate IdM API calls. The usage of the framework is governed by the terms and conditions of its [License](https://github.com/ejyle/devaccelerate-idm-dotnet-sdk/blob/master/LICENSE).
## 1.0.0 Preview Changes
DevAccelerate IdM SDK for .NET 1.0 is the first release and contains wrappers for several DevAceelerate IdM APIs. The following are the highlights:
* ```DaeServiceCollectionExtensions``` class has an extension method ```AddDaeOpenIdAuthentication()``` to configure DevAccelerate IdM authentication in a ASP.NET Core.
* ```DaeClaimsPrincipalExtensions``` class has an exntension method ```GetDaeUser()``` that returns an instance of ```DaeClaimsUser``` based on the available claims.
* ```DaeApiConsumer``` class offers generic methods that can be used to conveniently call DevAccelerate IdM APIs.
* ```DaeUsersApi``` class is a wrapper for /users APIs.
* ```DaeTenantsApi``` class is a wrapper for /tenants APIs.
## Packages
DevAccelerate IdM SDK for .NET is broken down into multiple NuGet package. The following is the list:
* [DevAccelerateIdMSdk](https://www.nuget.org/packages/DevAccelerateIdMSdk)
* [DevAccelerateIdMSdkAspNetCore](https://www.nuget.org/packages/DevAccelerateIdMSdkAspNetCore)
## Installation
Use ```dotnet add package``` command to install DevAccelerate IdM SDK for .NET packages:
```
dotnet add package DevAccelerateIdMSdk
dotnet add package DevAccelerateIdMSdkAspNetCore
```
## Issues
If you find a bug in the library or you have an idea about a new feature, please try to search in the existing list of [issues](https://github.com/ejyle/devaccelerate-idm-dotnet-sdk/issues). If the bug or idea is not listed and addressed there, please [open a new issue](https://github.com/ejyle/devaccelerate-idm-dotnet-sdk/issues/new).
