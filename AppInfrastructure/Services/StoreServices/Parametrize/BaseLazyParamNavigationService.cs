using AppInfrastructure.Services.NavigationServices.Navigation.Parametrize;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.StoreServices.Parametrize;

/// <summary>
///     Base realization of IParamNavigationService
/// </summary>
/// <typeparam name="TInput">Input parameter</typeparam>
/// <typeparam name="TOutput">Output parameter</typeparam>
public class BaseLazyParamNavigationService<TInput,TOutput>  : IParamNavigationService<TInput>
{
    #region Stores

    protected Lazy<IStore<TOutput>> _lazyStore;

    protected Lazy<Func<TInput, TOutput>> _lazyNavigationFunc;

    #endregion
    
    #region Constructors

    public BaseLazyParamNavigationService(IStore<TOutput> store,Func<TInput,TOutput> navigationFunc)
    {
        #region Properties and Fields Initializing

        _lazyStore = store is null
            ? throw new ArgumentNullException(nameof(store))
            : new Lazy<IStore<TOutput>>(() => store);

        _lazyNavigationFunc = navigationFunc is null
            ? throw new ArgumentNullException(nameof(navigationFunc))
            : new Lazy<Func<TInput, TOutput>>(() => navigationFunc);

        #endregion
    }

    #endregion

    #region Methods

    public void Navigate(TInput parameter) => _lazyStore.Value.CurrentValue = _lazyNavigationFunc.Value(parameter);

    #endregion


}