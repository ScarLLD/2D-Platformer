using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected void OnEnable()
    {
        _health.AmountChanged += OnAmountChanged;
    }

    protected void Start()
    {
        OnAmountChanged(_health.CurrentHealth, _health.MaxHealth);
    }

    protected void OnDisable()
    {
        _health.AmountChanged -= OnAmountChanged;
    }

    public virtual void OnAmountChanged(float currentHealth, float maxHealth) { }
}
