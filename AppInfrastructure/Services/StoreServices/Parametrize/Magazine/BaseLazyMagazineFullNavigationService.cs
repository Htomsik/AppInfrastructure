using AppInfrastructure.Services.NavigationServices.Close;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.StoreServices.Parametrize.Magazine;

/// <summary>
///     Magazine service with ICloseServices
/// </summary>
/// <typeparam name="TInput">Input parameter</typeparam>
/// <typeparam name="TOutput">Output parameter</typeparam>
public class BaseLazyMagazineFullNavigationService<TInput,TOutput> : BaseLazyMagazineNavigationService<TInput,TOutput>, ICloseServices
{
    
    #region Constructors

    public BaseLazyMagazineFullNavigationService(Dictionary<TInput, TOutput> collations, IStore<TOutput> store) : base(collations, store)
    {
    }

    #endregion
    
    #region Methods

    public void Close() => _lazyStore.Value.CurrentValue = default;

    #endregion
    
}