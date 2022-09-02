namespace AppInfrastructure.Stores;

/// <summary>
///     Base Lazy Realize for IStore.
/// </summary>
/// <typeparam name="TValue">Value with some type</typeparam>
public class BaseLazyStore<TValue> : IStore<TValue> 
{
    #region CurrentValue

    private Lazy<TValue?> _currentValue = new (()=>default);
    
    public TValue? CurrentValue
    {
        get => _currentValue.Value;
        set
        {
            _currentValue =  new Lazy<TValue?>(() => value);
            CurrentValueChangedNotifier?.Invoke();
        }
    }

    #endregion

    public event Action? CurrentValueChangedNotifier;
}