using AppInfrastructure.Services.NavigationServices.Navigation.Parametrize;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.StoreServices.Parametrize.Magazine;

/// <summary>
///     Magazine service based on IParamNavigationService
/// </summary>
/// <typeparam name="TInput">Input parameter</typeparam>
/// <typeparam name="TOutput">Output parameter</typeparam>
public class BaseLazyMagazineNavigationService<TInput,TOutput> : IParamNavigationService<TInput>
{
    
    #region Properties and fields

    protected Lazy<Dictionary<TInput, TOutput>>  _lazyCollations;
    
    #endregion

    #region Stores

    protected Lazy<IStore<TOutput>> _lazyStore;

    #endregion
    
    #region Constructors

    /// <param name="collations">Collations dictionary</param>
    /// <param name="store">Some information store</param>
    /// <exception cref="ArgumentNullException">Throw if collations or store is null</exception>
    public BaseLazyMagazineNavigationService(Dictionary<TInput, TOutput> collations,IStore<TOutput> store)
    {
        #region Stores Initializing

        _lazyStore = store is null
            ? throw new ArgumentNullException(nameof(store))
            : new Lazy<IStore<TOutput>>(() => store);

        #endregion
        
        #region Properties and Fields Initializing
        
        _lazyCollations = collations is null 
            ? throw new ArgumentNullException(nameof(collations))
            : new Lazy<Dictionary<TInput, TOutput> >(() => collations);
        
        #endregion
    }

    #endregion
    
    #region Methods

    public void Navigate(TInput parameter) => _lazyStore.Value.CurrentValue = _lazyCollations.Value[parameter];

    #endregion
    
}