using AppInfrastructure.Stores.Repositories.BaseTypes;

namespace AppInfrastructure.Stores.Repositories.Collection;
/// <summary>
///       Repository generic (IEnumerable generic type)
/// </summary>
/// <typeparam name="TCollection">Some Ienumerable type</typeparam>
/// <typeparam name="TValue">Some value</typeparam>
public interface ICollectionRepository<TCollection, TValue> : IRepository<TCollection> where TCollection : ICollection<TValue>
{ 
    
    new TCollection CurrentValue { get; set; }
    
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
    
    
    /// <summary>
    ///     Add some value into ICollection
    /// </summary>
    /// <param name="value">Added value</param>
    /// <returns>True if value is add</returns>
    bool AddIntoEnumerable(TValue value);
    
    /// <summary>
    ///      Remove some value from ICollection
    /// </summary>
    /// <param name="value">Removed value</param>
    /// <returns>True if value is add</returns>
    bool RemoveFromEnumerable(TValue value);

}