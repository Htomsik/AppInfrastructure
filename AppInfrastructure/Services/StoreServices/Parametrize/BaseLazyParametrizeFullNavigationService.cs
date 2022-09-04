using AppInfrastructure.Services.NavigationServices.Close;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.StoreServices.Parametrize;

/// <summary>
///     Base realization of IParametrizeNavigationService with ICloseServices
/// </summary>
/// <typeparam name="TInput">Input parameter</typeparam>
/// <typeparam name="TOutput">Output parameter</typeparam>
public class BaseLazyParametrizeFullNavigationService<TInput,TOutput> : BaseLazyParametrizeNavigationService<TInput,TOutput>, ICloseServices
{
    #region Methods

    public void Close() => _lazyStore.Value.CurrentValue = default;

    #endregion

    #region Constructors

    public BaseLazyParametrizeFullNavigationService(Func<TInput, TOutput> navigationFunc, IStore<TOutput> store) : base(navigationFunc, store)
    {
    }

    #endregion
    
}