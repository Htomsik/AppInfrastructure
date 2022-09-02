using AppInfrastructure.Services.NavigationServices.Close;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.StoreServices;

/// <summary>
///     Base realize for ICloseServices
/// </summary>
public class BaseLazyStoreCloseService : ICloseServices
{
    #region Fields

    protected readonly Lazy<IStore>  _store;

    #endregion

    #region Methods

    public void Close() => _store.Value.CurrentValue = null;

    #endregion

    #region Constructors


    /// <param name="store">Some store</param>
    /// <exception cref="ArgumentNullException">Then store is null</exception>
    public BaseLazyStoreCloseService(IStore store) =>
        _store = store is null 
            ? throw new ArgumentNullException(nameof(store))
            : new Lazy<IStore>(()=> store);

    #endregion
    
}

/// <summary>
///     Base generic realize for ICloseServices
/// </summary>
public class BaseLazyStoreCloseService<TValue> : BaseLazyStoreCloseService
{
    #region Constructors

    /// <param name="store">Some store</param>
    /// <exception cref="ArgumentNullException">Then store is null</exception>
    public BaseLazyStoreCloseService(IStore<TValue> store) : base(store)
    {
    }

    #endregion
}