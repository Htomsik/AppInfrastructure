namespace AppInfrastructure.Stores.DefaultStore;

/// <summary>
///     Simple generic some value storage
/// </summary>
public interface IStore<TValue> : IStore
{
   new TValue CurrentValue { get; set; }
   
}

/// <summary>
///     Simple some value storage
/// </summary>
/// <typeparam name="TValue">Value with some type</typeparam>
public interface IStore
{
    /// <summary>
    ///     Current value in store
    /// </summary>
     object? CurrentValue { get; set; }

    /// <summary>
    ///     Notify when value is changed  
    /// </summary>
    event Action? CurrentValueChangedNotifier;
    
    
    /// <summary>
    ///     Notify when value is null or default 
    /// </summary>
    event Action? CurrentValueDeletedNotifier;
}
