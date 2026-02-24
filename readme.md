# Immediate.Templates

This repository contains `dotnet new` templates for [ImmediatePlatform](https://github.com/ImmediatePlatform) handlers and projects.

## Installing Templates

Clone this repository and run `dotnet new install ./src/Immediate.Templates/`.

## Included Templates

### ASP.NET Core Web API (ImmediatePlatform)

A project template for creating a RESTful Web API using ImmediatePlatform handlers. Scaffolds a minimal ASP.NET Core project pre-configured with OpenAPI, Immediate.Handlers, Immediate.Apis, and Immediate.Validations.

**Short name:** `webapiip`
**Type:** Project
**Language:** C#

```bash
dotnet new webapiip -n MyApi
```

#### Options

| Option | Alias | Description | Type | Default |
|---|---|---|---|---|
| `--cpm` | `-c` | Use CPM style `PackageReference`s (omits version number) | `bool` | `false` |

---

### ImmediatePlatform Handler

An item template for creating an Immediate.Handlers handler. Generates a handler class with configurable query/response records, optional Immediate.Apis API endpoint mapping, Immediate.Validations support, and endpoint customization.

**Short name:** `iphandler`
**Type:** Item
**Language:** C#

```bash
dotnet new iphandler -n GetWeather
```

#### Options

| Option | Alias | Description | Type | Default |
|---|---|---|---|---|
| `--namespace` | `-ns` | The root namespace for the generated handler. | `string` | `MyNamespace` |
| `--query-class-name` | `-q` | The name of the query class the handler will receive. | `string` | `Query` |
| `--response-class-name` | `-r` | The name of the response class the handler will return. | `string` | `Response` |
| `--http-method` | `-m` | Adds the associated attribute to register the handler as an API endpoint. Choices: **Get**, **Post**, **Put**, **Delete**. | `choice` | *(none)* |
| `--validations` | `-v` | Generates a handler query implementing Immediate.Validations. | `bool` | `false` |
| `--customize-endpoint` | `-c` | Generates a `CustomizeEndpoint` method in the handler. Requires an HTTP method to be specified. | `bool` | `false` |

#### Examples

Create a handler with a GET endpoint and validations:

```bash
dotnet new iphandler -n GetWeather -m Get -p:v -q Query -r WeatherForecasts
```

---

### ImmediatePlatform Cache

An item template for creating an Immediate.Cache cache. Generates a cache and associated handler class.

**Short name:** `ipcache`
**Type:** Item
**Language:** C#

```bash
dotnet new ipcache -n GetWeather
```

#### Options

| Option | Alias | Description | Type | Default |
|---|---|---|---|---|
| `--namespace` | `-ns` | The root namespace for the generated handler. | `string` | `MyNamespace` |
