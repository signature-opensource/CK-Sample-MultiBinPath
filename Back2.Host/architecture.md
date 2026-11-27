<!-- Generated from Backs.Builder/ckonf.json: do not edit. -->
# The App '$Back2'

Its run time configuration is `appsettings.json`; this document describes it from its content and its compile time choices.

## The projects

- The App: `../Back2.App`
- The Builder: `../Backs.Builder`

## The type set

- Types: `{
  "Name": "CK.Core.IActivityMonitor, CK.ActivityMonitor",
  "Kind": "IsContainerConfiguredService|IsScoped"
}`, `{
  "Name": "CK.Core.IParallelLogger, CK.ActivityMonitor",
  "Kind": "IsContainerConfiguredService|IsScoped"
}`

## The configurable types by package

| Package | Configurable types |
|---|---|
| CK.AppIdentity | DevRunningStatus |
| CK.AppIdentity.HttpEndpoint | ForwardedHeaders, HttpEndpoint |
| CK.SqlServer.Setup.Model | SqlServer |

## The aspects

### AppContext aspect `SqlServer`

Package: `CK.SqlServer.Setup.Model`

| Key | Value |
|---|---|
| DefaultDatabaseConnectionString | *(secret)* |
| Databases | *(contains secrets)* *(default)* |
| GlobalResolution | `false` *(default)* |
| IgnoreMissingDependencyIsError | `false` *(default)* |

## The party '$Back2'

- Full name: `Sample/MultiBinPath/$Back2/#Dev`

### Feature `HttpEndpoint`

Package: `CK.AppIdentity.HttpEndpoint`
