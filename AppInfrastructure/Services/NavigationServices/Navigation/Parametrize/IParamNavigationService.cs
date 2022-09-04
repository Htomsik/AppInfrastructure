namespace AppInfrastructure.Services.NavigationServices.Navigation.Parametrize;

/// <summary>
///   Navigation service with parameter
/// </summary>
/// <typeparam name="TValue"></typeparam>
public interface IParamNavigationService<in TValue> 
{
   void Navigate(TValue parameter);
}





