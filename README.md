| Latest Version | Nuget.org | Issues | Testing | License | Discord |
|-----------------|-----------------|----------------|----------------|----------------|----------------|
| [![Latest Version](https://img.shields.io/github/v/tag/mod-posh/PasswordSafeClient)](https://github.com/mod-posh/PasswordSafeClient/tags) | [![Nuget.org](https://img.shields.io/nuget/dt/ModPosh.PasswordSafeClient)](https://www.nuget.org/packages/ModPosh.PasswordSafeClient) | [![GitHub issues](https://img.shields.io/github/issues/mod-posh/PasswordSafeClient)](https://github.com/mod-posh/PasswordSafeClient/issues) | [![Testing](https://github.com/mod-posh/PasswordSafeClient/actions/workflows/test.yml/badge.svg)](https://github.com/mod-posh/PasswordSafeClient/actions/workflows/test.yml) | [![GitHub license](https://img.shields.io/github/license/mod-posh/PasswordSafeClient)](https://github.com/mod-posh/PasswordSafeClient/blob/master/LICENSE) | [![Discord Server](https://assets-global.website-files.com/6257adef93867e50d84d30e2/636e0b5493894cf60b300587_full_logo_white_RGB.svg)](https://discord.com/channels/1044305359021555793/1044305781627035811) |

# ModPosh.PasswordSafeClient

ModPosh.PasswordSafeClient is a C# client library for interacting with the PasswordSafe API. It allows developers to manage credentials within projects by providing a simple and flexible API interface. This client supports basic operations such as retrieving, creating, updating, and deleting credentials, and it uses an authentication token to securely communicate with the API.

## Features

- Retrieve all credentials for a project.
- Retrieve a specific credential by its ID.
- Create new credentials.
- Update existing credentials.
- Delete credentials from a project.
- Supports token-based authentication (`X-Auth-Token`).

## Installation

You can install **ModPosh.PasswordSafeClient** via NuGet:

```bash
dotnet add package ModPosh.PasswordSafeClient
```

Or by adding it to your `csproj` file:

```xml
<PackageReference Include="ModPosh.PasswordSafeClient" Version="1.0.0" />
```

---

## Usage in C# Project

### 1. Initialize the Client

You need to pass an `HttpClient` and an authentication token (`X-Auth-Token`) to create an instance of the `PasswordSafeClient`.

#### Example

```csharp
using ModPosh.PasswordSafeClient;
using ModPosh.PasswordSafeClient.Factory;
using System.Net.Http;

var httpClient = new HttpClient { BaseAddress = new Uri("https://pwdsafe.rackspace.net") };
httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

string authToken = "your-auth-token";  // Replace with a valid token
var passwordSafeClient = PasswordSafeClientFactory.Create(httpClient, authToken);

// Example usage: Retrieve a specific credential
int projectId = 30795;
int credentialId = 320223;

var credential = await passwordSafeClient.CredentialsService.GetCredentialAsync(projectId, credentialId);
Console.WriteLine($"Credential Description: {credential.Description}");
```

---

## Usage via PowerShell

You can also use **ModPosh.PasswordSafeClient** in PowerShell by importing it into your script.

### 1. Load the Assembly

```powershell
Add-Type -Path "path\to\ModPosh.PasswordSafeClient.dll"
```

### 2. Set up the `HttpClient` and Token

```powershell
# Create an instance of HttpClient
$httpClient = [System.Net.Http.HttpClient]::new()
$httpClient.BaseAddress = [Uri]::new("https://pwdsafe.rackspace.net")
$httpClient.DefaultRequestHeaders.Add("Accept", "application/json")

# Set your authentication token
$authToken = "your-auth-token"  # Replace with the actual token

# Create the PasswordSafeClient
$passwordSafeClient = [ModPosh.PasswordSafeClient.Factory.PasswordSafeClientFactory]::Create($httpClient, $authToken)

# Set the project and credential IDs
$projectId = 30795  # Replace with your project ID
$credentialId = 320223  # Replace with your credential ID

# Retrieve the credential
$credential = $passwordSafeClient.CredentialsService.GetCredentialAsync($projectId, $credentialId).GetAwaiter().GetResult()

# Output the credential information
$credential | ConvertTo-Json -Depth 5
```

---

## Implemented Services

### CredentialsService

- `Task<List<Credential>> GetAllCredentialsAsync(int projectId)`
  - Retrieves all credentials for a specific project.

- `Task<Credential> GetCredentialAsync(int projectId, int credentialId)`
  - Retrieves a specific credential by its ID.

- `Task<Credential> CreateCredentialAsync(int projectId, CredentialRequest credentialRequest)`
  - Creates a new credential for the project.

- `Task UpdateCredentialAsync(int projectId, int credentialId, CredentialRequest credentialRequest)`
  - Updates an existing credential.

- `Task DeleteCredentialAsync(int projectId, int credentialId)`
  - Deletes a credential from the project.
