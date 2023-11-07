using System;
using AppInfrastructure.Services.NavigationServices.Navigation.Parametrize;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Services.StoreServices.Parametrize;

/// <summary>
///     Base realization of IParamNavigationService with ICloseServices
/// </summary>
/// <typeparam name="TInput">Input parameter</typeparam>
/// <typeparam name="TOutput">Output parameter</typeparam>
public class BaseLazyParamFullNavigationService<TInput,TOutput> : BaseLazyParamNavigationService<TInput,TOutput>, IFullParamNavigationService<TInput>
{
    #region Methods

    public void Close() => _lazyStore.Value.CurrentValue = default;

    #endregion

    #region Constructors

    public BaseLazyParamFullNavigationService(IStore<TOutput> store,Func<TInput, TOutput> navigationFunc) : base(store, navigationFunc)
    {
    }

    #endregion
    
}