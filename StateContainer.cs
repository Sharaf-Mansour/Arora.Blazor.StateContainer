using System;
using Microsoft.Extensions.DependencyInjection;
namespace Arora.Blazor.StateContainer;
public class StateContainer
{
    /// <summary>
    /// Occurs when the state has changed.
    /// Use += StateHasChanged to subscribe to this event.
    /// </summary>
    public event Action? OnChange;
    /// <summary>
    /// Notifies the state container that the state has changed.
    /// </summary>
    public void NotifyStateChanged() => OnChange?.Invoke();
}
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Injects a StateContainer into the DI container as a scoped service.
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddStateContainer(this IServiceCollection services) =>
        services.AddScoped<StateContainer>();
}