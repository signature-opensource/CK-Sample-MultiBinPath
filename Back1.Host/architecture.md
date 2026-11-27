<!-- Generated from Backs.Builder/ckonf.json: do not edit. -->
# The App '$Back1'

Its run time configuration is `appsettings.json`; this document describes it from its content and its compile time choices.

## The projects

- The App: `../Back1.App`
- The Builder: `../Backs.Builder`

## The type set

The types of the packages of the App project (discovered from its folder).

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

## The party '$Back1'

- Full name: `Sample/MultiBinPath/$Back1/#Dev`

### Feature `HttpEndpoint`

Package: `CK.AppIdentity.HttpEndpoint`
