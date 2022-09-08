using System.Collections;
using AppInfrastructure.Services.NavigationServices.Close;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Repositories;

/// <summary>
///     Reository
/// </summary>
public interface IRepositorty : IStore, ICloseServices
{
    /// <summary>
    ///     Add some value from
    /// </summary>
    /// <param name="value">added value</param>
    /// <returns>True if value is add</returns>
    bool Add(object value);
    
    /// <summary>
    ///     Remove some value from store
    /// </summary>
    /// <param name="value"></param>
    /// <returns>True if value removed</returns>
    bool Remove(object value);
    
}

/// <summary>
///     Repository wit Generic types
/// </summary>
/// <typeparam name="TValue">Some generic types</typeparam>
public interface IRepositorty<TValue> :  IStore<TValue>, ICloseServices
{
    bool Add(TValue value);

    bool Remove(TValue value);
}


/// <summary>
///       Reository (ICollection type)
/// </summary>
/// <typeparam name="TCollection">Some Ienumerable type</typeparam>
public interface IRepository<TCollection> : IRepositorty, IStore<TCollection> where TCollection : ICollection
{
    /// <summary>
    ///     Find some value in store by some parameter
    /// </summary>
    /// <param name="parameter">Search parameter</param>
    /// <returns></returns>
    object Find(object parameter);

    /// <summary>
    ///     Is store contains some value
    /// </summary>
    /// <param name="value">Search value</param>
    /// <returns>True if contains</returns>
    bool Contains(object value);
}


public interface IRepository<TCollection, TValue> : IRepositorty<TCollection> where TCollection : ICollection<TValue>
{ 
    /// <summary>
    ///     Find some value in store by some parameter
    /// </summary>
    /// <param name="parameter">Search parameter</param>
    /// <returns></returns>
    TValue Find(TValue parameter);

    /// <summary>
    ///     Is store contains some value
    /// </summary>
    /// <param name="value">Search value</param>
    /// <returns>True if contains</returns>
    bool Contains(TValue value);
}
