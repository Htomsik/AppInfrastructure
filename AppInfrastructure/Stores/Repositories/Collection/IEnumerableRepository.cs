using System.Collections;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Stores.Repositories;

/// <summary>
///       Reository (IEnumerable type)
/// </summary>
/// <typeparam name="TCollection">Some Ienumerable type</typeparam>
public interface IEnumerableRepository<TCollection> : IRepository, IStore<TCollection> where TCollection : IEnumerable
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


/// <summary>
///       Reository generic (IEnumerable generic type)
/// </summary>
/// <typeparam name="TEnumerable">Some Ienumerable type</typeparam>
/// <typeparam name="TValue">Some value</typeparam>
public interface IEnumerableRepository<TEnumerable, TValue> : IEnumerableRepository<TEnumerable> where TEnumerable : IEnumerable<TValue>
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