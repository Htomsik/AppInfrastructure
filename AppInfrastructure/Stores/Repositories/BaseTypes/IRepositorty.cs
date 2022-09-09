using AppInfrastructure.Services.NavigationServices.Close;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Stores.Repositories.BaseTypes;

/// <summary>
///     Repository
/// </summary>
public interface IRepository : IStore, ICloseServices
{
    /// <summary>
    ///     Add some value from store
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
///     Repository wit generic types
/// </summary>
/// <typeparam name="TValue">Some generic types</typeparam>
public interface IRepository<TValue> :  IStore<TValue>, ICloseServices
{
    
    /// <summary>
    ///     Add some value from store
    /// </summary>
    /// <param name="value">added value</param>
    /// <returns>True if value is add</returns>
    bool Add(TValue value);

    /// <summary>
    ///     Remove some value from store
    /// </summary>
    /// <param name="value"></param>
    /// <returns>True if value removed</returns>
    bool Remove(TValue value);
}


