using AppInfrastructure.Services.NavigationServices.Navigation;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.StoreServices;


/// <summary>
///     Base realize for IFullNavigationService
/// </summary>
public class BaseLazyStoreFullNavigationService : BaseLazyStoreNavigationService, IFullNavigationService
{
    #region Methods
    
    public void Close() => Store.Value.CurrentValue = default;

    #endregion

    #region Constructors

    public BaseLazyStoreFullNavigationService(IStore store, Func<object> creatableNewStoreValue) : base(store, creatableNewStoreValue)
    {
    }

    #endregion
    
}

/// <summary>
///     Base realize for IFullNavigationService with generic types
/// </summary>
/// <typeparam name="TValue">Some value with class type</typeparam>
public class BaseLazyStoreFullNavigationService<TValue>  : BaseLazyStoreFullNavigationService where TValue : class
{
    public BaseLazyStoreFullNavigationService(IStore<TValue> store, Func<TValue> creatableNewStoreValue) : base(store, creatableNewStoreValue)
    {
    }
}






