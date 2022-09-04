using AppInfrastructure.Services.NavigationServices.Close;

namespace AppInfrastructure.Services.NavigationServices.Navigation.Parametrize;

/// <summary>
///  Full Navigation service with parameter
/// </summary>
/// <typeparam name="TValue"></typeparam>
public interface IFullParamNavigationService<TValue> : IParamNavigationService<TValue>, ICloseServices
{
    
}