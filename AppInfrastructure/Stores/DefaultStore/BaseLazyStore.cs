namespace AppInfrastructure.Stores.DefaultStore;

/// <summary>
///     Base Lazy Realize for IStore.
/// </summary>
/// <typeparam name="TValue">Value with some type</typeparam>
public class BaseLazyStore<TValue> : BaseLazyStore, IStore<TValue>
{
    #region CurrentValue
    
    public new  TValue? CurrentValue
    {
        get => (TValue?)_currentValue.Value;
        set
        {
            _currentValue =  new Lazy<object?>(() => value);
            OnCurrentValueChanged();
        }
    }

    #endregion

    #region Constructors

    public BaseLazyStore(TValue value) => CurrentValue = value;

    public BaseLazyStore(){}

    #endregion
    
}

public class BaseLazyStore : IStore
{
    #region CurrentValue

    protected Lazy<object?> _currentValue = new (()=>default);
    
    public object? CurrentValue
    {
        get => _currentValue.Value;
        set
        {
            _currentValue =  new Lazy<object?>(() => value);
            OnCurrentValueChanged();
        }
    }

    #endregion

    #region CurrentValueChangedNotifier

    protected void OnCurrentValueChanged() =>  CurrentValueChangedNotifier?.Invoke();
    public event Action? CurrentValueChangedNotifier;

    #endregion

    #region Constructors

    public BaseLazyStore(object value) => CurrentValue = value;

    public BaseLazyStore(){}

    #endregion
    
}