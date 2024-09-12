using System;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;

    public int MaxValue { get { return _maxValue; } }
    protected float CurrentValue { get; private set; }

    public event Action Died;
    public event Action<float> ValueChanged;

    public void TakeDamage(float damage)
    {
        if (CurrentValue == 0)
            return;

        if (damage < 0)
            damage *= -1;

        CurrentValue = Math.Clamp(CurrentValue - damage, 0, _maxValue);

        ValueChanged?.Invoke(CurrentValue);

        if (CurrentValue == 0)
        {
            Died?.Invoke();
        }
    }

    public void Regenerate(float desiredCount)
    {
        if ((CurrentValue + desiredCount) < _maxValue)
        {
            CurrentValue += desiredCount;
        }
        else
        {
            CurrentValue = _maxValue;
        }

        ValueChanged?.Invoke(CurrentValue);
    }
}
