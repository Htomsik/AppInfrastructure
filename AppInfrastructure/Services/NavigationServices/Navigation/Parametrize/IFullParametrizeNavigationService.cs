using AppInfrastructure.Services.NavigationServices.Close;

namespace AppInfrastructure.Services.NavigationServices.Navigation.Parametrize;

/// <summary>
///  Full Navigation service with parameter
/// </summary>
/// <typeparam name="TValue"></typeparam>
public interface IFullParametrizeNavigationService<TValue> : IParametrizeNavigationService<TValue>, ICloseServices
{
    
}