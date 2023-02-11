# Arora.Blazor.StateContainer
Arora.Blazor.StateContainer is a .NET library that provides a simple state container implementation for Blazor applications. The library defines a `StateContainer` class that can be used to store and manage application state, and an extension method `AddStateContainer()` that can be used to register the StateContainer with the dependency injection container.

## Installation
You can install the Arora.Blazor.StateContainer library using the .NET CLI:

```java
dotnet add package Arora.Blazor.StateContainer
```
## Usage
### Top-level statements
If you're using C# 9 or later with top-level statements, you can use the Arora.Blazor.StateContainer library as follows:

```csharp
using Arora.Blazor.StateContainer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStateContainer();

var app = builder.Build();

app.Run();
```
### Old-style program and Startup
If you're using an older version of C# or the Program.cs and Startup.cs files in your project, you can use the Arora.Blazor.StateContainer library as follows:

```csharp
using Arora.Blazor.StateContainer;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddStateContainer();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
```
### Steps 
1. Add the following using statement:
```cs
using Arora.Blazor.StateContainer;
```
```razor
@using Arora.Blazor.StteContainer;
```
2. In your Blazor component, use the `@inject` directive to inject the `StateContainer` instance:
```razor
@inject StateContainer State
```
3. Use the StateContainer instance in your component to update the state:
```razor
<p>Count: @count</p>
<button @onclick="IncrementCount">Increment</button>

@code {
    private int count = 0;

    private void IncrementCount()
    {
        count++;
        State.NotifyStateChanged();
    }

    protected override void OnInitialized()
    {
        State.OnChange += StateHasChanged;
    }

    public void Dispose()
    {
        State.OnChange -= StateHasChanged;
    }
}
```
