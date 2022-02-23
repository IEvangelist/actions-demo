# .NET 💜 GitHub Actions

The purpose of this repository is to demonstrate the ease-of-use with GitHub Actions.

## Build and deploy status badges 📛

[![build](https://github.com/IEvangelist/actions-demo/actions/workflows/dotnet-build.yml/badge.svg)](https://github.com/IEvangelist/actions-demo/actions/workflows/dotnet-build.yml)
[![deploy](https://github.com/IEvangelist/actions-demo/actions/workflows/azure-static-web-app-deploy.yml/badge.svg)](https://github.com/IEvangelist/actions-demo/actions/workflows/azure-static-web-app-deploy.yml)

### Build workflow sequence diagram

```mermaid
sequenceDiagram
    autonumber
    actor Developer
    Developer->>GitHub build workflow: push code...
    GitHub build workflow->>actions/checkout: Check out source code
    actions/checkout-->>GitHub build workflow: Source code is checked out
    GitHub build workflow->>actions/setup-dotnet: Set up .NET CLI environment
    actions/setup-dotnet-->>GitHub build workflow: .NET CLI is setup
    GitHub build workflow->>dotnet restore: Run dotnet restore
    dotnet restore-->>GitHub build workflow: .NET restore command completed successfully
    GitHub build workflow->>dotnet build: Run dotnet build
    dotnet build-->>GitHub build workflow: .NET build command completed successfully
```

## Demo app 🔗

**[Let's Learn GitHub Actions](https://aka.ms/lets-learn-github-actions)**
