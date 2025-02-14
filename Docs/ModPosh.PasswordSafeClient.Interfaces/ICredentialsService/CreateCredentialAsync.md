# ICredentialsService.CreateCredentialAsync method

Creates a new credential within the specified project.

```csharp
public Task<Credential> CreateCredentialAsync(int projectId, CredentialRequest credentialRequest)
```

| parameter | description |
| --- | --- |
| projectId | The ID of the project. |
| credentialRequest | The request payload containing the credential details. |

## Return Value

The newly created credential.

## See Also

* class [Credential](../../ModPosh.PasswordSafeClient.Models/Credential.md)
* class [CredentialRequest](../../ModPosh.PasswordSafeClient.Models/CredentialRequest.md)
* interface [ICredentialsService](../ICredentialsService.md)
* namespace [ModPosh.PasswordSafeClient.Interfaces](../ICredentialsService.md.md)
* assembly [PasswordSafeClient](../../PasswordSafeClient.md)

<!-- DO NOT EDIT: generated by xmldocmd for PasswordSafeClient.dll -->
