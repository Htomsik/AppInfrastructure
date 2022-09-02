namespace AppInfrastructure.Stores;


/// <summary>
///     Simple some value storage
/// </summary>
/// <typeparam name="TValue">Value with some type</typeparam>
public interface IStore<TValue>
{
    /// <summary>
    ///     Current value in store
    /// </summary>
    public TValue? CurrentValue { get; set; }

    /// <summary>
    ///     Notify when value is changed  
    /// </summary>
    public event Action? CurrentValueChangedNotifier;
}