using AppInfrastructure.Services.NavigationServices.Close;

namespace AppInfrastructure.Services.NavigationServices.Navigation;

/// <summary>
///     Navigation service with close and navigation methods
/// </summary>
public interface IFullNavigationService : INavigationServices, ICloseServices
{
    
}