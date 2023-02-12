using System;
using Microsoft.Extensions.DependencyInjection;
namespace Arora.Blazor.StateContainer;
public class StateContainer
{
    public event Action? OnChange;
    public void NotifyStateChanged() => OnChange?.Invoke();
}
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStateContainer(this IServiceCollection services) =>
        services.AddScoped<StateContainer>();
}
