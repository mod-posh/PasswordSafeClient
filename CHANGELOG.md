# Changelog

All changes to this project should be reflected in this document.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/), and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [[1.2.0]](https://github.com/mod-posh/PasswordSafeClient/releases/tag/v1.2.0) - 2024-10-18

This release of the ModPosh.PasswordSafeClient adds support for the Users endpoint.

Added:

- User Endpoint
  - Models
    - User
    - UserRequest
  - Interface
    - IUserService

Removed: The functions these files provided have all been moved into Github Workflows

- Files
  - PSScriptAnalyzerSettings.psd1
  - bluesky.json
  - discord.json
  - github.json
  - nuget.config
  - psakefile.ps1

---

## [[1.0.0]](https://github.com/mod-posh/PasswordSafeClient/releases/tag/v1.0.0) - 2024-10-16

ModPosh.PasswordSafeClient is a C# client library for interacting with the PasswordSafe API. It allows developers to manage credentials within projects by providing a simple and flexible API interface. This client supports basic operations such as retrieving, creating, updating, and deleting credentials, and it uses an authentication token to securely communicate with the API.

Added:

- Retrieve all credentials for a project.
- Retrieve a specific credential by its ID.
- Create new credentials.
- Update existing credentials.
- Delete credentials from a project.

---
