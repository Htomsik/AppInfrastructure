using System;
using AppInfrastructure.Services.NavigationServices.Navigation;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.StoreServices;

/// <summary>
///     Base realize for INavigationService
/// </summary>
public class BaseLazyStoreNavigationService : INavigationServices
{
    #region Fields

    protected readonly Lazy<IStore>  Store;

    protected readonly Lazy<Func<object>>  CreatableNewStoreValue;

    #endregion

    #region Methods

    public void Navigate() => Store.Value.CurrentValue = CreatableNewStoreValue.Value();

    #endregion

    #region Constructors

    public BaseLazyStoreNavigationService(IStore store,  Func<object> creatableNewStoreValue)
    {
        Store = store is null
            ? throw new ArgumentNullException(nameof(store))
            : new Lazy<IStore>(() => store);
            
        CreatableNewStoreValue = creatableNewStoreValue is null
            ? throw new ArgumentNullException(nameof(creatableNewStoreValue))
            :new Lazy<Func<object>>(() => creatableNewStoreValue);
    }
    #endregion
}

/// <summary>
///      Base realize for INavigationService with generic valuer
/// </summary>
/// <typeparam name="TValue">Some value with class type</typeparam>
public class BaseLazyStoreNavigationService<TValue> : BaseLazyStoreNavigationService where TValue : class
{
    public BaseLazyStoreNavigationService(IStore<TValue> store, Func<TValue> creatableNewStoreValue) 
        : base(store, creatableNewStoreValue)
    {
    }
}