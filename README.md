# .NET 💜 GitHub Actions

The purpose of this repository is to demonstrate the ease of using GitHub Actions for .NET developers.

> For additional resources, see [URL List: Learn .NET GitHub](https://www.theurlist.com/letslearndotnet-github-resources).

## Build and deploy status badges 📛

[![Build workflow](https://github.com/IEvangelist/actions-demo/actions/workflows/dotnet-build.yml/badge.svg)](https://github.com/IEvangelist/actions-demo/actions/workflows/dotnet-build.yml)
[![Test and Deploy workflow](https://github.com/IEvangelist/actions-demo/actions/workflows/dotnet-test.yml/badge.svg)](https://github.com/IEvangelist/actions-demo/actions/workflows/dotnet-test.yml)
[![Lint Code Base](https://github.com/IEvangelist/actions-demo/actions/workflows/super-linter.yml/badge.svg)](https://github.com/IEvangelist/actions-demo/actions/workflows/super-linter.yml)
[![CodeQL workflow](https://github.com/IEvangelist/actions-demo/actions/workflows/codeql.yml/badge.svg)](https://github.com/IEvangelist/actions-demo/actions/workflows/codeql.yml)

### Build workflow sequence diagram

```mermaid
sequenceDiagram
    autonumber
    actor Developer
    Developer->>GitHub build workflow: push code to main
    GitHub build workflow->>actions/checkout: Check out source code
    actions/checkout-->>GitHub build workflow: Source code is checked out
    GitHub build workflow->>actions/setup-dotnet: Set up .NET CLI environment
    actions/setup-dotnet-->>GitHub build workflow: .NET CLI environment is setup
    GitHub build workflow->>dotnet restore: Run dotnet restore
    dotnet restore-->>GitHub build workflow: .NET restore command completed successfully
    GitHub build workflow->>dotnet build: Run dotnet build
    dotnet build-->>GitHub build workflow: .NET build command completed successfully
```

## Demo app 🔗

**[Let's Learn GitHub Actions](https://aka.ms/lets-learn-github-actions)**

## Local testing ☑️

```dotnetcli
dotnet dev-certs https --trust
```
